using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.RestaurantStatusses
{
    [AutoMapFrom(typeof(RestaurantStatus))]
    [AutoMapTo(typeof(RestaurantStatus))]
    public class RestaurantStatusCandUDto: EntityDto<int>
    {
        //public int RestaurantStatusId { get; set; }
        public string RestaurantStatus1 { get; set; }

    }
}
