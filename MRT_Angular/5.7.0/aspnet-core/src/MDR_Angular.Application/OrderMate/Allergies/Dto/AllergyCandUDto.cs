using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.Allergies.Dto
{
    [AutoMapFrom(typeof(Allergy))]
    [AutoMapTo(typeof(Allergy))]
    public class AllergyCandUDto
    {
        public string Allergy1 { get; set; }

    }
}
