using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.RestaurantStatusses
{
    //[AbpAuthorize(PermissionNames.Pages_RS)]
    public class RestaurantStatusAppService : AsyncCrudAppService<
        RestaurantStatus, RestaurantStatusDto, int, PagedAndSortedResultRequestDto, RestaurantStatusDto>, IRestaurantStatusAppService
    {
        public RestaurantStatusAppService(IRepository<RestaurantStatus> repository) : base(repository) { }
    }
}
