using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.SupplierOrderLines;
using MDR_Angular.OrderMate.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.SupplierOrders
{
    public class SupplierOrder : FullAuditedEntity<int>
    {
        //public int SupplierOrderId { get; set; }
        public DateTime SupplierOrderDate { get; set; }
        public int? SupplierIdFk { get; set; }

        [ForeignKey("SupplierIdFk")]
        public virtual Supplier SupplierIdFkNavigation { get; set; }
        public virtual ICollection<SupplierOrderLine> SupplierOrderLine { get; set; }
    }
}
