using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MDR_Angular.OrderMate.Countries.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDR_Angular.OrderMate.Countries
{
    public class CountryAppService : AsyncCrudAppService<
       Country, CountryDto, int, PagedAndSortedResultRequestDto, CountryDto>, ICountryAppService
    {
        public CountryAppService(IRepository<Country> repository) : base(repository) { }

        public ListResultDto<CountryDto> GetCountryById(int id)
        {
            var menuItem = Repository
                .GetAll()
                .Include(i => i.Provinces).ThenInclude(x => x.Cities)
                .Where(x => x.Id == id)
                .ToList();

            return new ListResultDto<CountryDto>(ObjectMapper.Map<List<CountryDto>>(menuItem));

        }



        protected override IQueryable<Country> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .Include(i => i.Provinces).ThenInclude(x => x.Cities);
                
        }
    }
}
