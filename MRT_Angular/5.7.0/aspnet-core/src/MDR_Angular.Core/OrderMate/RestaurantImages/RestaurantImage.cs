using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Restaurants;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.RestaurantImages
{
    public class RestaurantImage : FullAuditedEntity<int>
    {
        // public int RestaurantImageId { get; set; }
        public string ImageDescription { get; set; }
        public byte[] ImageFile { get; set; }
        public int? RestaurantIdFk { get; set; }

        [ForeignKey("RestaurantIdFk")]
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
    }
}
