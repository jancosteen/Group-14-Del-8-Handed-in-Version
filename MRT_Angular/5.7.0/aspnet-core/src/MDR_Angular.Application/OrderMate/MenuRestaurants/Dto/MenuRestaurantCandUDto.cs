using Abp.AutoMapper;

namespace MDR_Angular.OrderMate.MenuRestaurants.Dto
{
    [AutoMapFrom(typeof(MenuRestaurant))]
    [AutoMapTo(typeof(MenuRestaurant))]
    public class MenuRestaurantCandUDto
    {
        public int MenuIdFk { get; set; }
        public int RestaurantIdFk { get; set; }
        public int? MenuItemIdFk { get; set; }
    }
}
