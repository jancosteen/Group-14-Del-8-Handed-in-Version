using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.RestaurantFacilityRefs
{
    //[AbpAuthorize(PermissionNames.Pages_RFR)]
    public class RestaurantFacilityRefAppService : AsyncCrudAppService<
        RestaurantFacilityRef, RestaurantFacilityRefDto, int, PagedAndSortedResultRequestDto, RestaurantFacilityRefDto>, IRestaurantFacilityRefAppService
    {
        public RestaurantFacilityRefAppService(IRepository<RestaurantFacilityRef> repository) : base(repository) { }
    }
}
