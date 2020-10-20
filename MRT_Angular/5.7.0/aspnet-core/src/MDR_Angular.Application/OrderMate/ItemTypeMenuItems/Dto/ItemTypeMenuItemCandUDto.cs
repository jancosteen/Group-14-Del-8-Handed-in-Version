using Abp.AutoMapper;
using MDR_Angular.OrderMate.ItemTypeMenuMenuItems;

namespace MDR_Angular.OrderMate.ItemTypeMenuItems.Dto
{
    [AutoMapFrom(typeof(ItemTypeMenuItem))]
    [AutoMapTo(typeof(ItemTypeMenuItem))]
    public class ItemTypeMenuItemCandUDto
    {
        public int MenuItemIdFk { get; set; }
        public int MenuItemTypeIdFk { get; set; }
    }
}
