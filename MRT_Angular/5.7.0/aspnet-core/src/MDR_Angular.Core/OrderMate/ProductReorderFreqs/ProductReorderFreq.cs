using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Products;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.ProductReorderFreqs
{
    public class ProductReorderFreq : FullAuditedEntity<int>
    {
        //public int ProductReorderFreqId { get; set; }
        public string ProductReorderFreq1 { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
