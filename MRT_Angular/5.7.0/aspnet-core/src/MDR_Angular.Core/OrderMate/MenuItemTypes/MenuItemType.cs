using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.ItemTypeMenuMenuItems;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.MenuItemTypes
{
    public class MenuItemType : FullAuditedEntity<int>
    {
        //public int MenuItemTypeId { get; set; }
        public string MenuItemType1 { get; set; }

        public virtual ICollection<ItemTypeMenuItem> ItemTypeMenuItem { get; set; }
    }
}
