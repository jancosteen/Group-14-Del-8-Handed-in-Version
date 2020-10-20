using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.RestaurantRestaurantImages
{
    [AutoMapFrom(typeof(RestaurantRestaurantImage))]
    [AutoMapTo(typeof(RestaurantRestaurantImage))]
    public class RestaurantRestaurantImageDto : FullAuditedEntityDto<int>
    {
        public int RestaurantIdFk { get; set; }
        public int RestaurantImageIdFk { get; set; }
        //public int RestaurantRestaurantImageId { get; set; }


    }
}
