using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.Cities.Dto;
using MDR_Angular.OrderMate.Countries.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Provinces.Dto
{
    [AutoMapFrom(typeof(Province))]
    [AutoMapTo(typeof(Province))]
    public class ProvinceCandUDto : EntityDto<int>
    {
        public string ProvinceName { get; set; }
        public int CountryIdFk { get; set; }

        public ICollection<CityCandUDto> Cities { get; set; }
        //public ICollection<RestaurantDto> Restaurants { get; set; }
        public virtual CountryCandUDto CountryIdFkNavigation { get; set; }
    }
}
