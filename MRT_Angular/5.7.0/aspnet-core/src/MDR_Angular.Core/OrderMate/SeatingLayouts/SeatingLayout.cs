using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.LayoutTypes;
using MDR_Angular.OrderMate.Restaurants;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.SeatingLayouts
{
    public class SeatingLayout : FullAuditedEntity<int>
    {
        //public int SeatingLayoutId { get; set; }
        public int RestaurantIdFk { get; set; }
        public int LayoutTypeIdFk { get; set; }
        public string SeatingLayoutQty { get; set; }

        [ForeignKey("LayoutTypeIdFk")]
        public virtual LayoutType LayoutTypeIdFkNavigation { get; set; }
        [ForeignKey("RestaurantIdFk")]
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
    }
}
