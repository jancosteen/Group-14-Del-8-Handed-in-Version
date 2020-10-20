using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MDR_Angular.OrderMate.MenuItems.Dto;

namespace MDR_Angular.OrderMate.MenuItems
{
    public interface IMenuItemAppService : IAsyncCrudAppService<MenuItemDto>
    {
        ListResultDto<MenuItemDto> GetyMenuItemById(int id);

    }
}
