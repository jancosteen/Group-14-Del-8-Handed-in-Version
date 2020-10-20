using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.ProductsWrittenOff;
using System;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.WrittenOffStocks
{
    public class WrittenOffStock : FullAuditedEntity<int>
    {
        //public int WrittenOfStockId { get; set; }
        public DateTime WrittenOfStockDate { get; set; }

        public virtual ICollection<ProductWrittenOff> ProductWrittenOff { get; set; }
    }
}
