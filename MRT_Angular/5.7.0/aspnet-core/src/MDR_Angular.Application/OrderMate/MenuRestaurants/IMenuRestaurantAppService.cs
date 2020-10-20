using Abp.Application.Services;
using MDR_Angular.OrderMate.MenuRestaurants.Dto;

namespace MDR_Angular.OrderMate.MenuRestaurants
{
    public interface IMenuRestaurantAppService : IAsyncCrudAppService<MenuRestaurantDto>
    {
    }
}
