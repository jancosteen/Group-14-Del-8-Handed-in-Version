using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.SocialMediaTypes
{
    [AutoMapFrom(typeof(SocialMediaType))]
    [AutoMapTo(typeof(SocialMediaType))]
    public class SocialMediaTypeDto : FullAuditedEntityDto<int>
    {
        //public int SocialMediaTypeId { get; set; }
        public string SocialMediaType1 { get; set; }

    }
}
