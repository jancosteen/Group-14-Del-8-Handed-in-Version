using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.ItemTypeMenuItems.Dto;
using MDR_Angular.OrderMate.ItemTypeMenuMenuItems;
using MDR_Angular.OrderMate.Menus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDR_Angular.OrderMate.ItemTypeMenuItems
{
    //[AbpAuthorize(PermissionNames.Pages_MI)]
    public class ItemTypeMenuItemAppService : AsyncCrudAppService<
        ItemTypeMenuItem, ItemTypeMenuItemDto, int, PagedAndSortedResultRequestDto, ItemTypeMenuItemDto>, IItemTypeMenuItemAppService
    {
        public ItemTypeMenuItemAppService(IRepository<ItemTypeMenuItem> repository) : base(repository) { }

        public ListResultDto<ItemTypeMenuItemDto> GetTypeByMenuItemId(int id)
        {
            var itemTypes = Repository
                .GetAll()
                .Where(x => x.MenuItemIdFk == id)
                .Include(i => i.MenuItemTypeIdFkNavigation)
                .Include(i => i.MenuItemTypeIdFkNavigation).Include(i => i.MenuItemTypeIdFkNavigation)
                .ToList();

            return new ListResultDto<ItemTypeMenuItemDto>(ObjectMapper.Map<List<ItemTypeMenuItemDto>>(itemTypes));


        }

        protected override IQueryable<ItemTypeMenuItem> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)                
                .Include(i => i.MenuItemTypeIdFkNavigation)
                .Include(i => i.MenuItemTypeIdFkNavigation).Include(i=>i.MenuItemTypeIdFkNavigation);
        }

    }
}
