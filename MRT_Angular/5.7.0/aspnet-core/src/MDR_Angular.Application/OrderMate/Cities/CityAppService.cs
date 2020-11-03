using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MDR_Angular.OrderMate.Cities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Cities
{
    public class CityAppService : AsyncCrudAppService<
        City, CityDto, int, PagedAndSortedResultRequestDto, CityDto>, ICityAppService
    {
        public CityAppService(IRepository<City> repository) : base(repository) { }
    }
}
