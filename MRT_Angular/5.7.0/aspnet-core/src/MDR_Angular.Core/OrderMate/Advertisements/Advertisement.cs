using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.AdvertisementDates;
using MDR_Angular.OrderMate.AdvertisementPrices;
using MDR_Angular.OrderMate.RestaurantAdvertisements;
using MDR_Angular.OrderMate.Restaurants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.Advertisements
{
    public class Advertisement : FullAuditedEntity<int>
    {
        //public int AdvertisementId { get; set; }
        public string AdvertisementName { get; set; }
        public string AdvertisementDescription { get; set; }
        public byte[] AdvertisementFile { get; set; }
        public float AdvertisementPrice { get; set; }
        public int RestaurantIdFK { get; set; }

        public DateTime AdvertisementDateAcvtiveFrom { get; set; }
        public DateTime AdvertisementDateActiveTo { get; set; }
        //public int? AdvertisementPriceIdFk { get; set; }

        [ForeignKey("RestaurantIdFK")]
        public virtual Restaurant RestaurantIdFKFkNavigation { get; set; }
        //[ForeignKey("AdvertisementPriceIdFk")]
        //public virtual AdvertisementPrice AdvertisementPriceIdFkNavigation { get; set; }
        //public virtual ICollection<RestaurantAdvertisement> RestaurantAdvertisement { get; set; }
    }
}
