using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Restaurants;
using MDR_Angular.OrderMate.RestaurantTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.RestaurantTypeReferences
{
    public class RestaurantTypeRef : FullAuditedEntity<int>
    {
        //public int RestaurantTypeRefId { get; set; }
        public int RestaurantTypeIdFk { get; set; }
        public int RestaurantIdFk { get; set; }

        [ForeignKey("RestaurantIdFk")]
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        [ForeignKey("RestaurantTypeIdFk")]
        public virtual RestaurantType RestaurantTypeIdFkNavigation { get; set; }
    }
}
