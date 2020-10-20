using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.Advertisements;
using System;
using System.Collections.Generic;


namespace MDR_Angular.OrderMate.AdvertisementDates
{
    public class AdvertisementDate : FullAuditedEntity<int>
    {
        //public int AdvertisementDateId { get; set; }
        public DateTime AdvertisementDateAcvtiveFrom { get; set; }
        public DateTime AdvertisementDateActiveTo { get; set; }

        public virtual ICollection<Advertisement> Advertisement { get; set; }
    }
}
