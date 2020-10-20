using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Products;
using MDR_Angular.OrderMate.SupplierOrders;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.SupplierOrderLines
{
    public class SupplierOrderLine : FullAuditedEntity<int>
    {
        //public int SupplierOrderLineId { get; set; }
        public int ProductIdFk { get; set; }
        public int SupplierOrderIdFk { get; set; }
        public int DeliveryLeadTime { get; set; }
        public double ProductStandardPrice { get; set; }
        public double DiscountAgreement { get; set; }
        public int OrderedQty { get; set; }

        [ForeignKey("ProductIdFk")]
        public virtual Product ProductIdFkNavigation { get; set; }
        [ForeignKey("SupplierOrderIdFk")]
        public virtual SupplierOrder SupplierOrderIdFkNavigation { get; set; }
    }
}
