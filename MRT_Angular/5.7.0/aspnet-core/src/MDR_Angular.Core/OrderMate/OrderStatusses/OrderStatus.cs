using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Orders;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.OrderStatusses
{
    public class OrderStatus : FullAuditedEntity<int>
    {
        //public int OrderStatusId { get; set; }
        public string OrderStatus1 { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
