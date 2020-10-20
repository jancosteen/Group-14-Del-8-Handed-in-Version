using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.EmployeeShifts.Dto
{
    [AutoMapFrom(typeof(EmployeeShift))]
    [AutoMapTo(typeof(EmployeeShift))]
    public class EmployeeShiftDto : FullAuditedEntityDto<int>
    {
        public int ShiftIdFk { get; set; }
        public int EmployeeIdFk { get; set; }
    }
}
