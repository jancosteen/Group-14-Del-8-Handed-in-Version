using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.Allergies.Dto
{
    [AutoMapFrom(typeof(Allergy))]
    [AutoMapTo(typeof(Allergy))]
    public class AllergyDto : FullAuditedEntityDto<int>
    {
        public string Allergy1 { get; set; }

    }
}
