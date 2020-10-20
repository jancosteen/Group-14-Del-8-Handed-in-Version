using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.OrderLines;
using MDR_Angular.OrderMate.OrderStatusses;
using MDR_Angular.OrderMate.QrCodeSeatings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.Orders
{
    public class Order : FullAuditedEntity<int>
    {
        //public int OrderId { get; set; }
        public DateTime OrderDateCreated { get; set; }
        public DateTime? OrderDateCompleted { get; set; }
        public int? QrCodeSeatingIdFk { get; set; }
        public int? OrderStatusIdFk { get; set; }

        [ForeignKey("OrderStatusIdFk")]
        public virtual OrderStatus OrderStatusIdFkNavigation { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
        [ForeignKey("QrCodeSeatingIdFk")]
        public virtual QrCodeSeating QrCodeSeating { get; set; }
    }
}
