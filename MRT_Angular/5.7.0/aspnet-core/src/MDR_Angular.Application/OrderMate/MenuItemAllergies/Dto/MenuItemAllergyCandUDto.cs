using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.MenuItemAllergies.Dto
{
    [AutoMapFrom(typeof(MenuItemAllergy))]
    [AutoMapTo(typeof(MenuItemAllergy))]
    public class MenuItemAllergyCandUDto
    {
        public int MenuItemIdFk { get; set; }
        public int AllergyIdFk { get; set; }
    }
}
