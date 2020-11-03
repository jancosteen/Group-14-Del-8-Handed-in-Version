using Abp.Application.Services.Dto;
using Abp.AutoMapper;
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
    }
}
