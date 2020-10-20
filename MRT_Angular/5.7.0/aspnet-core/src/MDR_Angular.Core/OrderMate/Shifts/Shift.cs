using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.EmployeeShifts;
using MDR_Angular.OrderMate.ShiftStatusses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.Shifts
{
    public class Shift : FullAuditedEntity<int>
    {
        //public int ShiftId { get; set; }
        public DateTime ShiftStartDateTime { get; set; }
        public DateTime ShiftEndDateTime { get; set; }
        public int ShiftCapacity { get; set; }
        public string ShiftName { get; set; }
        public int? ShiftStatusIdFk { get; set; }

        [ForeignKey("ShiftStatusIdFk")]
        public virtual ShiftStatus ShiftStatusIdFkNavigation { get; set; }
        public virtual ICollection<EmployeeShift> EmployeeShift { get; set; }
    }
}
