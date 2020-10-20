using Abp.Application.Services;
using MDR_Angular.OrderMate.Reports.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.Reports
{
    public interface ITotalSalesByMenuItemReportAppService: IAsyncCrudAppService<TotalSalesByMenuItemReportDto>
    {
    }
}
