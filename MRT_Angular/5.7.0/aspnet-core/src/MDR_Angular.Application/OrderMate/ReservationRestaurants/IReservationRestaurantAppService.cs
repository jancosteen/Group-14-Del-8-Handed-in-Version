using Abp.Application.Services;

namespace MDR_Angular.OrderMate.ReservationRestaurants
{
    public interface IReservationRestaurantAppService : IAsyncCrudAppService<ReservationRestaurantDto>
    {
    }
}
