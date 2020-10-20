using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.RestaurantTypes
{
    //[AbpAuthorize(PermissionNames.Pages_RT)]
    public class RestaurantTypeAppService : AsyncCrudAppService<
        RestaurantType, RestaurantTypeDto, int, PagedAndSortedResultRequestDto, RestaurantTypeDto>, IRestaurantTypeAppService
    {
        public RestaurantTypeAppService(IRepository<RestaurantType> repository) : base(repository) { }
    }
}
