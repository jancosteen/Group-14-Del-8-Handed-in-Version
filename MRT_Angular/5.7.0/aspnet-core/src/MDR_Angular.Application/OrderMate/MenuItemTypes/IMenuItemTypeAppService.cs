using Abp.Application.Services;
using MDR_Angular.OrderMate.MenuItemTypes.Dto;

namespace MDR_Angular.OrderMate.MenuItemTypes
{
    public interface IMenuItemTypeAppService : IAsyncCrudAppService<MenuItemTypeDto>
    {
    }
}
