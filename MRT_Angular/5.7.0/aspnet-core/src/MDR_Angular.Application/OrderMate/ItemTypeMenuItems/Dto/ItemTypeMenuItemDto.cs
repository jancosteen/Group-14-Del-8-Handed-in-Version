using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.ItemTypeMenuMenuItems;
using MDR_Angular.OrderMate.MenuItemTypes.Dto;

namespace MDR_Angular.OrderMate.ItemTypeMenuItems.Dto
{
    [AutoMapFrom(typeof(ItemTypeMenuItem))]
    [AutoMapTo(typeof(ItemTypeMenuItem))]
    public class ItemTypeMenuItemDto : FullAuditedEntityDto<int>
    {
        public int MenuItemIdFk { get; set; }
        public int MenuItemTypeIdFk { get; set; }

        public virtual MenuItemTypeDto MenuItemTypeIdFkNavigation { get; set; }
    }
}
