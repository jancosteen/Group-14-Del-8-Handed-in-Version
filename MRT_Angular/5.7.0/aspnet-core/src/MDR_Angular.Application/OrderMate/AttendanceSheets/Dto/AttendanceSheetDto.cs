using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.AttendanceSheets
{
    [AutoMapFrom(typeof(AttendanceSheet))]
    [AutoMapTo(typeof(AttendanceSheet))]
    public class AttendanceSheetDto : FullAuditedEntityDto<int>
    {
        public DateTime ClockInDateTime { get; set; }
        public DateTime ClockOutDateTime { get; set; }
        public int? EmployeeIdFk { get; set; }
    }
}
