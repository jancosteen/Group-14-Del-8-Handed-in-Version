using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.StockTakes
{
    [AutoMapFrom(typeof(StockTake))]
    [AutoMapTo(typeof(StockTake))]
    public class StockTakeCandUDto
    {
        //public int StockTakeId { get; set; }
        public DateTime StockTakeDate { get; set; }

    }
}
