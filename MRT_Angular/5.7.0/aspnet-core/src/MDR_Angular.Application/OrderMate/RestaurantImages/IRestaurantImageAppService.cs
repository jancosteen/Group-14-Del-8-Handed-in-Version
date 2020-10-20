using Abp.Application.Services;

namespace MDR_Angular.OrderMate.RestaurantImages
{
    public interface IRestaurantImageAppService : IAsyncCrudAppService<RestaurantImageDto>
    {
    }
}
