using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.SupplierOrders;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.Suppliers
{
    public class Supplier : FullAuditedEntity<int>
    {
        //public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierContactNumber { get; set; }
        public string SupplierAddressLine1 { get; set; }
        public string SupplierAddressLine2 { get; set; }
        public string SupplierAddressLine3 { get; set; }
        public string SupplierCity { get; set; }
        public string SupplierPostalCode { get; set; }
        public string SupplierCountry { get; set; }

        public virtual ICollection<SupplierOrder> SupplierOrder { get; set; }
    }
}
