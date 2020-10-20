using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Restaurants;
using MDR_Angular.OrderMate.StarRatings;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.UserComments
{
    public class UserComment : FullAuditedEntity<int>
    {
        // public int UserCommentId { get; set; }
        public string UserComment1 { get; set; }
        public DateTime UserCommentDateCreated { get; set; }
        public int? RestaurantIdFk { get; set; }
        public int? StarRatingIdFk { get; set; }

        [ForeignKey("RestaurantIdFk")]
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        [ForeignKey("StarRatingIdFk")]
        public virtual StarRating StarRatingIdFkNavigation { get; set; }
    }
}
