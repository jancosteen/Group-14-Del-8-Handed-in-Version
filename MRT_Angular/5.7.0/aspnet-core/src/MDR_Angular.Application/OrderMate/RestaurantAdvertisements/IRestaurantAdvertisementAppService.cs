using Abp.Application.Services;

namespace MDR_Angular.OrderMate.RestaurantAdvertisements
{
    public interface IRestaurantAdvertisementAppService : IAsyncCrudAppService<RestaurantAdvertisementDto>
    {
    }
}
