using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.MenuItemCategories.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MDR_Angular.OrderMate.MenuItemCategories
{
    //[AbpAuthorize(PermissionNames.Pages_MIC)]
    public class MenuItemCategoryAppService : AsyncCrudAppService<
        MenuItemCategory, MenuItemCategoryDto, int, PagedAndSortedResultRequestDto, MenuItemCategoryDto>, IMenuItemCategoryAppService
    {
        public MenuItemCategoryAppService(IRepository<MenuItemCategory> repository) : base(repository) { }

        public ListResultDto<MenuItemCategoryDetailsDto> GetMicAndMi()
        {
            var menuItem = Repository
                .GetAll()
                .Include(i => i.MenuItem)
                .ToList();

            return new ListResultDto<MenuItemCategoryDetailsDto>(ObjectMapper.Map<List<MenuItemCategoryDetailsDto>>(menuItem));

        }

        
    }
}
