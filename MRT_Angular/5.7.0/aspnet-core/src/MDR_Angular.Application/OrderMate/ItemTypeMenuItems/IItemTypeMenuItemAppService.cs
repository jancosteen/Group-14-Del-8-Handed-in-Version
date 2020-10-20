using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MDR_Angular.OrderMate.ItemTypeMenuItems.Dto;

namespace MDR_Angular.OrderMate.ItemTypeMenuItems
{
    public interface IItemTypeMenuItemAppService : IAsyncCrudAppService<ItemTypeMenuItemDto>
    {
        ListResultDto<ItemTypeMenuItemDto> GetTypeByMenuItemId(int id);
    }
}
