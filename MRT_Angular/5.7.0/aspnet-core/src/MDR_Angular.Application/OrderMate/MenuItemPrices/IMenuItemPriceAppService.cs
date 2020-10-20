using Abp.Application.Services;
using MDR_Angular.OrderMate.MenuItemPrices.Dto;

namespace MDR_Angular.OrderMate.MenuItemPrices
{
    public interface IMenuItemPriceAppService : IAsyncCrudAppService<MenuItemPriceDto>
    {
    }
}
