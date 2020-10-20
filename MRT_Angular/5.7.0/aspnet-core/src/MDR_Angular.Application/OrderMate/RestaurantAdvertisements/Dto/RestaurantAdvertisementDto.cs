using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.RestaurantAdvertisements
{
    [AutoMapFrom(typeof(RestaurantAdvertisement))]
    [AutoMapTo(typeof(RestaurantAdvertisement))]
    public class RestaurantAdvertisementDto : FullAuditedEntityDto<int>
    {
        //public int RestaurantAdvertisesementId { get; set; }
        public int RestaurantIdFk { get; set; }
        public int AdvertisementIdFk { get; set; }


    }
}
