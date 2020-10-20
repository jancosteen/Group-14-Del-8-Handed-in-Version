using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.MenuItems;
using MDR_Angular.OrderMate.MenuItemTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.ItemTypeMenuMenuItems
{
    public class ItemTypeMenuItem : FullAuditedEntity<int>
    {
        //public int ItemTypeMenuItemId { get; set; }
        public int MenuItemIdFk { get; set; }
        public int MenuItemTypeIdFk { get; set; }

        [ForeignKey("MenuItemIdFk")]
        public virtual MenuItem MenuItemIdFkNavigation { get; set; }
        [ForeignKey("MenuItemTypeIdFk")]
        public virtual MenuItemType MenuItemTypeIdFkNavigation { get; set; }
    }
}
