﻿using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.ProductsWrittenOff
{
    [AutoMapFrom(typeof(ProductWrittenOff))]
    [AutoMapTo(typeof(ProductWrittenOff))]
    public class ProductWrittenOffCandUDto
    {
        //public int WrittenOffStockIdFk { get; set; }
        public int ProductIdFk { get; set; }
        public int WrittenOffQty { get; set; }
        public int? EmployeeIdFk { get; set; }

    }
}
