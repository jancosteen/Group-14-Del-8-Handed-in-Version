using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Reports.Dto
{
    [AutoMapFrom(typeof(TotalSalesByMenuItemReport))]
    [AutoMapTo(typeof(TotalSalesByMenuItemReport))]
    public class TotalSalesByMenuItemReportDto:EntityDto<int>
    {
        public string MenuIteMane { get; set; }
        public double MenuItemPrice1 { get; set; }
        public double TotalSalesAmount { get; set; }
    }
}
