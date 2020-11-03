using Abp.Application.Services;
using MDR_Angular.OrderMate.Countries.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Countries
{
    public interface ICountryAppService: IAsyncCrudAppService<CountryDto>
    {
    }
}
