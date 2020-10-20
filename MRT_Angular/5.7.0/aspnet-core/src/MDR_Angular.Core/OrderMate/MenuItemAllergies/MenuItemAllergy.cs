using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Allergies;
using MDR_Angular.OrderMate.MenuItems;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.MenuItemAllergies
{
    public class MenuItemAllergy : FullAuditedEntity<int>
    {
        //public int MenuItemAllergyId { get; set; }
        public int MenuItemIdFk { get; set; }
        public int AllergyIdFk { get; set; }

        [ForeignKey("AllergyIdFk")]
        public virtual Allergy AllergyIdFkNavigation { get; set; }
        [ForeignKey("MenuItemIdFk")]
        public virtual MenuItem MenuItemIdFkNavigation { get; set; }
    }
}
