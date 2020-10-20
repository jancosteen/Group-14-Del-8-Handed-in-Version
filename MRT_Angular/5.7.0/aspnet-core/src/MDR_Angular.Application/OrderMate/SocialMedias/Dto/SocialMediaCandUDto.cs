using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.SocialMedias
{
    [AutoMapFrom(typeof(SocialMedia))]
    [AutoMapTo(typeof(SocialMedia))]
    public class SocialMediaCandU
    {
        //public int SocialMediaId { get; set; }
        public int SocialMediaTypeIdFk { get; set; }
        public string SocialMediaAddress { get; set; }


    }
}
