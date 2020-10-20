using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.MenuItemAllergies.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDR_Angular.OrderMate.MenuItemAllergies
{
    //[AbpAuthorize(PermissionNames.Pages_MIA)]
    public class MenuItemAllergyAppService : AsyncCrudAppService<
        MenuItemAllergy, MenuItemAllergyDto, int, PagedAndSortedResultRequestDto, MenuItemAllergyDto>, IMenuItemAllergyAppService
    {
        public MenuItemAllergyAppService(IRepository<MenuItemAllergy> repository) : base(repository) { }

        public ListResultDto<MenuItemAllergyDto> GetAllergyByMenuItemId(int id)
        {
            var allergies = Repository
                .GetAll()
                .Where(x => x.MenuItemIdFk == id)
                .Include(i => i.AllergyIdFkNavigation)
                .ToList();

            return new ListResultDto<MenuItemAllergyDto>(ObjectMapper.Map<List<MenuItemAllergyDto>>(allergies));



        }
    }
}
