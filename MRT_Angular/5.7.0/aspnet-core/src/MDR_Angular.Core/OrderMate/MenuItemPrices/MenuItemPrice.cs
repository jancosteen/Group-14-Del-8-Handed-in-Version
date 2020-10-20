using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.MenuItems;
using System;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.MenuItemPrices
{
    public class MenuItemPrice : FullAuditedEntity<int>
    {
        //public int MenuItemPriceId { get; set; }
        public double MenuItemPrice1 { get; set; }
        public DateTime MenuItemDateUpdated { get; set; }
        public Boolean isActive { get; set; }

        public virtual ICollection<MenuItem> MenuItem { get; set; }
    }
}
