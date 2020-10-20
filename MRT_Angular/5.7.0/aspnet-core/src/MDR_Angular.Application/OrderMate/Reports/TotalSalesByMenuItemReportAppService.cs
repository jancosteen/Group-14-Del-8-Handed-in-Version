using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MDR_Angular.OrderMate.Reports.Dto;
using MDR_Angular.OrderMate.Reports.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDR_Angular.OrderMate.Reports
{
    public class TotalSalesByMenuItemReportAppService : AsyncCrudAppService<
   TotalSalesByMenuItemReport, TotalSalesByMenuItemReportDto, int, PagedAndSortedResultRequestDto, TotalSalesByMenuItemReportDto
   >, ITotalSalesByMenuItemReportAppService
    {
        private readonly IReportRepository1 _repository;
        public TotalSalesByMenuItemReportAppService(IReportRepository1 repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<TotalSalesByMenuItemReportDto>> GetReport2(int miId, DateTime dateFrom, DateTime dateTo)
        {
            var results = _repository.GetTotSBMI(miId, dateFrom, dateTo);
            return await results;
        }
    }
}
