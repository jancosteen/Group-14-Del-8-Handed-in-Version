using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.RestaurantTypeReferences
{
    //[AbpAuthorize(PermissionNames.Pages_RTR)]
    public class RestaurantTypeReferenceAppService : AsyncCrudAppService<
        RestaurantTypeRef, RestaurantTypeRefDto, int, PagedAndSortedResultRequestDto, RestaurantTypeRefDto>, IRestaurantTypeReferenceAppService
    {
        public RestaurantTypeReferenceAppService(IRepository<RestaurantTypeRef> repository) : base(repository) { }
    }
}
