using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.RestaurantImages
{
    [AutoMapFrom(typeof(RestaurantImage))]
    [AutoMapTo(typeof(RestaurantImage))]
    public class RestaurantImageCandUDto
    {
        // public int RestaurantImageId { get; set; }
        public string ImageDescription { get; set; }
        public byte[] ImageFile { get; set; }
        public int? RestaurantIdFk { get; set; }


    }
}
