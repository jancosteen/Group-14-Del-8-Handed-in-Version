using Abp.Domain.Repositories;
using MDR_Angular.OrderMate.Reports.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDR_Angular.OrderMate.Reports.Repository
{
    public interface IReportRepository1 : IRepository<TotalSalesByMenuItemReport, int>
    {
        Task<List<TotalSalesByMenuItemReportDto>> GetTotSBMI(int miId, DateTime dateFrom, DateTime dateTo);

    }
}
