using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Orders;
using MDR_Angular.OrderMate.QrCodes;
using MDR_Angular.OrderMate.Seatings;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.QrCodeSeatings
{
    public class QrCodeSeating : FullAuditedEntity<int>
    {
        //public int QrCodeSeatingId { get; set; }
        public int NrOfPeople { get; set; }
        public int QrCodeIdFk { get; set; }
        public int SeatingIdFk { get; set; }
        public int? OrderIdFk { get; set; }

        [ForeignKey("OrderIdFk")]
        public virtual Order OrderIdFkNavigation { get; set; }
        [ForeignKey("QrCodeIdFk")]
        public virtual QrCode QrCodeIdFkNavigation { get; set; }
        [ForeignKey("SeatingIdFk")]
        public virtual Seating SeatingIdFkNavigation { get; set; }
    }
}
