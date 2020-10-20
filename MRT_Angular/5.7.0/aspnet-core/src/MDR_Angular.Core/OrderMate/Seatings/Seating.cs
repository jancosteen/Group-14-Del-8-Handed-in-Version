using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.QrCodeSeatings;
using MDR_Angular.OrderMate.Reservations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.Seatings
{
    public class Seating : FullAuditedEntity<int>
    {
        //public int SeatingId { get; set; }
        public DateTime SeatingDate { get; set; }
        public TimeSpan SeatingTime { get; set; }
        public int? ReservationIdFk { get; set; }

        [ForeignKey("ReservationIdFk")]
        public virtual Reservation ReservationIdFkNavigation { get; set; }
        public virtual ICollection<QrCodeSeating> QrCodeSeating { get; set; }
    }
}
