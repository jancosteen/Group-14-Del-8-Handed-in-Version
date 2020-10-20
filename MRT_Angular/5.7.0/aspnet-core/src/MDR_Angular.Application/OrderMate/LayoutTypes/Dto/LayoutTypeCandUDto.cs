using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.LayoutTypes.Dto
{
    [AutoMapFrom(typeof(LayoutType))]
    [AutoMapTo(typeof(LayoutType))]
    public class LayoutTypeCandUDto
    {
        public string LayoutType1 { get; set; }

    }
}
