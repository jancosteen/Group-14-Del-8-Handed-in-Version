using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.ReservationRestaurants
{
    [AutoMapFrom(typeof(ReservationRestaurant))]
    [AutoMapTo(typeof(ReservationRestaurant))]
    public class ReservationRestaurantDto : FullAuditedEntityDto<int>
    {
        //public int ReservationRestaurantId { get; set; }
        public int ReservationIdFk { get; set; }
        public int RestaurantIdFk { get; set; }

    }
}
