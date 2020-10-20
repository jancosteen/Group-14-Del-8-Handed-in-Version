using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.MenuItemCategories.Dto
{
    [AutoMapFrom(typeof(MenuItemCategory))]
    [AutoMapTo(typeof(MenuItemCategory))]
    public class MenuItemCategoryDto : FullAuditedEntityDto<int>
    {
        public string MenuItemCategory1 { get; set; }
    }
}
