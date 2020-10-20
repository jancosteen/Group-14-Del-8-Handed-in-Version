using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MDR_Angular.OrderMate.MenuItems.Dto;
using MDR_Angular.OrderMate.MenuRestaurants.Dto;
using MDR_Angular.OrderMate.Restaurants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.Menus
{
    [AutoMapFrom(typeof(Menu))]
    [AutoMapTo(typeof(Menu))]
    public class MenuDto : FullAuditedEntityDto<int>
    {
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public DateTime MenuDateCreated { get; set; }
        public TimeSpan? MenuTimeActiveFrom { get; set; }
        public TimeSpan? MenuTimeActiveTo { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual ICollection<MenuItemDto> MenuItem { get; set; }
        [ForeignKey("RestaurantIdFk")]
        public virtual RestaurantDto RestaurantIdFkNavigation { get; set; }
    }
}
