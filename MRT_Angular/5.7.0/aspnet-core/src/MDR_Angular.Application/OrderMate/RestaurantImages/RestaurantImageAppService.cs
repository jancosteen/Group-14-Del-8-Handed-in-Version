using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.RestaurantImages
{
    //[AbpAuthorize(PermissionNames.Pages_RI)]
    public class RestaurantImageAppService : AsyncCrudAppService<
        RestaurantImage, RestaurantImageDto, int, PagedAndSortedResultRequestDto, RestaurantImageDto>, IRestaurantImageAppService
    {
        public RestaurantImageAppService(IRepository<RestaurantImage> repository) : base(repository) { }
    }
}
