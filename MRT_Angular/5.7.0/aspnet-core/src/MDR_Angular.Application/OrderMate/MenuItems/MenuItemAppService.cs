using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.MenuItems.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MDR_Angular.OrderMate.MenuItems
{
    //[AbpAuthorize(PermissionNames.Pages_MI)]
    public class MenuItemAppService : AsyncCrudAppService<
        MenuItem, MenuItemDto, int, PagedAndSortedResultRequestDto, MenuItemDto>, IMenuItemAppService
    {
        public MenuItemAppService(IRepository<MenuItem> repository) : base(repository) { }

        public ListResultDto<MenuItemDto> GetyMenuItemById(int id)
        {
            var menuItem = Repository
                .GetAll()
                .Include(i => i.MenuItemAllergy).ThenInclude(i => i.AllergyIdFkNavigation)
                .Include(i => i.MenuItemCategoryIdFkNavigation)
                .Include(i => i.MenuItemPriceIdFkNavigation)
                .Include(i => i.ItemTypeMenuMenuItem).ThenInclude(i => i.MenuItemTypeIdFkNavigation)
                .Where(x => x.Id == id)
                .ToList();

            return new ListResultDto<MenuItemDto>(ObjectMapper.Map<List<MenuItemDto>>(menuItem));

        }

        protected override IQueryable<MenuItem> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .Include(i => i.MenuItemAllergy)     
                .Include(i => i.MenuItemCategoryIdFkNavigation)
                .Include(i => i.MenuItemPriceIdFkNavigation)
                //.Include(i => i.Menu)
                .Include(i => i.MenuItemSpecial).ThenInclude(x => x.SpecialIdFkNavigation)
                .Include(i => i.ItemTypeMenuMenuItem).ThenInclude(x => x.MenuItemTypeIdFkNavigation)
                .Include(i => i.MenuItemAllergy).ThenInclude(x=> x.AllergyIdFkNavigation)
                .Include(i => i.MenuItemSpecial).ThenInclude(x => x.SpecialIdFkNavigation);
        }


    }
}
