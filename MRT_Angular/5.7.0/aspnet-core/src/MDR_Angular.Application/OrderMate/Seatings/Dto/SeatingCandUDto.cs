using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.Seatings
{
    [AutoMapFrom(typeof(Seating))]
    [AutoMapTo(typeof(Seating))]
    public class SeatingCandUDto
    {
        //public int SeatingId { get; set; }
        public DateTime SeatingDate { get; set; }
        public TimeSpan SeatingTime { get; set; }
        public int? ReservationIdFk { get; set; }


    }
}
