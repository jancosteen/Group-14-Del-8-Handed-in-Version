using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.ItemTypeMenuMenuItems;
using MDR_Angular.OrderMate.MenuItemAllergies;
using MDR_Angular.OrderMate.MenuItemCategories;
using MDR_Angular.OrderMate.MenuItemPrices;
using MDR_Angular.OrderMate.MenuItemSpecials;
using MDR_Angular.OrderMate.MenuRestaurants;
using MDR_Angular.OrderMate.Menus;
using MDR_Angular.OrderMate.OrderLines;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.MenuItems
{
    public class MenuItem : FullAuditedEntity<int>
    {
        //public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public int? MenuItemCategoryIdFk { get; set; }
        public int? MenuItemPriceIdFk { get; set; }
        public int? MenuIdFk { get; set; }

        [ForeignKey("MenuItemCategoryIdFk")]
        public virtual MenuItemCategory MenuItemCategoryIdFkNavigation { get; set; }
        [ForeignKey("MenuItemPriceIdFk")]
        public virtual MenuItemPrice MenuItemPriceIdFkNavigation { get; set; }
        public virtual ICollection<ItemTypeMenuItem> ItemTypeMenuMenuItem { get; set; }
        public virtual ICollection<MenuItemAllergy> MenuItemAllergy { get; set; }
        public virtual ICollection<MenuItemSpecial> MenuItemSpecial { get; set; }
        [ForeignKey("MenuIdFk")]
        public virtual Menu MenuIdFkNavigation { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
