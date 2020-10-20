using Abp.Application.Services;
using MDR_Angular.OrderMate.OrderStatusses.Dto;

namespace MDR_Angular.OrderMate.OrderStatusses
{
    public interface IOrderStatusAppService : IAsyncCrudAppService<OrderStatusDto>
    {
    }
}
