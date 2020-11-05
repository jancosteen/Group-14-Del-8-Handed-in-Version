using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.MenuItems.Dto;

namespace MDR_Angular.OrderMate.OrderLines.Dto
{
    [AutoMapFrom(typeof(OrderLine))]
    [AutoMapTo(typeof(OrderLine))]
    public class OrderLineCandUDto:EntityDto<int>
    {
        public int ItemQty { get; set; }
        public string ItemComments { get; set; }
        public int? SpecialIdFk { get; set; }
        public int? MenuItemIdFk { get; set; }
        public int? OrderIdFk { get; set; }
        public long UserIdFk { get; set; }

        public virtual MenuItemCandUDto MenuItemIdFkNavigation { get; set; }

    }
}
