using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.Orders.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MDR_Angular.OrderMate.Orders
{
    //[AbpAuthorize(PermissionNames.Pages_O)]
    public class OrderAppService : AsyncCrudAppService<
        Order, OrderDto, int, PagedAndSortedResultRequestDto, OrderDto>, IOrderAppService
    {
        public OrderAppService(IRepository<Order> repository) : base(repository) { }

        public ListResultDto<OrderDto> GetOrderById(int id)
        {
            var order = Repository
                .GetAll().Where(x => x.Id == id)
                .Include(i => i.OrderLine).ThenInclude(i => i.MenuItemIdFkNavigation).ThenInclude(i => i.MenuItemPriceIdFkNavigation)
                .Include(i => i.OrderStatusIdFkNavigation)
                .Include(i => i.QrCodeSeating)
                //.Include(i => i.OrderLine).ThenInclude(i => i.UserIdFkNavigation)

                .ToList();
            return new ListResultDto<OrderDto>(ObjectMapper.Map<List<OrderDto>>(order));
        }

        protected override IQueryable<Order> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .Include(i => i.OrderLine)
                .Include(i => i.OrderStatusIdFkNavigation)
                .Include(i => i.QrCodeSeating);
        }

    }

    
}
