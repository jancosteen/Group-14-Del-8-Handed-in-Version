using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Employees;
using MDR_Angular.OrderMate.Products;
using MDR_Angular.OrderMate.WriteOffReasons;
using MDR_Angular.OrderMate.WrittenOffStocks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.ProductsWrittenOff
{
    public class ProductWrittenOff : FullAuditedEntity<int>
    {
        //public int WrittenOffStockIdFk { get; set; }
        public int ProductIdFk { get; set; }
        public int WrittenOffQty { get; set; }
        public int? EmployeeIdFk { get; set; }

        [ForeignKey("EmployeeIdFk")]
        public virtual Employee EmployeeIdFkNavigation { get; set; }
        [ForeignKey("ProductIdFk")]
        public virtual Product ProductIdFkNavigation { get; set; }
        [ForeignKey("WrittenOffStockIdFk")]
        public virtual WrittenOffStock WrittenOffStockIdFkNavigation { get; set; }
        public virtual ICollection<WriteOffReason> WriteOffReason { get; set; }
    }
}
