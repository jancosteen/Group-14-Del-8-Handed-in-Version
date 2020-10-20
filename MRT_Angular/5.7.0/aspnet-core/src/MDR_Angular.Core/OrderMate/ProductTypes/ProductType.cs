using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Products;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.ProductTypes
{
    public class ProductType : FullAuditedEntity<int>
    {
        //public int ProductTypeId { get; set; }
        public string ProductType1 { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
