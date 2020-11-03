using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.Provinces.Dto;
using MDR_Angular.OrderMate.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Countries.Dto
{
    [AutoMapFrom(typeof(Country))]
    [AutoMapTo(typeof(Country))]
    public class CountryDto: EntityDto<int>
    {
        public string CountryName { get; set; }

        public ICollection<ProvinceDto> Provinces { get; set; }
        //public ICollection<RestaurantDto> Restaurants { get; set; }
    }
}
