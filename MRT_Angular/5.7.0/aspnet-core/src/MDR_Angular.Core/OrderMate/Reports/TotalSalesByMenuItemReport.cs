using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Reports
{
    public class TotalSalesByMenuItemReport: Entity<int>
    {
        public string MenuIteMane { get; set; }
        public double MenuItemPrice1 { get; set; }
        public double TotalSalesAmount { get; set; }
    }
}
