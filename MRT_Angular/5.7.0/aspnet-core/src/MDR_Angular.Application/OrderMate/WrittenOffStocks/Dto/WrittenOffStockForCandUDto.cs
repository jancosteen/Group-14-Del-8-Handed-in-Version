using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.WrittenOffStocks
{
    [AutoMapFrom(typeof(WrittenOffStock))]
    [AutoMapTo(typeof(WrittenOffStock))]
    public class WrittenOffStockCandUDto
    {
        //public int WrittenOfStockId { get; set; }
        public DateTime WrittenOfStockDate { get; set; }

    }
}
