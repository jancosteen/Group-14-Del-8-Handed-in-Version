using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.RestaurantTypes
{
    [AutoMapFrom(typeof(RestaurantType))]
    [AutoMapTo(typeof(RestaurantType))]
    public class RestaurantTypeDto : FullAuditedEntityDto<int>
    {
        //public int RestaurantTypeId { get; set; }
        public string RestaurantType1 { get; set; }

    }
}
