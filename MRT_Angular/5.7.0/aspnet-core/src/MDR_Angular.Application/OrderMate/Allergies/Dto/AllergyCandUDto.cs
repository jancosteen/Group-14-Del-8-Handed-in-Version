using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.MenuItemAllergies.Dto;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.Allergies.Dto
{
    [AutoMapFrom(typeof(Allergy))]
    [AutoMapTo(typeof(Allergy))]
    public class AllergyCandUDto: EntityDto<int>
    {
        public string Allergy1 { get; set; }

        public virtual ICollection<MenuItemAllergyDto> MenuItemAllergy { get; set; }

    }
}
