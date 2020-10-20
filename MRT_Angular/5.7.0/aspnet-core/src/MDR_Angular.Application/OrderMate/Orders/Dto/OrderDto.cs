using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.OrderLines.Dto;
using MDR_Angular.OrderMate.OrderStatusses.Dto;
using MDR_Angular.OrderMate.QrCodeSeatings;
using System;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.Orders.Dto
{
    [AutoMapFrom(typeof(Order))]
    [AutoMapTo(typeof(Order))]
    public class OrderDto : FullAuditedEntityDto<int>
    {
        public DateTime OrderDateCreated { get; set; }
        public DateTime? OrderDateCompleted { get; set; }
        public int? QrCodeSeatingIdFk { get; set; }
        public int? OrderStatusIdFk { get; set; }

        
        public virtual OrderStatusDto OrderStatusIdFkNavigation { get; set; }
        public virtual ICollection<OrderLineDto> OrderLine { get; set; }
        
        public virtual QrCodeSeatingDto QrCodeSeating { get; set; }
    }
}
