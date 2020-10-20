using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.ReservationRestaurants
{
    [AutoMapFrom(typeof(ReservationRestaurant))]
    [AutoMapTo(typeof(ReservationRestaurant))]
    public class ReservationRestaurantCandUDto
    {
        //public int ReservationRestaurantId { get; set; }
        public int ReservationIdFk { get; set; }
        public int RestaurantIdFk { get; set; }


    }
}
