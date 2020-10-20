using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.AdvertisementDates.Dto
{
    [AutoMapFrom(typeof(AdvertisementDate))]
    [AutoMapTo(typeof(AdvertisementDate))]
    public class AdvertisementDateDto : FullAuditedEntityDto<int>
    {
        public DateTime AdvertisementDateAcvtiveFrom { get; set; }
        public DateTime AdvertisementDateActiveTo { get; set; }

    }
}
