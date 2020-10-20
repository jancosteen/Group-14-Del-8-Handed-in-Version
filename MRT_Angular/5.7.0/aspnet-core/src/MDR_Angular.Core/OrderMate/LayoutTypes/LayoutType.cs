using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.SeatingLayouts;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.LayoutTypes
{
    public class LayoutType : FullAuditedEntity<int>
    {
        //public int LayoutTypeId { get; set; }
        public string LayoutType1 { get; set; }

        public virtual ICollection<SeatingLayout> SeatingLayout { get; set; }
    }
}
