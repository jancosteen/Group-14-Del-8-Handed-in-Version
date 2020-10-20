using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MDR_Angular.OrderMate.Reports.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDR_Angular.OrderMate.Reports.Repository
{
    public interface IReportRepository: IRepository<TotalSalesByDayOfWeekReport,int>
    {
        Task<List<TotalSalesByDayOfWeekReportDto>> GetTotSDOW(int resId, DateTime dateFrom, DateTime dateTo);
    }
}
