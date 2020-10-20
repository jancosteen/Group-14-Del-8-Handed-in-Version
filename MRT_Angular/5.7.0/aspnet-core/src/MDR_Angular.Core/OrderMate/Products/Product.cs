using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.ProductCategories;
using MDR_Angular.OrderMate.ProductReorderFreqs;
using MDR_Angular.OrderMate.ProductStockTakes;
using MDR_Angular.OrderMate.ProductsWrittenOff;
using MDR_Angular.OrderMate.ProductTypes;
using MDR_Angular.OrderMate.SupplierOrderLines;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.Products
{
    public class Product : FullAuditedEntity<int>
    {
        //public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductReorderLevel { get; set; }
        public int ProductOnHand { get; set; }
        public int? ProductTypeIdFk { get; set; }
        public int? ProductCategoryIdFk { get; set; }
        public int? ProductReorderFreqIdFk { get; set; }

        [ForeignKey("ProductCategoryIdFk")]
        public virtual ProductCategory ProductCategoryIdFkNavigation { get; set; }
        [ForeignKey("ProductReorderFreqIdFk")]
        public virtual ProductReorderFreq ProductReorderFreqIdFkNavigation { get; set; }
        [ForeignKey("ProductTypeIdFk")]
        public virtual ProductType ProductTypeIdFkNavigation { get; set; }
        public virtual ICollection<ProductStockTake> ProductStockTake { get; set; }
        public virtual ICollection<ProductWrittenOff> ProductWrittenOff { get; set; }
        public virtual ICollection<SupplierOrderLine> SupplierOrderLine { get; set; }
    }
}
