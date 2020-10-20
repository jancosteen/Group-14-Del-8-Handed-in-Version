using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.AdvertisementPrices.Dto
{
    [AutoMapFrom(typeof(AdvertisementPrice))]
    [AutoMapTo(typeof(AdvertisementPrice))]
    public class AdvertisementPriceDto : FullAuditedEntityDto<int>
    {
        public double AdvertismentPrice { get; set; }
        public DateTime AdvertisementPriceDateUpdated { get; set; }
    }
}
