using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.AdvertisementDates.Dto
{
    [AutoMapFrom(typeof(AdvertisementDate))]
    [AutoMapTo(typeof(AdvertisementDate))]
    public class AdvertisementDateCandUDto
    {
        public DateTime AdvertisementDateAcvtiveFrom { get; set; }
        public DateTime AdvertisementDateActiveTo { get; set; }
    }
}
