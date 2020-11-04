using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.Cities.Dto;
using MDR_Angular.OrderMate.Countries.Dto;
using MDR_Angular.OrderMate.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Provinces.Dto
{
    [AutoMapFrom(typeof(Province))]
    [AutoMapTo(typeof(Province))]
    public class ProvinceDto: EntityDto<int>
    {
        public string ProvinceName { get; set; }
        public int CountryIdFk { get; set; }

        public ICollection<CityDto> Cities { get; set; }
        public ICollection<RestaurantCandUDto> Restaurants { get; set; }
        public virtual CountryDto CountryIdFkNavigation { get; set; }
    }
}
