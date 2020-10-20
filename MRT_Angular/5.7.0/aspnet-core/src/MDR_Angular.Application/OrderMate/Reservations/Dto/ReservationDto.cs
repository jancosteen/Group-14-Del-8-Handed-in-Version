using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.ReservationRestaurants;
using MDR_Angular.OrderMate.ReservationStatusses;
using MDR_Angular.OrderMate.Restaurants;
using MDR_Angular.OrderMate.Seatings;
using MDR_Angular.Users.Dto;
using System;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.Reservations
{
    [AutoMapFrom(typeof(Reservation))]
    [AutoMapTo(typeof(Reservation))]
    public class ReservationDto : FullAuditedEntityDto<int>
    {
        //public int ReservationId { get; set; }
        public DateTime ReservationDateCreated { get; set; }
        public DateTime ReservationDateReserved { get; set; }
        public int ReservationPartyQty { get; set; }
        public long UserIdFk { get; set; }
        public int? ReservationStatusIdFk { get; set; }
        public int ReservationNumberOfBills { get; set; }
        public int RestaurantIdFk { get; set; }

        public virtual ReservationStatusDto ReservationStatusIdFkNavigation { get; set; }
        public virtual UserDto UserIdFkNavigation { get; set; }
        //public virtual ICollection<ReservationRestaurantDto> ReservationRestaurant { get; set; }
        public virtual ICollection<SeatingDto> Seating { get; set; }
        public virtual RestaurantDto RestaurantIdFkNavigation { get; set; }



    }
}
