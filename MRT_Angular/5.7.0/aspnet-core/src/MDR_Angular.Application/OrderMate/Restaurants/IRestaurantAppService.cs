using Abp.Application.Services;
using Abp.Application.Services.Dto;

namespace MDR_Angular.OrderMate.Restaurants
{
    public interface IRestaurantAppService : IAsyncCrudAppService<RestaurantDto>
    {
        ListResultDto<RestaurantDto> GetRestById(int id);

    }
}
