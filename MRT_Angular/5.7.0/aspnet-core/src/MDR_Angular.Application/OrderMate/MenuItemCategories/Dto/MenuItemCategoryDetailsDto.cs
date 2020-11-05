using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.MenuItems.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDR_Angular.OrderMate.MenuItemCategories.Dto
{
    [AutoMapFrom(typeof(MenuItemCategory))]
    [AutoMapTo(typeof(MenuItemCategory))]
    public class MenuItemCategoryDetailsDto: EntityDto<int>
    {
        public string MenuItemCategory1 { get; set; }

        public virtual ICollection<MenuItemCandUDto> MenuItem { get; set; }
    }
}
