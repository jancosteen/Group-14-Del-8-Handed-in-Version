using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.RestaurantTypes
{
    [AutoMapFrom(typeof(RestaurantType))]
    [AutoMapTo(typeof(RestaurantType))]
    public class RestaurantTypeCandUDto
    {
        //public int RestaurantTypeId { get; set; }
        public string RestaurantType1 { get; set; }

    }
}
