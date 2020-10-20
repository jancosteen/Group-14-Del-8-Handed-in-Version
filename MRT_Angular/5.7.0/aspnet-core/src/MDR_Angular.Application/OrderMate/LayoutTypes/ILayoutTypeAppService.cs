using Abp.Application.Services;
using MDR_Angular.OrderMate.LayoutTypes.Dto;

namespace MDR_Angular.OrderMate.LayoutTypes
{
    public interface ILayoutTypeAppService : IAsyncCrudAppService<LayoutTypeDto>
    {
    }
}
