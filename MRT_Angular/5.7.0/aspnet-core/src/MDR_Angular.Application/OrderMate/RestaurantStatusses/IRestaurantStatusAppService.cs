using Abp.Application.Services;

namespace MDR_Angular.OrderMate.RestaurantStatusses
{
    public interface IRestaurantStatusAppService : IAsyncCrudAppService<RestaurantStatusDto>
    {
    }
}
