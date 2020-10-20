using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Shifts;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.ShiftStatusses
{
    public class ShiftStatus : FullAuditedEntity<int>
    {
        //public int ShiftStatusId { get; set; }
        public string ShiftStatus1 { get; set; }

        public virtual ICollection<Shift> Shift { get; set; }
    }
}
