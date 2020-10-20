using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.UserComments
{
    [AutoMapFrom(typeof(UserComment))]
    [AutoMapTo(typeof(UserComment))]
    public class UserCommentDto : FullAuditedEntityDto<int>
    {
        // public int UserCommentId { get; set; }
        public string UserComment1 { get; set; }
        public DateTime UserCommentDateCreated { get; set; }
        public int? RestaurantIdFk { get; set; }
        public int? StarRatingIdFk { get; set; }


    }
}
