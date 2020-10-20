using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.RestaurantFacilityRefs;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.RestaurantFacilities
{
    public class RestaurantFacility : FullAuditedEntity<int>
    {
        //public int RestaurantFacilityId { get; set; }
        public string RestaurantFacility1 { get; set; }

        public virtual ICollection<RestaurantFacilityRef> ResaurantFacilityRef { get; set; }
    }
}
