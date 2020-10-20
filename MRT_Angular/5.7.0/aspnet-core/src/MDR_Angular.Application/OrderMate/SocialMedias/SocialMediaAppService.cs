using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MDR_Angular.OrderMate.SocialMedias
{
    //[AbpAuthorize(PermissionNames.Pages_SM)]
    public class SocialMediaAppService : AsyncCrudAppService<
        SocialMedia, SocialMediaDto, int, PagedAndSortedResultRequestDto, SocialMediaDto>, ISocialMediaAppService
    {
        public SocialMediaAppService(IRepository<SocialMedia> repository) : base(repository) { }

        protected override IQueryable<SocialMedia> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .Include(i => i.RestaurantIdFkNavigation)
                .Include(i=> i.SocialMediaTypeIdFkNavigation);
        }
    }
}
