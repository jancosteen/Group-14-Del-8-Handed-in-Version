using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.OrderLines.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MDR_Angular.OrderMate.OrderLines
{
    //[AbpAuthorize(PermissionNames.Pages_OL)]
    public class OrderLineAppService : AsyncCrudAppService<
        OrderLine, OrderLineDto, int, PagedAndSortedResultRequestDto, OrderLineDto>, IOrderLineAppService
    {
        public OrderLineAppService(IRepository<OrderLine> repository) : base(repository) { }

        public ListResultDto<OrderLineDto> GetOrderLineByOrderId(int id)
        {
            var orderLines = Repository
                .GetAll().Where(x => x.OrderIdFk == id)
                .Include(i => i.MenuItemIdFkNavigation)
               .Include(i => i.UserIdFkNavigation)
               .Include(i => i.MenuItemIdFkNavigation).ThenInclude(i => i.MenuItemPriceIdFkNavigation)
                
                .ToList();
            return new ListResultDto<OrderLineDto>(ObjectMapper.Map<List<OrderLineDto>>(orderLines));
        }

        protected override IQueryable<OrderLine> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .Include(i => i.MenuItemIdFkNavigation)
                .Include(i => i.MenuItemIdFkNavigation).ThenInclude(i=>i.MenuItemPriceIdFkNavigation)
                .Include(i => i.UserIdFkNavigation);             
        }
    }
}
