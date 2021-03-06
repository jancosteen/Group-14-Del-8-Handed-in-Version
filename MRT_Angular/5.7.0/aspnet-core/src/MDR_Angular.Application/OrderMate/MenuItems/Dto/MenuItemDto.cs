﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.ItemTypeMenuItems.Dto;
using MDR_Angular.OrderMate.MenuItemAllergies.Dto;
using MDR_Angular.OrderMate.MenuItemCategories.Dto;
using MDR_Angular.OrderMate.MenuItemPrices.Dto;
using MDR_Angular.OrderMate.MenuItemSpecials.Dto;
using MDR_Angular.OrderMate.MenuRestaurants.Dto;
using MDR_Angular.OrderMate.Menus;
using MDR_Angular.OrderMate.OrderLines.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.MenuItems.Dto
{
    [AutoMapFrom(typeof(MenuItem))]
    [AutoMapTo(typeof(MenuItem))]
    public class MenuItemDto : FullAuditedEntityDto<int>
    {
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public int? MenuItemCategoryIdFk { get; set; }
        public float MenuItemPrice { get; set; }
        public int? MenuIdFk { get; set; }

        public virtual MenuItemCategoryCandUDto MenuItemCategoryIdFkNavigation { get; set; }
       // public virtual MenuItemPriceDto MenuItemPriceIdFkNavigation { get; set; }
        public virtual ICollection<ItemTypeMenuItemCandUDto> ItemTypeMenuMenuItem { get; set; }
        //public virtual ICollection<MenuItemAllergyDto> MenuItemAllergy { get; set; }
        public virtual ICollection<MenuItemSpecialCandUDto> MenuItemSpecial { get; set; }
        [ForeignKey("MenuIdFk")]
        public virtual MenuCandUDto MenuIdFkNavigation { get; set; }
    }
}
