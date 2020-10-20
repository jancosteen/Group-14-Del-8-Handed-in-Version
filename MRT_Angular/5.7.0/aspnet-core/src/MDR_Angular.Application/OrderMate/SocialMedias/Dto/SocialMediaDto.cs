using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.Restaurants;
using MDR_Angular.OrderMate.SocialMediaTypes;

namespace MDR_Angular.OrderMate.SocialMedias
{
    [AutoMapFrom(typeof(SocialMedia))]
    [AutoMapTo(typeof(SocialMedia))]
    public class SocialMediaDto : FullAuditedEntityDto<int>
    {
        //public int SocialMediaId { get; set; }
        public int SocialMediaTypeIdFk { get; set; }
        public string SocialMediaAddress { get; set; }
        public int RestaurantIdFk { get; set; }

        public virtual SocialMediaTypeDto SocialMediaTypeIdFkNavigation { get; set; }
        public virtual RestaurantDto RestaurantIdFkNavigation { get; set; }


    }
}
