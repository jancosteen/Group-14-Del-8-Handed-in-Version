using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MDR_Angular.OrderMate.Orders.Dto;

namespace MDR_Angular.OrderMate.Orders
{
    public interface IOrderAppService : IAsyncCrudAppService<OrderDto>
    {
        ListResultDto<OrderDto> GetOrderById(int id);

    }
}
