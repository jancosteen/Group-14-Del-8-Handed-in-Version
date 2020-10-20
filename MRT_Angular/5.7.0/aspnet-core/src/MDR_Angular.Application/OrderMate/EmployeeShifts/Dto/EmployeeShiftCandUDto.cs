using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.EmployeeShifts.Dto
{
    [AutoMapFrom(typeof(EmployeeShift))]
    [AutoMapTo(typeof(EmployeeShift))]
    public class EmployeeShiftCandUDto
    {
        public int ShiftIdFk { get; set; }
        public int EmployeeIdFk { get; set; }
    }
}
