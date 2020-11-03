using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MDR_Angular.OrderMate.Countries.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Countries
{
    public class CountryAppService : AsyncCrudAppService<
       Country, CountryDto, int, PagedAndSortedResultRequestDto, CountryDto>, ICountryAppService
    {
        public CountryAppService(IRepository<Country> repository) : base(repository) { }
    }
}
