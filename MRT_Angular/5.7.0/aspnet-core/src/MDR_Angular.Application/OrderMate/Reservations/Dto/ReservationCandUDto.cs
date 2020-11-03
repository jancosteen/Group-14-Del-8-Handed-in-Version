using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.Reservations
{
    [AutoMapFrom(typeof(Reservation))]
    [AutoMapTo(typeof(Reservation))]
    public class ReservationCandUDto: EntityDto<int>
    {
        //public int ReservationId { get; set; }
        //public DateTime ReservationDateCreated { get; set; }
        public DateTime ReservationDateReserved { get; set; }
        public int ReservationPartyQty { get; set; }
        public long UserIdFk { get; set; }
        public int? ReservationStatusIdFk { get; set; }
        public int ReservationNumberOfBills { get; set; }
        public int RestaurantIdFk { get; set; }


    }
}
