using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MDR_Angular.OrderMate.OrderLines.Dto;

namespace MDR_Angular.OrderMate.OrderLines
{
    public interface IOrderLineAppService : IAsyncCrudAppService<OrderLineDto>
    {
        ListResultDto<OrderLineDto> GetOrderLineByOrderId(int id);
    }
}
