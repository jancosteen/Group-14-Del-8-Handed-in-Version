using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.Provinces;
using MDR_Angular.OrderMate.Provinces.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Cities.Dto
{
    [AutoMapFrom(typeof(City))]
    [AutoMapTo(typeof(City))]
    public class CityDto: EntityDto<int>
    {
        public string CityName { get; set; }
        public int ProvinceIdFk { get; set; }

        public virtual ProvinceCandUDto ProvinceIdFkNavigation { get; set; }

    }
}
