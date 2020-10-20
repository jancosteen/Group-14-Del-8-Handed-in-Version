using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.ProductStockTakes;
using System;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.StockTakes
{
    public class StockTake : FullAuditedEntity<int>
    {
        //public int StockTakeId { get; set; }
        public DateTime StockTakeDate { get; set; }

        public virtual ICollection<ProductStockTake> ProductStockTake { get; set; }
    }
}
