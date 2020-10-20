using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Employees;
using MDR_Angular.OrderMate.Shifts;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.EmployeeShifts
{
    public class EmployeeShift : FullAuditedEntity<int>
    {
        //public int EmployeeShiftId { get; set; }
        public int ShiftIdFk { get; set; }
        public int EmployeeIdFk { get; set; }

        [ForeignKey("EmployeeIdFk")]
        public virtual Employee EmployeeIdFkNavigation { get; set; }
        [ForeignKey("ShiftIdFk")]
        public virtual Shift ShiftIdFkNavigation { get; set; }
    }
}
