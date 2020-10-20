using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.MenuItems;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.MenuItemCategories
{
    public class MenuItemCategory : FullAuditedEntity<int>
    {
        //public int MenuItemCategoryId { get; set; }
        public string MenuItemCategory1 { get; set; }

        public virtual ICollection<MenuItem> MenuItem { get; set; }
    }
}
