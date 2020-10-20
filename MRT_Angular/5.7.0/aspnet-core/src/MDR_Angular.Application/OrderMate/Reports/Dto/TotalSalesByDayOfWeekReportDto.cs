using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Reports.Dto
{
    [AutoMapFrom(typeof(TotalSalesByDayOfWeekReport))]
    [AutoMapTo(typeof(TotalSalesByDayOfWeekReport))]
    public class TotalSalesByDayOfWeekReportDto: EntityDto<int>
    {
        public int Sunday { get; set; }
        public int Monday { get; set; }
        public int Tuesday { get; set; }
        public int Wednesday { get; set; }
        public int Thursday { get; set; }
        public int Friday { get; set; }
        public int Saturday { get; set; }
        public int TotalSales { get; set; }
        public double TotalAmount { get; set; }
    }
}
