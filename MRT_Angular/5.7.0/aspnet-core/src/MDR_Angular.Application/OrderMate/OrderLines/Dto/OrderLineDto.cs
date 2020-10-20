using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.MenuItems.Dto;
using MDR_Angular.Users.Dto;

namespace MDR_Angular.OrderMate.OrderLines.Dto
{
    [AutoMapFrom(typeof(OrderLine))]
    [AutoMapTo(typeof(OrderLine))]
    public class OrderLineDto : FullAuditedEntityDto<int>
    {
        public int ItemQty { get; set; }
        public string ItemComments { get; set; }
        public int? SpecialIdFk { get; set; }
        public int? MenuItemIdFk { get; set; }
        public int? OrderIdFk { get; set; }
        public long UserIdFk { get; set; }

        public virtual MenuItemDto MenuItemIdFkNavigation { get; set; }
        public virtual UserDto UserIdFkNavigation { get; set; }
    }
}
