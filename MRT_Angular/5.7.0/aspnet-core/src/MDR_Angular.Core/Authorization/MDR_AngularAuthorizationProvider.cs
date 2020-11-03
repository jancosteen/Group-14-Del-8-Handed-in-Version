using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace MDR_Angular.Authorization
{
    public class MDR_AngularAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Customer, L("Customer"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"));
            
            context.CreatePermission(PermissionNames.Pages_AD, L("AdvertisementDates"));
            context.CreatePermission(PermissionNames.Pages_AP, L("AdvertisementPrices"));
            context.CreatePermission(PermissionNames.Pages_A, L("Advertisements"));
            context.CreatePermission(PermissionNames.Pages_Al, L("Allergies"));
            context.CreatePermission(PermissionNames.Pages_AS, L("AttendanceSheets"));
            context.CreatePermission(PermissionNames.Pages_E, L("Emlpoyees"));
            context.CreatePermission(PermissionNames.Pages_ES, L("EmployeeShifts"));
            context.CreatePermission(PermissionNames.Pages_ITMI, L("MenuItemRef"));
            context.CreatePermission(PermissionNames.Pages_LT, L("LayoutTypes"));
            context.CreatePermission(PermissionNames.Pages_MIA, L("MenuItemAllergies"));
            context.CreatePermission(PermissionNames.Pages_MIC, L("MenuItemCategories"));
            context.CreatePermission(PermissionNames.Pages_MIP, L("MenuItemPrices"));
            context.CreatePermission(PermissionNames.Pages_MI, L("MenuItems"));
            context.CreatePermission(PermissionNames.Pages_MIS, L("MenuItemSpecials"));
            context.CreatePermission(PermissionNames.Pages_MIT, L("MenuItemTypes"));
            context.CreatePermission(PermissionNames.Pages_MR, L("MenuRestaurants"));
            context.CreatePermission(PermissionNames.Pages_M, L("Menus"));
            context.CreatePermission(PermissionNames.Pages_OL, L("OrderLines"));
            context.CreatePermission(PermissionNames.Pages_O, L("Orders"));
            context.CreatePermission(PermissionNames.Pages_OS, L("OrderStatusses"));
            context.CreatePermission(PermissionNames.Pages_PC, L("ProductCategories"));
            context.CreatePermission(PermissionNames.Pages_PRF, L("ProductReorderFrequencies"));
            context.CreatePermission(PermissionNames.Pages_P, L("Products"));
            context.CreatePermission(PermissionNames.Pages_PST, L("ProductStockTakes"));
            context.CreatePermission(PermissionNames.Pages_PWO, L("ProductsWrittenOff"));
            context.CreatePermission(PermissionNames.Pages_PT, L("ProductTypes"));
            context.CreatePermission(PermissionNames.Pages_QC, L("QrCodes"));
            context.CreatePermission(PermissionNames.Pages_QCS, L("QrCodeSeatings"));
            context.CreatePermission(PermissionNames.Pages_RR, L("ReservationRestaurants"));
            context.CreatePermission(PermissionNames.Pages_R, L("Reservations"));
            context.CreatePermission(PermissionNames.Pages_RS, L("ReservationStatusses"));
            context.CreatePermission(PermissionNames.Pages_RA, L("RestaurantAdvertisements"));
            context.CreatePermission(PermissionNames.Pages_RF, L("RestaurantFacilities"));
            context.CreatePermission(PermissionNames.Pages_RFR, L("RestaurantfacilityRefs"));
            context.CreatePermission(PermissionNames.Pages_RI, L("RestaurantImages"));
            context.CreatePermission(PermissionNames.Pages_RRI, L("RestaurantImageRefs"));
            context.CreatePermission(PermissionNames.Pages_REST, L("Restaurants"));
            context.CreatePermission(PermissionNames.Pages_RTR, L("RestaurantTypeRefs"));
            context.CreatePermission(PermissionNames.Pages_RT, L("RestaurantTypes"));
            context.CreatePermission(PermissionNames.Pages_SL, L("SeatingLayouts"));
            context.CreatePermission(PermissionNames.Pages_S, L("Seatings"));
            context.CreatePermission(PermissionNames.Pages_SH, L("Shifts"));
            context.CreatePermission(PermissionNames.Pages_SHS, L("ShiftStatusses"));
            context.CreatePermission(PermissionNames.Pages_SM, L("SocialMedias"));
            context.CreatePermission(PermissionNames.Pages_SMT, L("SocialMediaTypes"));
            context.CreatePermission(PermissionNames.Pages_SP, L("Specials"));
            context.CreatePermission(PermissionNames.Pages_SPP, L("SpecialPrices"));
            context.CreatePermission(PermissionNames.Pages_SR, L("StarRatings"));
            context.CreatePermission(PermissionNames.Pages_ST, L("StockTackes"));
            context.CreatePermission(PermissionNames.Pages_SOL, L("SupplierOrderLines"));
            context.CreatePermission(PermissionNames.Pages_SO, L("SupplierOrders"));
            context.CreatePermission(PermissionNames.Pages_SUP, L("Suppliers"));
            context.CreatePermission(PermissionNames.Pages_UC, L("UserComments"));
            context.CreatePermission(PermissionNames.Pages_WOS, L("WrittenOffStocks"));
            context.CreatePermission(PermissionNames.Pages_SYSTEM_ADMIN, L("SYSTEM_ADMIN"));
            context.CreatePermission(PermissionNames.Pages_EMPLOYEE, L("EMPLOYEE"));



        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, MDR_AngularConsts.LocalizationSourceName);
        }
    }
}
