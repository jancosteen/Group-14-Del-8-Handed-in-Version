using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.OrderStatusses.Dto;

namespace MDR_Angular.OrderMate.OrderStatusses
{
    //[AbpAuthorize(PermissionNames.Pages_OS)]
    public class OrderStatusAppService : AsyncCrudAppService<
        OrderStatus, OrderStatusDto, int, PagedAndSortedResultRequestDto, OrderStatusDto>, IOrderStatusAppService
    {
        public OrderStatusAppService(IRepository<OrderStatus> repository) : base(repository) { }
    }
}
