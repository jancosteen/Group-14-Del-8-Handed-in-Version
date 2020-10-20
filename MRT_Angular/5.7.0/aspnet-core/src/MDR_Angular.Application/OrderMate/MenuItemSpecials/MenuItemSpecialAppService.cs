using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.MenuItemSpecials.Dto;

namespace MDR_Angular.OrderMate.MenuItemSpecials
{
    //[AbpAuthorize(PermissionNames.Pages_MIS)]
    public class MenuItemSpecialAppService : AsyncCrudAppService<
        MenuItemSpecial, MenuItemSpecialDto, int, PagedAndSortedResultRequestDto, MenuItemSpecialDto>, IMenuItemSpecialAppService
    {
        public MenuItemSpecialAppService(IRepository<MenuItemSpecial> repository) : base(repository) { }
    }
}
