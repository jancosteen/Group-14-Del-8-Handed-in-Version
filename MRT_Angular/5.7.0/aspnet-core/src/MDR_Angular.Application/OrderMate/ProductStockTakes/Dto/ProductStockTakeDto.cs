﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.ProductStockTakes
{
    [AutoMapFrom(typeof(ProductStockTake))]
    [AutoMapTo(typeof(ProductStockTake))]
    public class ProductStockTakeDto : FullAuditedEntityDto<int>
    {
        //public int ProductStockTakeId { get; set; }
        public int? EmployeeIdFk { get; set; }
        public int ProductIdFk { get; set; }
        public int ProductStockTakeQty { get; set; }
        public int StockTakeIdFk { get; set; }


    }
}
