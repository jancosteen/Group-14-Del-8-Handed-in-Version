using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.Restaurants;

namespace MDR_Angular.OrderMate.QrCodes
{
    [AutoMapFrom(typeof(QrCode))]
    [AutoMapTo(typeof(QrCode))]
    public class QrCodeDto : FullAuditedEntityDto<int>
    {
        //public int QrCodeId { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual RestaurantDto RestaurantIdFkNavigation { get; set; }

    }
}
