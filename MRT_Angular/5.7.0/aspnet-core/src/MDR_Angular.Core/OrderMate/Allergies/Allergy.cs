using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.MenuItemAllergies;
using System.Collections.Generic;


namespace MDR_Angular.OrderMate.Allergies
{
    public class Allergy : FullAuditedEntity<int>
    {
        //public int AllergyId { get; set; }
        public string Allergy1 { get; set; }

        public virtual ICollection<MenuItemAllergy> MenuItemAllergy { get; set; }
    }
}
