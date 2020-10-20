using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Restaurants;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.RestaurantStatusses
{
    public class RestaurantStatus : FullAuditedEntity<int>
    {
        //public int RestaurantStatusId { get; set; }
        public string RestaurantStatus1 { get; set; }

        public virtual ICollection<Restaurant> Restaurant { get; set; }
    }
}
