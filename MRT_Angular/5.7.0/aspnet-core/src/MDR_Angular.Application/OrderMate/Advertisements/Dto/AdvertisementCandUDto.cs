using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.Advertisements.Dto
{
    [AutoMapFrom(typeof(Advertisement))]
    [AutoMapTo(typeof(Advertisement))]
    public class AdvertisementCandUDto
    {
        public string AdvertisementName { get; set; }
        public string AdvertisementDescription { get; set; }
        public byte[] AdvertisementFile { get; set; }

        public int? AdvertisementDateIdFk { get; set; }
        public int? AdvertisementPriceIdFk { get; set; }
    }
}
