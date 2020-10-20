using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Restaurants;
using MDR_Angular.OrderMate.SocialMediaTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.SocialMedias
{
    public class SocialMedia : FullAuditedEntity<int>
    {
        //public int SocialMediaId { get; set; }
        public int SocialMediaTypeIdFk { get; set; }
        public string SocialMediaAddress { get; set; }
        
        public int RestaurantIdFk { get; set;}

        [ForeignKey("SocialMediaTypeIdFk")]
        public virtual SocialMediaType SocialMediaTypeIdFkNavigation { get; set; }
        [ForeignKey("RestaurantIdFk")]
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }


    }
}
