﻿using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.SupplierOrders
{
    [AutoMapFrom(typeof(SupplierOrder))]
    [AutoMapTo(typeof(SupplierOrder))]
    public class SupplierOrderCandUDto
    {
        //public int SupplierOrderId { get; set; }
        public DateTime SupplierOrderDate { get; set; }
        public int? SupplierIdFk { get; set; }


    }
}
