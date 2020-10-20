import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import {
  Router,
  RouterEvent,
  NavigationEnd,
  PRIMARY_OUTLET
} from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { filter } from 'rxjs/operators';
import { MenuItem } from '@shared/layout/menu-item';

@Component({
  selector: 'sidebar-menu',
  templateUrl: './sidebar-menu.component.html'
})
export class SidebarMenuComponent extends AppComponentBase implements OnInit {
  menuItems: MenuItem[];
  menuItemsMap: { [key: number]: MenuItem } = {};
  activatedMenuItems: MenuItem[] = [];
  routerEvents: BehaviorSubject<RouterEvent> = new BehaviorSubject(undefined);
  homeRoute = '/app/home';

  constructor(injector: Injector, private router: Router) {
    super(injector);
    this.router.events.subscribe(this.routerEvents);
  }

  ngOnInit(): void {
    this.menuItems = this.getMenuItems();
    this.patchMenuItems(this.menuItems);
    this.routerEvents
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event) => {
        const currentUrl = event.url !== '/' ? event.url : this.homeRoute;
        const primaryUrlSegmentGroup = this.router.parseUrl(currentUrl).root
          .children[PRIMARY_OUTLET];
        if (primaryUrlSegmentGroup) {
          this.activateMenuItems('/' + primaryUrlSegmentGroup.toString());
        }
      });
  }

  getMenuItems(): MenuItem[] {
    return [
      new MenuItem(this.l('HomePage'), '/app/home', 'fas fa-circle'),
      new MenuItem(this.l('My Reservations'), '/app/cusReser', 'fas fa-circle'),
      new MenuItem(this.l('Administration'), '','fas fa-circle','Pages.SYSTEM_ADMIN',[
        new MenuItem(
          this.l('Tenants'),
          '/app/tenants',
          'fas fa-circle',
          'Pages.SYSTEM_ADMIN'
        ),
        new MenuItem(
          this.l('Users'),
          '/app/users',
          'fas fa-circle',
          'Pages.SYSTEM_ADMIN'
        ),
        new MenuItem(
          this.l('Roles'),
          '/app/roles',
          'fas fa-circle',
          'Pages.SYSTEM_ADMIN'
        ),
      ]),
      new MenuItem(this.l('Setup'),'', 'fas fa-circle','Pages.SYSTEM_ADMIN',[
        new MenuItem(this.l('Menus'),'','fas fa-circle','Pages.SYSTEM_ADMIN',[
          new MenuItem(
            this.l('Menus'),
            '/app/menus',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN'
          ),
          new MenuItem(
            this.l('Menu Items'),
            '/app/menuItems',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN'
          ),
          new MenuItem(
            this.l('Allergies'),
            '/app/allergies',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN'
          ),
          new MenuItem(
            this.l('Categories'),
            '/app/miCat',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN'
          ),
          new MenuItem(
            this.l('Prices'),
            '/app/miPrice',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN'
          ),

        ]),
        new MenuItem(this.l('Orders'),'','fas fa-circle','Pages.SYSTEM_ADMIN',[
          new MenuItem(
            this.l('Status'),
            '/app/orderStatus',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN'
          ),
        ]),
        new MenuItem(this.l('Reservations'),'','fas fa-circle','Pages.SYSTEM_ADMIN',[
          new MenuItem(
            this.l('Status'),
            '/app/resStatus',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN'
          ),
        ]),
        new MenuItem(this.l('Restaurants'), '', 'fas fa-circle', 'Pages.SYSTEM_ADMIN',[
          new MenuItem(
            this.l('Restaurants'),
            '/app/restaurants',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN'
          ),
          new MenuItem(
            this.l('Images'),
            '/app/resImages',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN'
          ),
          new MenuItem(
            this.l('Restaurant Status'),
            '/app/resStat',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN'
          ),
          new MenuItem(
            this.l('Social Media'),
            '/app/socialMedia',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN'
          ),
          new MenuItem(
            this.l('Social Media Types'),
            '/app/smTypes',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN'
          ),

        ]),
        new MenuItem(this.l('Tables'),'','fas fa-circle','Pages.SYSTEM_ADMIN',[
          new MenuItem(
            this.l('Tables'),
            '/app/seating',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN'),
          new MenuItem(
            this.l('QrCodes'),
            '/app/qrCodes',
            'fas fa-circle',
            'Pages.SYSTEM_ADMIN')
        ])
      ]),
      new MenuItem(
        this.l('Manage Reservations'),
        '/app/reservations',
        'fas fa-circle',
        "Pages.EMPLOYEE"
      ),
      new MenuItem(
        this.l('Manage Orders'),
        '/app/orders',
        'fas fa-circle',
        "Pages.EMPLOYEE"
      ),
      new MenuItem(
        this.l('Generate Qr Code'),
        '/app/qrGen',
        'fas fa-circle',
        "Pages.EMPLOYEE"
      )
    ]
  }

  patchMenuItems(items: MenuItem[], parentId?: number): void {
    items.forEach((item: MenuItem, index: number) => {
      item.id = parentId ? Number(parentId + '' + (index + 1)) : index + 1;
      if (parentId) {
        item.parentId = parentId;
      }
      if (parentId || item.children) {
        this.menuItemsMap[item.id] = item;
      }
      if (item.children) {
        this.patchMenuItems(item.children, item.id);
      }
    });
  }

  activateMenuItems(url: string): void {
    this.deactivateMenuItems(this.menuItems);
    this.activatedMenuItems = [];
    const foundedItems = this.findMenuItemsByUrl(url, this.menuItems);
    foundedItems.forEach((item) => {
      this.activateMenuItem(item);
    });
  }

  deactivateMenuItems(items: MenuItem[]): void {
    items.forEach((item: MenuItem) => {
      item.isActive = false;
      item.isCollapsed = true;
      if (item.children) {
        this.deactivateMenuItems(item.children);
      }
    });
  }

  findMenuItemsByUrl(
    url: string,
    items: MenuItem[],
    foundedItems: MenuItem[] = []
  ): MenuItem[] {
    items.forEach((item: MenuItem) => {
      if (item.route === url) {
        foundedItems.push(item);
      } else if (item.children) {
        this.findMenuItemsByUrl(url, item.children, foundedItems);
      }
    });
    return foundedItems;
  }

  activateMenuItem(item: MenuItem): void {
    item.isActive = true;
    if (item.children) {
      item.isCollapsed = false;
    }
    this.activatedMenuItems.push(item);
    if (item.parentId) {
      this.activateMenuItem(this.menuItemsMap[item.parentId]);
    }
  }

  isMenuItemVisible(item: MenuItem): boolean {
    if (!item.permissionName) {
      return true;
    }
    return this.permission.isGranted(item.permissionName);
  }
}
