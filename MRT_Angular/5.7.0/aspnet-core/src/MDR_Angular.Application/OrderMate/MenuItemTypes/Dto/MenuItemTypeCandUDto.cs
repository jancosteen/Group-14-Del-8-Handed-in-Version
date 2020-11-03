using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace MDR_Angular.OrderMate.MenuItemTypes.Dto
{
    [AutoMapFrom(typeof(MenuItemType))]
    [AutoMapTo(typeof(MenuItemType))]
    public class MenuItemTypeCandUDto: Entity<int>
    {
        public string MenuItemType1 { get; set; }
    }
}
