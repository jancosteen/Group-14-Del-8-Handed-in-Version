using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.SocialMediaTypes
{
    [AutoMapFrom(typeof(SocialMediaType))]
    [AutoMapTo(typeof(SocialMediaType))]
    public class SocialMediaTypeCandUDto
    {
        //public int SocialMediaTypeId { get; set; }
        public string SocialMediaType1 { get; set; }

    }
}
