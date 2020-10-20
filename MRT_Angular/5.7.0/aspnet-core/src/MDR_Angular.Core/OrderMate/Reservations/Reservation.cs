using Abp.Domain.Entities.Auditing;
using MDR_Angular.Authorization.Users;
using MDR_Angular.OrderMate.ReservationRestaurants;
using MDR_Angular.OrderMate.ReservationStatusses;
using MDR_Angular.OrderMate.Restaurants;
using MDR_Angular.OrderMate.Seatings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.Reservations
{
    public class Reservation : FullAuditedEntity<int>
    {
        //public int ReservationId { get; set; }
        public DateTime ReservationDateCreated { get; set; }
        public DateTime ReservationDateReserved { get; set; }
        public int ReservationPartyQty { get; set; }
        public long UserIdFk { get; set; }
        public int? ReservationStatusIdFk { get; set; }
        public int ReservationNumberOfBills { get; set; }
        public int RestaurantIdFk { get; set; }

        [ForeignKey("ReservationStatusIdFk")]
        public virtual ReservationStatus ReservationStatusIdFkNavigation { get; set; }
        [ForeignKey("UserIdFk")]
        public virtual User UserIdFkNavigation { get; set; }
        [ForeignKey("RestaurantIdFk")]
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        //public virtual ICollection<ReservationRestaurant> ReservationRestaurant { get; set; }
        public virtual ICollection<Seating> Seating { get; set; }
    }
}
