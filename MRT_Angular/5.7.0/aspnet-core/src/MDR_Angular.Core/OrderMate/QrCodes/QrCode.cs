using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.QrCodeSeatings;
using MDR_Angular.OrderMate.Restaurants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.QrCodes
{
    public class QrCode : FullAuditedEntity<int>
    {
        //public int QrCodeId { get; set; }
        public int? RestaurantIdFk { get; set; }

        [ForeignKey("RestaurantIdFk")]
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        public virtual ICollection<QrCodeSeating> QrCodeSeating { get; set; }
    }
}
