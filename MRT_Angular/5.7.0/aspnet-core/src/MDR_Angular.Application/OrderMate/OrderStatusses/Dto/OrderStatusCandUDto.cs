using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.OrderStatusses.Dto
{
    [AutoMapFrom(typeof(OrderStatus))]
    [AutoMapTo(typeof(OrderStatus))]
    public class OrderStatusCandUDto
    {
        public string OrderStatus1 { get; set; }
    }
}
