using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using MDR_Angular.OrderMate.Allergies.Dto;

namespace MDR_Angular.OrderMate.Allergies
{
    //[AbpAuthorize(PermissionNames.Pages_Al)]
    public class AllergyAppService : AsyncCrudAppService<
        Allergy, AllergyDto, int, PagedAndSortedResultRequestDto, AllergyDto>, IAllergyAppService
    {
        public AllergyAppService(IRepository<Allergy> repository) : base(repository) { }
    }
}
