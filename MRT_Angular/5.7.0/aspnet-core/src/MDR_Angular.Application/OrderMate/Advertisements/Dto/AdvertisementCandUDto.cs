using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.Advertisements.Dto
{
    [AutoMapFrom(typeof(Advertisement))]
    [AutoMapTo(typeof(Advertisement))]
    public class AdvertisementCandUDto:EntityDto<int>
    {
        public string AdvertisementName { get; set; }
        public string AdvertisementDescription { get; set; }
        public byte[] AdvertisementFile { get; set; }


        public DateTime AdvertisementDateAcvtiveFrom { get; set; }
        public DateTime AdvertisementDateActiveTo { get; set; }
        public int RestaurantIdFK { get; set; }
    }
}
