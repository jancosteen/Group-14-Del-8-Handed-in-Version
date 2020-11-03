using Abp.Application.Services;
using MDR_Angular.OrderMate.Provinces.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Provinces
{
    public interface IProvinceAppService: IAsyncCrudAppService<ProvinceDto>
    {
    }
}
