using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MDR_Angular.EntityFrameworkCore;
using MDR_Angular.OrderMate.Reports.Dto;
using MDR_Angular.OrderMate.Reports.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDR_Angular.OrderMate.Reports
{
    public class TotalSalesByDayOfWeekReportAppService : AsyncCrudAppService<
    TotalSalesByDayOfWeekReport, TotalSalesByDayOfWeekReportDto, int, PagedAndSortedResultRequestDto, TotalSalesByDayOfWeekReportDto
    >, ITotalSalesByDayOfWeekReportAppService
    {
        private readonly IReportRepository _repository;
        public TotalSalesByDayOfWeekReportAppService(IReportRepository repository) : base(repository) 
        {
            _repository = repository;
        }

        public async Task<List<TotalSalesByDayOfWeekReportDto>> GetReport1(int resId, DateTime dateFrom, DateTime dateTo)
        {
            var results = _repository.GetTotSDOW(resId, dateFrom, dateTo);
            return await results;
        }
    }
}
