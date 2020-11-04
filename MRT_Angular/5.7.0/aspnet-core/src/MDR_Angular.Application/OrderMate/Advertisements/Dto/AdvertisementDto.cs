using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.AdvertisementDates.Dto;
using MDR_Angular.OrderMate.AdvertisementPrices.Dto;
using MDR_Angular.OrderMate.Restaurants;
using System;

namespace MDR_Angular.OrderMate.Advertisements.Dto
{
    [AutoMapFrom(typeof(Advertisement))]
    [AutoMapTo(typeof(Advertisement))]
    public class AdvertisementDto : FullAuditedEntityDto<int>
    {
        public string AdvertisementName { get; set; }
        public string AdvertisementDescription { get; set; }
        public byte[] AdvertisementFile { get; set; }
        

        public DateTime AdvertisementDateAcvtiveFrom { get; set; }
        public DateTime AdvertisementDateActiveTo { get; set; }
        public int RestaurantIdFK { get; set; }

        public virtual RestaurantCandUDto RestaurantIdFKFkNavigation { get; set; }

        //public virtual AdvertisementDateDto AdvertisementDateIdFkNavigation { get; set; }
        //public virtual AdvertisementPriceDto AdvertisementPriceIdFkNavigation { get; set; }

    }
}
