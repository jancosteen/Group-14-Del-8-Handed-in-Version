using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.MenuItems.Dto
{
    [AutoMapFrom(typeof(MenuItem))]
    [AutoMapTo(typeof(MenuItem))]
    public class MenuItemCandUDto
    {
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public int? MenuItemCategoryIdFk { get; set; }
        public int? MenuItemPriceIdFk { get; set; }
    }
}
