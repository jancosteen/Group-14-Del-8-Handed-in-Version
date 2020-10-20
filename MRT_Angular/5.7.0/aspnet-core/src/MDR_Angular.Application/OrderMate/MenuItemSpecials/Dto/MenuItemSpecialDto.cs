using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.MenuItemSpecials.Dto
{
    [AutoMapFrom(typeof(MenuItemSpecial))]
    [AutoMapTo(typeof(MenuItemSpecial))]
    public class MenuItemSpecialDto : FullAuditedEntityDto<int>
    {
        public int SpecialIdFk { get; set; }
        public int MenuItemIdFk { get; set; }
    }
}
