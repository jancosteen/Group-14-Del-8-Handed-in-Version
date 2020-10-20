using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.RestaurantImages
{
    [AutoMapFrom(typeof(RestaurantImage))]
    [AutoMapTo(typeof(RestaurantImage))]
    public class RestaurantImageDto : FullAuditedEntityDto<int>
    {
        // public int RestaurantImageId { get; set; }
        public string ImageDescription { get; set; }
        public byte[] ImageFile { get; set; }
        public int? RestaurantIdFk { get; set; }


    }
}
