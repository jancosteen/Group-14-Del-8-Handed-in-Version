using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.StarRatings
{
    [AutoMapFrom(typeof(StarRating))]
    [AutoMapTo(typeof(StarRating))]
    public class StarRatingDto : FullAuditedEntityDto<int>
    {
        //public int StarRatingId { get; set; }
        public int StarRatingValue { get; set; }

    }
}
