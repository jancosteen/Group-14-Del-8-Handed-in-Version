using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MDR_Angular.OrderMate.Provinces.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDR_Angular.OrderMate.Provinces
{
    public class ProvinceAppService : AsyncCrudAppService<
        Province, ProvinceDto, int, PagedAndSortedResultRequestDto, ProvinceDto>, IProvinceAppService
    {
        public ProvinceAppService(IRepository<Province> repository) : base(repository) { }

        public ListResultDto<ProvinceDto> GetProvinceById(int id)
        {
            var menuItem = Repository
                .GetAll()
                .Include(i => i.Cities)
                .Include(i => i.CountryIdFkNavigation)
                .Where(x => x.Id == id)
                .ToList();

            return new ListResultDto<ProvinceDto>(ObjectMapper.Map<List<ProvinceDto>>(menuItem));

        }



        protected override IQueryable<Province> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .Include(i => i.CountryIdFkNavigation)
                .Include(i => i.Cities);

        }
    }
}
