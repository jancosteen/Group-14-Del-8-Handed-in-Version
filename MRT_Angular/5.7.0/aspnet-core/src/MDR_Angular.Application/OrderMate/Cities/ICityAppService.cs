using Abp.Application.Services;
using MDR_Angular.OrderMate.Cities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Cities
{
    public interface ICityAppService: IAsyncCrudAppService<CityDto>
    {
    }
}
