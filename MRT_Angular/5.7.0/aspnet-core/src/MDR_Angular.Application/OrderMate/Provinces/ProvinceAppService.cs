using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MDR_Angular.OrderMate.Provinces.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Provinces
{
    public class ProvinceAppService : AsyncCrudAppService<
        Province, ProvinceDto, int, PagedAndSortedResultRequestDto, ProvinceDto>, IProvinceAppService
    {
        public ProvinceAppService(IRepository<Province> repository) : base(repository) { }
    }
}
