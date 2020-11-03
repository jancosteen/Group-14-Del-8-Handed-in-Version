using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.Restaurants
{
    [AutoMapFrom(typeof(Restaurant))]
    [AutoMapTo(typeof(Restaurant))]
    public class RestaurantCandUDto
    {
        //public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantUrl { get; set; }
        public string RestaurantDescription { get; set; }
        //public DateTime? RestaurantDateCreated { get; set; }
        public string RestaurantAddressLine1 { get; set; }
        public string ResaturantAddressLine2 { get; set; }
        public int CityIdFk { get; set; }
        public string RestaurantPostalCode { get; set; }
        public int ProvinceIdFk { get; set; }
        public int CountryIdFk { get; set; }
        public int? RestaurantStatusIdFk { get; set; }


    }
}
