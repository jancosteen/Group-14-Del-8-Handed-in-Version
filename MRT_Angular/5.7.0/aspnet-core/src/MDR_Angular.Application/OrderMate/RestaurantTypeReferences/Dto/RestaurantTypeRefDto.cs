using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.RestaurantTypes;

namespace MDR_Angular.OrderMate.RestaurantTypeReferences
{
    [AutoMapFrom(typeof(RestaurantTypeRef))]
    [AutoMapTo(typeof(RestaurantTypeRef))]
    public class RestaurantTypeRefDto : FullAuditedEntityDto<int>
    {
        //public int RestaurantTypeRefId { get; set; }
        public int RestaurantTypeIdFk { get; set; }
        public int RestaurantIdFk { get; set; }

        //public virtual RestaurantDto RestaurantIdFkNavigation { get; set; }
        public virtual RestaurantTypeDto RestaurantTypeIdFkNavigation { get; set; }

    }
}
