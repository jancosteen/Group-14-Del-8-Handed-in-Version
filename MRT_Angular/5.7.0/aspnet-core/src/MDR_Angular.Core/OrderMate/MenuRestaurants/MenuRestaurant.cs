using Abp.Domain.Entities.Auditing;
using MDR_Angular.OrderMate.MenuItems;
using MDR_Angular.OrderMate.Menus;
using MDR_Angular.OrderMate.Restaurants;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDR_Angular.OrderMate.MenuRestaurants
{
    public class MenuRestaurant : FullAuditedEntity<int>
    {
        //public int MenuRestaurantId { get; set; }
        public int MenuIdFk { get; set; }
        public int RestaurantIdFk { get; set; }
        public int? MenuItemIdFk { get; set; }

       
    }
}
