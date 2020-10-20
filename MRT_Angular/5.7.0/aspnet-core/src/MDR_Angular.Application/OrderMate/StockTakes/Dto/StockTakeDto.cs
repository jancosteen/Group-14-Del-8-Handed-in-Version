using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.StockTakes
{
    [AutoMapFrom(typeof(StockTake))]
    [AutoMapTo(typeof(StockTake))]
    public class StockTakeDto : FullAuditedEntityDto<int>
    {
        //public int StockTakeId { get; set; }
        public DateTime StockTakeDate { get; set; }

    }
}
