using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.MenuItems.Dto
{
    [AutoMapFrom(typeof(MenuItem))]
    [AutoMapTo(typeof(MenuItem))]
    public class MenuItemCandUDto: EntityDto<int>
    {
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public int? MenuItemCategoryIdFk { get; set; }
        public float MenuItemPrice { get; set; }
    }
}
