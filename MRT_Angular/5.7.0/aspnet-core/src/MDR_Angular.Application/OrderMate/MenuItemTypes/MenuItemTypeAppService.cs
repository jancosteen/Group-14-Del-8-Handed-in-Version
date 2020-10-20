using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.MenuItemTypes.Dto;

namespace MDR_Angular.OrderMate.MenuItemTypes
{
    //[AbpAuthorize(PermissionNames.Pages_MIT)]
    public class MenuItemTypeAppService : AsyncCrudAppService<
        MenuItemType, MenuItemTypeDto, int, PagedAndSortedResultRequestDto, MenuItemTypeDto>, IMenuItemTypeAppService
    {
        public MenuItemTypeAppService(IRepository<MenuItemType> repository) : base(repository) { }
    }
}
