using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.RestaurantFacilityRefs
{
    [AutoMapFrom(typeof(RestaurantFacilityRef))]
    [AutoMapTo(typeof(RestaurantFacilityRef))]
    public class RestaurantFacilityRefCandUDto: EntityDto<int>
    {
        //public int RestaurantFacilityRefId { get; set; }
        public int RestaurantFacilityIdFk { get; set; }
        public int RestaurantIdFk { get; set; }


    }
}
