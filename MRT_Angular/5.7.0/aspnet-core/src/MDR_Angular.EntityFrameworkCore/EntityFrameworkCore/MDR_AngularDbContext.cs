using Abp.Zero.EntityFrameworkCore;
using MDR_Angular.Authorization.Roles;
using MDR_Angular.Authorization.Users;
using MDR_Angular.MultiTenancy;
using MDR_Angular.OrderMate.AdvertisementDates;
using MDR_Angular.OrderMate.AdvertisementPrices;
using MDR_Angular.OrderMate.Advertisements;
using MDR_Angular.OrderMate.Allergies;
using MDR_Angular.OrderMate.AttendanceSheets;
using MDR_Angular.OrderMate.Employees;
using MDR_Angular.OrderMate.EmployeeShifts;
using MDR_Angular.OrderMate.ItemTypeMenuMenuItems;
using MDR_Angular.OrderMate.LayoutTypes;
using MDR_Angular.OrderMate.MenuItemAllergies;
using MDR_Angular.OrderMate.MenuItemCategories;
using MDR_Angular.OrderMate.MenuItemPrices;
using MDR_Angular.OrderMate.MenuItems;
using MDR_Angular.OrderMate.MenuItemSpecials;
using MDR_Angular.OrderMate.MenuItemTypes;
using MDR_Angular.OrderMate.MenuRestaurants;
using MDR_Angular.OrderMate.Menus;
using MDR_Angular.OrderMate.OrderLines;
using MDR_Angular.OrderMate.Orders;
using MDR_Angular.OrderMate.OrderStatusses;
using MDR_Angular.OrderMate.ProductCategories;
using MDR_Angular.OrderMate.ProductReorderFreqs;
using MDR_Angular.OrderMate.Products;
using MDR_Angular.OrderMate.ProductStockTakes;
using MDR_Angular.OrderMate.ProductsWrittenOff;
using MDR_Angular.OrderMate.ProductTypes;
using MDR_Angular.OrderMate.QrCodes;
using MDR_Angular.OrderMate.QrCodeSeatings;
using MDR_Angular.OrderMate.Reports;
using MDR_Angular.OrderMate.ReservationRestaurants;
using MDR_Angular.OrderMate.Reservations;
using MDR_Angular.OrderMate.ReservationStatusses;
using MDR_Angular.OrderMate.RestaurantAdvertisements;
using MDR_Angular.OrderMate.RestaurantFacilities;
using MDR_Angular.OrderMate.RestaurantFacilityRefs;
using MDR_Angular.OrderMate.RestaurantImages;
using MDR_Angular.OrderMate.RestaurantRestaurantImages;
using MDR_Angular.OrderMate.Restaurants;
using MDR_Angular.OrderMate.RestaurantStatusses;
using MDR_Angular.OrderMate.RestaurantTypeReferences;
using MDR_Angular.OrderMate.RestaurantTypes;
using MDR_Angular.OrderMate.SeatingLayouts;
using MDR_Angular.OrderMate.Seatings;
using MDR_Angular.OrderMate.Shifts;
using MDR_Angular.OrderMate.ShiftStatusses;
using MDR_Angular.OrderMate.SocialMedias;
using MDR_Angular.OrderMate.SocialMediaTypes;
using MDR_Angular.OrderMate.SpecialPrices;
using MDR_Angular.OrderMate.Specials;
using MDR_Angular.OrderMate.StarRatings;
using MDR_Angular.OrderMate.StockTakes;
using MDR_Angular.OrderMate.SupplierOrderLines;
using MDR_Angular.OrderMate.SupplierOrders;
using MDR_Angular.OrderMate.Suppliers;
using MDR_Angular.OrderMate.UserComments;
using MDR_Angular.OrderMate.WriteOffReasons;
using MDR_Angular.OrderMate.WrittenOffStocks;
using Microsoft.EntityFrameworkCore;

namespace MDR_Angular.EntityFrameworkCore
{
    public class MDR_AngularDbContext : AbpZeroDbContext<Tenant, Role, User, MDR_AngularDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<AdvertisementDate> AdvertisementDate { get; set; }
        public DbSet<AdvertisementPrice> AdvertisementPrice { get; set; }
        public DbSet<Advertisement> Advertisement { get; set; }
        public DbSet<Allergy> Allergy { get; set; }
        public DbSet<AttendanceSheet> AttendanceSheet { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeShift> EmployeeShift { get; set; }
        public DbSet<ItemTypeMenuItem> ItemTypeMenuItem { get; set; }
        public DbSet<LayoutType> LayoutType { get; set; }
        public DbSet<MenuItemAllergy> MenuItemAllergy { get; set; }
        public DbSet<MenuItemCategory> MenuItemCategory { get; set; }
        public DbSet<MenuItemPrice> MenuItemPrice { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<MenuItemSpecial> MenuItemSpecial { get; set; }
        public DbSet<MenuItemType> MenuItemType { get; set; }
        public DbSet<MenuRestaurant> MenuRestaurant { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<OrderLine> OrderLine { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductReorderFreq> ProductReorderFreq { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductStockTake> ProductStockTake { get; set; }
        public DbSet<ProductWrittenOff> ProductWrittenOff { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<QrCode> QrCode { get; set; }
        public DbSet<QrCodeSeating> QrCodeSeating { get; set; }
        public DbSet<ReservationRestaurant> ReservationRestaurant { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<ReservationStatus> ReservationStatus { get; set; }
        public DbSet<RestaurantAdvertisement> RestaurantAdvertisement { get; set; }
        public DbSet<RestaurantFacility> RestaurantFacility { get; set; }
        public DbSet<RestaurantFacilityRef> RestaurantFacilityRef { get; set; }
        public DbSet<RestaurantImage> RestaurantImage { get; set; }
        public DbSet<RestaurantRestaurantImage> RestaurantRestaurantImage { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<RestaurantStatus> RestaurantStatus { get; set; }
        public DbSet<RestaurantTypeRef> RestaurantTypeRef { get; set; }
        public DbSet<RestaurantType> RestaurantType { get; set; }
        public DbSet<SeatingLayout> SeatingLayout { get; set; }
        public DbSet<Seating> Seating { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<ShiftStatus> ShiftStatus { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<SocialMediaType> SocialMediaType { get; set; }
        public DbSet<SpecialPrice> SpecialPrice { get; set; }
        public DbSet<Special> Special { get; set; }
        public DbSet<StarRating> StarRating { get; set; }
        public DbSet<StockTake> StockTake { get; set; }
        public DbSet<SupplierOrderLine> SupplierOrderLine { get; set; }
        public DbSet<SupplierOrder> SupplierOrder { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<UserComment> UserComment { get; set; }
        public DbSet<WriteOffReason> WriteOffReason { get; set; }
        public DbSet<WrittenOffStock> WrittenOffStock { get; set; }
        public DbSet<TotalSalesByDayOfWeekReport> TotalSalesByDayOfWeekReport { get; set; }
        public DbSet<TotalSalesByMenuItemReport> TotalSalesByMenuItemReport { get; set; }



        public MDR_AngularDbContext(DbContextOptions<MDR_AngularDbContext> options)
            : base(options)
        {
        }

    }
}
