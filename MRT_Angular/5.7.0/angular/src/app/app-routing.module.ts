import { ReportComponent } from './report/report.component';
import { DashComponent } from './dash/dash.component';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { AllergiesComponent } from './allergies/allergies.component';
import { AdvPricesComponent } from './advPrices/advPrices.component';
import { RestaurantsComponent } from './restaurants/restaurants.component';
import { RestaurantImagesComponent } from './restaurant-images/restaurantImages.component';
import { RestaurantFacilitiesComponent } from './restaurant-facilities/restaurantFacilities.component';
import { RestaurantTypesComponent } from './restaurant-types/restaurantTypes.component';
import { MenuItemCategoriesComponent } from './menuItem-categories/menuItemCategories.component';
import { MenuItemPricesComponent } from './menuItem-prices/menuItemPrices.component';
import { OrderStatussesComponent } from './order-statusses/orderStatus.component';
import { ReservationStatussesComponent } from './reservation-statusses/reservationStatusses.component';
import { RestaurantStatussesComponent } from './restaurant-status/restaurantStatusses.component';
import { SocialMediaTypesComponent } from './socialMedia-types/socialMediaTypes.component';
import { SocialMediasComponent } from './socialMedias/socialMedias.component';
import { QrCodeGeneratorComponent } from './qrCodeGenerator/qr-code-generator/qr-code-generator.component';
import { ReservationsComponent } from './reservations/reservations.component';
import { MenuItemTypesComponent } from './menuItem-types/menuItemType.component';
import { OrdersComponent } from './orders/orders.component';
import { MenuItemsComponent } from './menuItems/menuItems.component';
import { SeatingsComponent } from './seating/seatings.component';
import { QrCodesComponent } from './qrCodes/qrCodes.component';
import { MenusComponent } from './menus/menus.component';
import { MenuDetailComponent } from './menus/menu-detail/menu-detail.component';
import { RestaurantDetailComponent } from './restaurants/restaurant-detail/restaurant-detail.component';
import { MenuItemDetailComponent } from './menuItems/menuItem-detail/menuItem-detail.component';
import { StarRatingsComponent } from './starRatings/starRatings.component';
import { OrderLinesComponent } from './orderLines/orderLines.component';
import { OrderDetailComponent } from './orders/order-detail/order-detail.component';
import { CreateOrderLineDialogComponent } from './orderLines/create-orderLine/create-orderLine-dialog.component';
import { CustomerMenuComponent } from './customerMenu/customerMenu.component';
import { CustomerReservationsComponent } from './customerReservations/customerReservations.component';
import { CheckInComponent } from './checkIn/checkIn.component';
import { CountriesComponent} from './countries/countries.component';
import { CitiesComponent } from './cities/cities.component';
import { ProvincesComponent } from './provinces/provinces.component';
import { ViewOrdersComponent } from './viewOrders/orders.component';
import { OrderHistoryComponent } from './orderHistory/orderHistory.component';
import { QrCodeScannerComponent } from './qr-code-scanner/qr-code-scanner.component';
import { ViewUserComponent } from './view-user/view-user.component';
import { OrderHistoryDetailComponent } from './orderHistory/orderHistory-detail/detail-orderHistory-.component';
import { CheckoutComponent } from './checkout/checkout.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'checkout', component: CheckoutComponent, data: {permission: '' }, canActivate: [AppRouteGuard] },
                    { path: 'dash', component:DashComponent, data: {permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'report', component:ReportComponent, data: {permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'home', component: HomeComponent },
                    { path: 'users', component: UsersComponent, data: { permission: '' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: '' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: '' }, canActivate: [AppRouteGuard] },
                    { path: 'about', component: AboutComponent },
                    { path: 'update-password', component: ChangePasswordComponent },
                    { path: 'allergies', component: AllergiesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'advPrices', component: AdvPricesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'restaurants', component: RestaurantsComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'resImages', component: RestaurantImagesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'resFacs', component: RestaurantFacilitiesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'resTypes', component: RestaurantTypesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'miCat', component: MenuItemCategoriesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'miPrice', component: MenuItemPricesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'orderStatus', component: OrderStatussesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'resStatus', component: ReservationStatussesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'resStat', component: RestaurantStatussesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'smTypes', component: SocialMediaTypesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'socialMedia', component: SocialMediasComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'qrGen', component: QrCodeGeneratorComponent, data: { permission: 'Pages.EMPLOYEE' }, canActivate: [AppRouteGuard] },
                    { path: 'reservations', component: ReservationsComponent, data: { permission: 'Pages.EMPLOYEE' }, canActivate: [AppRouteGuard] },
                    { path: 'miTypes', component: MenuItemTypesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'orders', component: OrdersComponent, data: { permission: 'Pages.EMPLOYEE' }, canActivate: [AppRouteGuard] },
                    { path: 'menuItems', component: MenuItemsComponent, data: { permission: 'Pages.EMPLOYEE' }, canActivate: [AppRouteGuard] },
                    { path: 'seating', component: SeatingsComponent, data: { permission: 'Pages.EMPLOYEE' }, canActivate: [AppRouteGuard] },
                    { path: 'qrCodes', component: QrCodesComponent, data: { permission: 'Pages.EMPLOYEE' }, canActivate: [AppRouteGuard] },
                    { path: 'menus', component: MenusComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'menu/:id', component: MenuDetailComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'restaurant/:id', component: RestaurantDetailComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'menuItem/:id', component: MenuItemDetailComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'starRatings', component: StarRatingsComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'orderLines', component: OrderLinesComponent, data: { permission: 'Pages.EMPLOYEE' }, canActivate: [AppRouteGuard] },
                    { path: 'order/:id', component: OrderDetailComponent, data: { permission: 'Pages.EMPLOYEE' }, canActivate: [AppRouteGuard] },
                    { path: 'orderLine', component: CreateOrderLineDialogComponent, data: { permission: 'Pages.EMPLOYEE' }, canActivate: [AppRouteGuard] },
                    { path: 'cusMenu/:id', component: CustomerMenuComponent, data: { permission: '' }, canActivate: [AppRouteGuard] },
                    { path: 'cusMenu2/:id', component: CustomerMenuComponent, data: { permission: '' }, canActivate: [AppRouteGuard] },
                    { path: 'cusReser', component: CustomerReservationsComponent, data: { permission: '' }, canActivate: [AppRouteGuard] },
                    { path: 'checkIn', component: CheckInComponent, data: { permission: '' }, canActivate: [AppRouteGuard] },
                    { path: 'countries', component: CountriesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'cities', component: CitiesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'provinces', component: ProvincesComponent, data: { permission: 'Pages.SYSTEM_ADMIN' }, canActivate: [AppRouteGuard] },
                    { path: 'cusOrder/:id', component:ViewOrdersComponent, data:{ permisssion: ''}, canActivate: [AppRouteGuard]},
                    { path: 'orderHist', component:OrderHistoryComponent, data:{ permisssion: ''}, canActivate: [AppRouteGuard]},
                    { path: 'qrScan', component:QrCodeScannerComponent, data:{ permisssion: ''}, canActivate: [AppRouteGuard]},
                    { path: 'orderHistory/:id', component:OrderHistoryDetailComponent, data:{ permisssion: ''}, canActivate: [AppRouteGuard]},
                    { path: 'cusOrder', component:ViewOrdersComponent, data:{ permisssion: ''}, canActivate: [AppRouteGuard]},
                    { path: 'viewUser', component:ViewUserComponent, data:{ permisssion: ''}, canActivate: [AppRouteGuard]},

                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
