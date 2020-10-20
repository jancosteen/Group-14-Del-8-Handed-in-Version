using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Advertisements;
using MDR_Angular.OrderMate.Restaurants;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.RestaurantAdvertisements
{
    public class RestaurantAdvertisement : FullAuditedEntity<int>
    {
        //public int RestaurantAdvertisesementId { get; set; }
        public int RestaurantIdFk { get; set; }
        public int AdvertisementIdFk { get; set; }

        //[ForeignKey("AdvertisementIdFk")]
        //public virtual Advertisement AdvertisementIdFkNavigation { get; set; }
        //[ForeignKey("RestaurantIdFk")]
        //public virtual Restaurant RestaurantIdFkNavigation { get; set; }
    }
}
