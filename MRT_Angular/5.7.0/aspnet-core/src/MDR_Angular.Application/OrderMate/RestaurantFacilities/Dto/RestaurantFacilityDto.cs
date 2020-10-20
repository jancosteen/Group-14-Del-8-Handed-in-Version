using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.RestaurantFacilities
{
    [AutoMapFrom(typeof(RestaurantFacility))]
    [AutoMapTo(typeof(RestaurantFacility))]
    public class RestaurantFacilityDto : FullAuditedEntityDto<int>
    {
        //public int RestaurantFacilityId { get; set; }
        public string RestaurantFacility1 { get; set; }

    }
}
