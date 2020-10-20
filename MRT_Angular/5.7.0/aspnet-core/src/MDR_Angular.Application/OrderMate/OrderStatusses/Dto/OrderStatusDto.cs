using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.OrderStatusses.Dto
{
    [AutoMapFrom(typeof(OrderStatus))]
    [AutoMapTo(typeof(OrderStatus))]
    public class OrderStatusDto : FullAuditedEntityDto<int>
    {
        public string OrderStatus1 { get; set; }
    }
}
