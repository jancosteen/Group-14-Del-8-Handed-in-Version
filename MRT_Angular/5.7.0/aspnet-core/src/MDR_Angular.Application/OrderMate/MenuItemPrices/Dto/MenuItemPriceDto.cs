using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace MDR_Angular.OrderMate.MenuItemPrices.Dto
{
    [AutoMapFrom(typeof(MenuItemPrice))]
    [AutoMapTo(typeof(MenuItemPrice))]
    public class MenuItemPriceDto : FullAuditedEntityDto<int>
    {
        public double MenuItemPrice1 { get; set; }
        public DateTime MenuItemDateUpdated { get; set; }
        public Boolean isActive { get; set; }
    }
}
