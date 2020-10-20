using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.AdvertisementDates.Dto;
using MDR_Angular.OrderMate.AdvertisementPrices.Dto;

namespace MDR_Angular.OrderMate.Advertisements.Dto
{
    [AutoMapFrom(typeof(Advertisement))]
    [AutoMapTo(typeof(Advertisement))]
    public class AdvertisementDto : FullAuditedEntityDto<int>
    {
        public string AdvertisementName { get; set; }
        public string AdvertisementDescription { get; set; }
        public byte[] AdvertisementFile { get; set; }

        public int? AdvertisementDateIdFk { get; set; }
        public int? AdvertisementPriceIdFk { get; set; }

        public virtual AdvertisementDateDto AdvertisementDateIdFkNavigation { get; set; }
        public virtual AdvertisementPriceDto AdvertisementPriceIdFkNavigation { get; set; }

    }
}
