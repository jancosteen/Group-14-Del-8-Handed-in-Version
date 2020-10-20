using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Reservations;
using MDR_Angular.OrderMate.Restaurants;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.ReservationRestaurants
{
    public class ReservationRestaurant : FullAuditedEntity<int>
    {
        //public int ReservationRestaurantId { get; set; }
        public int ReservationIdFk { get; set; }
        public int RestaurantIdFk { get; set; }

        /*[ForeignKey("ReservationIdFk")]
        public virtual Reservation ReservationIdFkNavigation { get; set; }
        [ForeignKey("RestaurantIdFk")]
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }*/
    }
}
