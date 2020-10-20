using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.MenuItemSpecials;
using MDR_Angular.OrderMate.OrderLines;
using MDR_Angular.OrderMate.SpecialPrices;
using System;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.Specials
{
    public class Special : FullAuditedEntity<int>
    {
        //public int SpecialId { get; set; }
        public DateTime SpecialStartDate { get; set; }
        public DateTime SpecialEndDate { get; set; }
        public string SpecialName { get; set; }
        public string SpecialDescription { get; set; }
        public Boolean isActive { get; set; }

        public virtual ICollection<MenuItemSpecial> MenuItemSpecial { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
        public virtual ICollection<SpecialPrice> SpecialPrice { get; set; }
    }
}
