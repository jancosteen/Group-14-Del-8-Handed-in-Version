using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.RestaurantFacilities;
using MDR_Angular.OrderMate.Restaurants;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.RestaurantFacilityRefs
{
    public class RestaurantFacilityRef : FullAuditedEntity<int>
    {
        //public int RestaurantFacilityRefId { get; set; }
        public int RestaurantFacilityIdFk { get; set; }
        public int RestaurantIdFk { get; set; }

        [ForeignKey("RestaurantFacilityIdFk")]
        public virtual RestaurantFacility RestaurantFacilityIdFkNavigation { get; set; }
        [ForeignKey("RestaurantIdFk")]
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
    }
}
