using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.MenuItems.Dto;
using System.Collections.Generic;

namespace MDR_Angular.OrderMate.MenuItemCategories.Dto
{
    [AutoMapFrom(typeof(MenuItemCategory))]
    [AutoMapTo(typeof(MenuItemCategory))]
    public class MenuItemCategoryCandUDto: EntityDto<int>
    {
        public string MenuItemCategory1 { get; set; }

        public virtual ICollection<MenuItemCandUDto> MenuItems { get; set; }
    }
}
