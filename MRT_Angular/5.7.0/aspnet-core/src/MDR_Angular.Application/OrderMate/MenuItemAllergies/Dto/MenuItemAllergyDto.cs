using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.Allergies.Dto;
using MDR_Angular.OrderMate.MenuItems.Dto;

namespace MDR_Angular.OrderMate.MenuItemAllergies.Dto
{
    [AutoMapFrom(typeof(MenuItemAllergy))]
    [AutoMapTo(typeof(MenuItemAllergy))]
    public class MenuItemAllergyDto : FullAuditedEntityDto<int>
    {
        public int MenuItemIdFk { get; set; }
        public int AllergyIdFk { get; set; }

        public virtual AllergyDto AllergyIdFkNavigation { get; set; }
        public virtual MenuItemDto MenuItemIdFkNavigation { get; set; }
    }
}
