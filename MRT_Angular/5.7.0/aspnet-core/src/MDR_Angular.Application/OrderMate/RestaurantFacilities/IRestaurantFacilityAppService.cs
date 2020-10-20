using Abp.Application.Services;

namespace MDR_Angular.OrderMate.RestaurantFacilities
{
    public interface IRestaurantFacilityAppService : IAsyncCrudAppService<RestaurantFacilityDto>
    {
    }
}
