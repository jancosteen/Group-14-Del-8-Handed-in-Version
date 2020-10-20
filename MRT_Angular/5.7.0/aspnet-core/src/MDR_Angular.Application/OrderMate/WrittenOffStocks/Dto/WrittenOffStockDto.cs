using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.WrittenOffStocks
{
    [AutoMapFrom(typeof(WrittenOffStock))]
    [AutoMapTo(typeof(WrittenOffStock))]
    public class WrittenOffStockDto : FullAuditedEntityDto<int>
    {
        //public int WrittenOfStockId { get; set; }
        public DateTime WrittenOfStockDate { get; set; }

    }
}
