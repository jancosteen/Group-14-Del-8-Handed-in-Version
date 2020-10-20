using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MDR_Angular.OrderMate.Menus
{
    //[AbpAuthorize(PermissionNames.Pages_M)]
    public class MenuAppService : AsyncCrudAppService<
        Menu, MenuDto, int, PagedAndSortedResultRequestDto, MenuDto>, IMenuAppService
    {
        public MenuAppService(IRepository<Menu> repository) : base(repository) { }

        public ListResultDto<MenuDto> GetMenuById(int id)
        {
            var menus = Repository
                .GetAll().Where(x=>x.Id == id)
                .Include(i => i.RestaurantIdFkNavigation)
                .Include(i => i.MenuItem)
                .Include(i => i.MenuItem).ThenInclude(i=> i.MenuItemCategoryIdFkNavigation)
                .Include(i => i.MenuItem).ThenInclude(i => i.MenuItemPriceIdFkNavigation)
                .ToList();
            return new ListResultDto<MenuDto>(ObjectMapper.Map<List<MenuDto>>(menus));
        }

        public ListResultDto<MenuDto> GetMenuByResId(int id)
        {
            var menus = Repository
                .GetAll().Where(x => x.RestaurantIdFk == id)
                .Include(i => i.RestaurantIdFkNavigation)
                .Include(i => i.MenuItem)
                .Include(i => i.MenuItem).ThenInclude(i => i.MenuItemCategoryIdFkNavigation)
                .Include(i => i.MenuItem).ThenInclude(i => i.MenuItemPriceIdFkNavigation)
                .ToList();
            return new ListResultDto<MenuDto>(ObjectMapper.Map<List<MenuDto>>(menus));
        }

        protected override IQueryable<Menu> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .Include(i => i.RestaurantIdFkNavigation)
                .Include(i => i.MenuItem);                
        }

        
    }
}
