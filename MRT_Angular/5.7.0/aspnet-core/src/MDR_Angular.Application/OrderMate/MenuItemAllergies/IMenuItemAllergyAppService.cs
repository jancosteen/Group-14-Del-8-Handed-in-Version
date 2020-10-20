using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MDR_Angular.OrderMate.MenuItemAllergies.Dto;

namespace MDR_Angular.OrderMate.MenuItemAllergies
{
    public interface IMenuItemAllergyAppService : IAsyncCrudAppService<MenuItemAllergyDto>
    {
        ListResultDto<MenuItemAllergyDto> GetAllergyByMenuItemId(int id);
    }
}
