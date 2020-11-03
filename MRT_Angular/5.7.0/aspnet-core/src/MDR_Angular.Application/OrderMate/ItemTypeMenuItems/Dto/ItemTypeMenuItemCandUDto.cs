using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.ItemTypeMenuMenuItems;
using MDR_Angular.OrderMate.MenuItems.Dto;
using MDR_Angular.OrderMate.MenuItemTypes.Dto;

namespace MDR_Angular.OrderMate.ItemTypeMenuItems.Dto
{
    [AutoMapFrom(typeof(ItemTypeMenuItem))]
    [AutoMapTo(typeof(ItemTypeMenuItem))]
    public class ItemTypeMenuItemCandUDto: EntityDto<int>
    {
        public int MenuItemIdFk { get; set; }
        public int MenuItemTypeIdFk { get; set; }

       
        public virtual MenuItemCandUDto MenuItemIdFkNavigation { get; set; }
        
        public virtual MenuItemTypeCandUDto MenuItemTypeIdFkNavigation { get; set; }
    }
}
