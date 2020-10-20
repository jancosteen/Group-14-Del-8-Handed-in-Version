using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.MenuItemTypes.Dto
{
    [AutoMapFrom(typeof(MenuItemType))]
    [AutoMapTo(typeof(MenuItemType))]
    public class MenuItemTypeCandUDto
    {
        public string MenuItemType1 { get; set; }
    }
}
