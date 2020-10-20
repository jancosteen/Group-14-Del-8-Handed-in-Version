using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using MDR_Angular.Authorization;

namespace MDR_Angular.OrderMate.RestaurantRestaurantImages
{
    //[AbpAuthorize(PermissionNames.Pages_RRI)]
    public class RestaurantRestaurantImageAppService : AsyncCrudAppService<
        RestaurantRestaurantImage, RestaurantRestaurantImageDto, int, PagedAndSortedResultRequestDto, RestaurantRestaurantImageDto>, IRestaurantRestaurantImageAppService
    {
        public RestaurantRestaurantImageAppService(IRepository<RestaurantRestaurantImage> repository) : base(repository) { }
    }
}
