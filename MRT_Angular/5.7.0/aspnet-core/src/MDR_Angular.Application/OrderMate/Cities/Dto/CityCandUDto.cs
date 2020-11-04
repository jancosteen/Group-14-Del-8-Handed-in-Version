using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Cities.Dto
{
    [AutoMapFrom(typeof(City))]
    [AutoMapTo(typeof(City))]
    public class CityCandUDto : EntityDto<int>
    {
        public string CityName { get; set; }
        public int ProvinceIdFk { get; set; }


    }
}
