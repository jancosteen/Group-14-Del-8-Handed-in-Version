using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Countries.Dto
{
    [AutoMapFrom(typeof(Country))]
    [AutoMapTo(typeof(Country))]
    public class CountryCandUDto : EntityDto<int>
    {
        public string CountryName { get; set; }

        
    }
}
