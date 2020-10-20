using Abp.Application.Services;
using MDR_Angular.OrderMate.MenuItemSpecials.Dto;

namespace MDR_Angular.OrderMate.MenuItemSpecials
{
    public interface IMenuItemSpecialAppService : IAsyncCrudAppService<MenuItemSpecialDto>
    {
    }
}
