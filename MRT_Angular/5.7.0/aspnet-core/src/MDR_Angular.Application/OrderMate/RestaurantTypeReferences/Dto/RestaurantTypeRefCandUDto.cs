using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.RestaurantTypeReferences
{
    [AutoMapFrom(typeof(RestaurantTypeRef))]
    [AutoMapTo(typeof(RestaurantTypeRef))]
    public class RestaurantTypeRefCandUDto: EntityDto<int>
    {
        //public int RestaurantTypeRefId { get; set; }
        public int RestaurantTypeIdFk { get; set; }
        public int RestaurantIdFk { get; set; }


    }
}
