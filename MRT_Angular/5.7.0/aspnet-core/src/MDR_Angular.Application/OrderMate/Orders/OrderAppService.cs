using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.Authorization.Users;
using MDR_Angular.Features.Email;
using MDR_Angular.OrderMate.Orders.Dto;
using MDR_Angular.OrderMate.OrderStatusses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace MDR_Angular.OrderMate.Orders
{
    //[AbpAuthorize(PermissionNames.Pages_O)]
    public class OrderAppService : AsyncCrudAppService<
        Order, OrderDto, int, PagedAndSortedResultRequestDto, OrderDto>, IOrderAppService
    {

        private readonly UserManager _userManager;
        private readonly IRepository<OrderStatus> _status;
        private readonly IEmail _email;
        public OrderAppService(IRepository<Order> repository,
            UserManager userManager,
            IRepository<OrderStatus> status,
            IEmail email) : base(repository) {
            _userManager = userManager;
            _status = status;
            _email = email;
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

        public ListResultDto<OrderDto> GetOrderByQrCodeId(int id)
        {
            var order = Repository
                .GetAll().Where(x => x.QrCodeSeating.QrCodeIdFk == id)
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


        

        
        public async Task<List<dynamic>> GetOrderByUser()
        {
            dynamic outObject = new ExpandoObject();
            var orders = Repository
                    .GetAll()
                    .AsEnumerable()
                    .GroupBy(x => x.CreatorUserId)
                    .ToList();

            var users = await _userManager.Users.ToListAsync();
            List<dynamic> userGroup = new List<dynamic>();

            foreach( var group in orders)
            {
                foreach (var x in users)
                {
                    if (x.Id == group.Key)
                    {
                        dynamic user = new ExpandoObject();
                        user.Name = x.FullName;
                        List<dynamic> orderlist = new List<dynamic>();
                        foreach (var item in group)
                        {
                            var stat = _status.Get((int)item.OrderStatusIdFk);
                            dynamic resobj = new ExpandoObject();
                            resobj.No = item.Id;
                            resobj.Date = item.CreationTime;
                            resobj.Status = stat.OrderStatus1;
                            orderlist.Add(resobj);
                        }
                        user.ordersList = orderlist;
                        userGroup.Add(user);
                    }
                }
            }


            return userGroup;

        }

        public async Task<bool> SendEmail(orderEmail input)
        {
            var user = await _userManager.GetUserByIdAsync(input.userId);

            var stat = _status.Get(input.statudId);



            if (user != null)
            {
                var message = "<h1> Hello " + user.FullName + "</h1><br><h3>Your order is " + stat.OrderStatus1 + "</h3>";



                await _email.SendEmailAsync("OrderMate", "ordermate370@gmail.com", user.FullName, user.EmailAddress, "Order Status", message);

            }
            return true;
        }





    }


}
