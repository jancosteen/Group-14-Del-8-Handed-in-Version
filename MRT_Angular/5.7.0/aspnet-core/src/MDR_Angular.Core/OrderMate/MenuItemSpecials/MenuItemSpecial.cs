using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.MenuItems;
using MDR_Angular.OrderMate.Specials;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.MenuItemSpecials
{
    public class MenuItemSpecial : FullAuditedEntity<int>
    {
        //public int MenuItemSpecialId { get; set; }
        public int SpecialIdFk { get; set; }
        public int MenuItemIdFk { get; set; }

        [ForeignKey("MenuItemIdFk")]
        public virtual MenuItem MenuItemIdFkNavigation { get; set; }
        [ForeignKey("SpecialIdFk")]
        public virtual Special SpecialIdFkNavigation { get; set; }
    }
}
