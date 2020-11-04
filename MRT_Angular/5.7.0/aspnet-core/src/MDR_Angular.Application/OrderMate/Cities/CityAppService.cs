using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MDR_Angular.OrderMate.Cities.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDR_Angular.OrderMate.Cities
{
    public class CityAppService : AsyncCrudAppService<
        City, CityDto, int, PagedAndSortedResultRequestDto, CityDto>, ICityAppService
    {
        public CityAppService(IRepository<City> repository) : base(repository) { }

        public ListResultDto<CityDto> GetCityById(int id)
        {
            var menuItem = Repository
                .GetAll()
                .Include(i => i.ProvinceIdFkNavigation)
                .Include(i => i.ProvinceIdFkNavigation).ThenInclude(x => x.CountryIdFkNavigation)
                .Where(x => x.Id == id)
                .ToList();

            return new ListResultDto<CityDto>(ObjectMapper.Map<List<CityDto>>(menuItem));
        }



        protected override IQueryable<City> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .Include(i => i.ProvinceIdFkNavigation)
                .Include(i => i.ProvinceIdFkNavigation).ThenInclude(x => x.CountryIdFkNavigation);
        }
    }
}
