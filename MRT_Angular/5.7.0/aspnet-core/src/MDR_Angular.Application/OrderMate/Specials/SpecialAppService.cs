using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.Specials
{
    //[AbpAuthorize(PermissionNames.Pages_S)]
    public class SpecialAppService : AsyncCrudAppService<
        Special, SpecialDto, int, PagedAndSortedResultRequestDto, SpecialDto>, ISpecialAppService
    {
        public SpecialAppService(IRepository<Special> repository) : base(repository) { }
    }
}
