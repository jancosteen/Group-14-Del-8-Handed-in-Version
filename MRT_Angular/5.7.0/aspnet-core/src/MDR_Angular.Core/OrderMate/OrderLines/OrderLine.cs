using Abp.Domain.Entities.Auditing;
using MDR_Angular.Authorization.Users;
using MDR_Angular.OrderMate.MenuItems;
using MDR_Angular.OrderMate.Orders;
using MDR_Angular.OrderMate.Specials;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.OrderLines
{
    public class OrderLine : FullAuditedEntity<int>
    {
        //public int OrderLineId { get; set; }
        public int ItemQty { get; set; }
        public string ItemComments { get; set; }
        public int? SpecialIdFk { get; set; }
        public int? MenuItemIdFk { get; set; }
        public int? OrderIdFk { get; set; }
        public long UserIdFk { get; set; }

        [ForeignKey("MenuItemIdFk")]
        public virtual MenuItem MenuItemIdFkNavigation { get; set; }
        [ForeignKey("OrderIdFk")]
        public virtual Order OrderIdFkNavigation { get; set; }
        [ForeignKey("SpecialIdFk")]
        public virtual Special SpecialIdFkNavigation { get; set; }
        [ForeignKey("UserIdFk")]
        public virtual User UserIdFkNavigation { get; set; }
    }
}

