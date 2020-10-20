using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.MenuItemPrices.Dto;

namespace MDR_Angular.OrderMate.MenuItemPrices
{
    //[AbpAuthorize(PermissionNames.Pages_MIP)]
    public class MenuItemPriceAppService : AsyncCrudAppService<
        MenuItemPrice, MenuItemPriceDto, int, PagedAndSortedResultRequestDto, MenuItemPriceDto>, IMenuItemPriceAppService
    {
        public MenuItemPriceAppService(IRepository<MenuItemPrice> repository) : base(repository) { }
    }
}
