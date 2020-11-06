using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.Authorization.Users;
using MDR_Angular.OrderMate.Orders.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace MDR_Angular.OrderMate.Orders
{
    //[AbpAuthorize(PermissionNames.Pages_O)]
    public class OrderAppService : AsyncCrudAppService<
        Order, OrderDto, int, PagedAndSortedResultRequestDto, OrderDto>, IOrderAppService
    {

        private readonly UserManager _userManager;
        public OrderAppService(IRepository<Order> repository,
            UserManager userManager) : base(repository) {
            _userManager = userManager;
        }

        public ListResultDto<OrderDto> GetOrderById(int id)
        {
            var order = Repository
                .GetAll().Where(x => x.Id == id)
                .Include(i => i.OrderLine).ThenInclude(i => i.MenuItemIdFkNavigation)
                .Include(i => i.OrderLine)
                .Include(i => i.OrderStatusIdFkNavigation)
                .Include(i => i.QrCodeSeating)
                //.Include(i => i.OrderLine).ThenInclude(i => i.UserIdFkNavigation)

                .ToList();
            return new ListResultDto<OrderDto>(ObjectMapper.Map<List<OrderDto>>(order));
        }


        public List<Order> GetTodayOrders()
        {
            var today = DateTime.Now;

            var orders = Repository
                    .GetAll().Where(x => x.OrderDateCompleted == today)
                    .Include(i => i.OrderLine).ThenInclude(i => i.MenuItemIdFkNavigation)
                    .Include(i => i.OrderLine)
                    .Include(i => i.OrderStatusIdFkNavigation)
                    .Include(i => i.QrCodeSeating)
                    .ToList();


            return orders;
        }
         

        protected override IQueryable<Order> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .Include(i => i.OrderLine)
                .Include(i => i.OrderStatusIdFkNavigation)
                .Include(i => i.QrCodeSeating);
        }


        public dynamic GetOrdersbyUser()
        {
            dynamic outObject = new ExpandoObject();
            var orders = Repository
                    .GetAll()
                    .Include(i => i.OrderLine).ThenInclude(i => i.MenuItemIdFkNavigation)
                    .Include(i => i.OrderLine)
                    .Include(i => i.OrderStatusIdFkNavigation)
                    .Include(i => i.QrCodeSeating)
                    .ToList();


            var orderList = orders.GroupBy(x => x.CreatorUserId);
            List<dynamic> Users = new List<dynamic>();
            foreach(var group in orders)
            {
                if (group.CreatorUserId != null)
                {
                    var id = (group.CreatorUserId);
                    var u = _userManager.GetUserById((long)id);
                    dynamic user = new ExpandoObject();
                    user.Name = u.FullName;
                    Users.Add(user);
                }
            }

            outObject.Users = Users;

            
            var custList = orders.GroupBy(x => x.CreatorUserId);

            List<dynamic> orderItems = new List<dynamic>();
            foreach(var group in custList)
            {
                dynamic order = new ExpandoObject();
                order.number = group.Key;
                order.sum = group.Sum(x => x.OrderLine.Count);
                List<dynamic> items = new List<dynamic>();
                foreach(var item in group)
                {
                    dynamic Obj = new ExpandoObject();
                    Obj.Name = item.OrderStatusIdFkNavigation.OrderStatus1;
                    Obj.Number = item.Id;
                    items.Add(item);
                }
                order.orders = items;
                orderItems.Add(order);
            }

            outObject.Orders = orderItems;
            return outObject;

        }




    }

    
}
