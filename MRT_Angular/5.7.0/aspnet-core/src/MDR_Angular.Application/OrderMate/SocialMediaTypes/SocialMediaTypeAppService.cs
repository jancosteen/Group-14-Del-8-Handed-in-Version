using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.SocialMediaTypes
{
    //[AbpAuthorize(PermissionNames.Pages_SMT)]
    public class SocialMediaTypeAppService : AsyncCrudAppService<
        SocialMediaType, SocialMediaTypeDto, int, PagedAndSortedResultRequestDto, SocialMediaTypeDto>, ISocialMediaTypeAppService
    {
        public SocialMediaTypeAppService(IRepository<SocialMediaType> repository) : base(repository) { }
    }
}
