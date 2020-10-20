import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '../../../shared/app-component-base';
import {
  MenuServiceProxy,
  MenuDto, RestaurantServiceProxy, RestaurantDtoPagedResultDto, RestaurantDto, MenuItemServiceProxy, MenuItemDto, MenuItemDtoPagedResultDto, MenuItemAllergyServiceProxy, MenuItemAllergyDto, MenuDtoListResultDto
} from '../../../shared/service-proxies/service-proxies';
import { EditMenuItemDialogComponent } from '../../menuItems/edit-menuItem/edit-menuItem-dialog.component';
import { CreateMenuItemDialogComponent } from '../../menuItems/create-menuItem/create-menuItem-dialog.component';
import { EditMenuDialogComponent } from '../edit-menu/edit-menu-dialog.component';
import { CreateMenuDialogComponent } from '../create-menu/create-menu-dialog.component';
import { PagedRequestDto } from '@shared/paged-listing-component-base';

class PagedMenuItemsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}



@Component({
  templateUrl: 'menu-detail.component.html'
})
export class MenuDetailComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  menu: MenuDto = new MenuDto();
  Iid: number;
  restaurants: RestaurantDto[]=[];
  restautrant: RestaurantDto = new RestaurantDto();
  restaurant: RestaurantDto = new RestaurantDto();
  restaurantdIdFk:number;
  menuItems: MenuItemDto[]=[];
  linkedMenuItems:MenuItemDto[]=[];
  menuId:number;
  menuItemAllergies: MenuItemAllergyDto[]=[];
  miAllergyIds:MenuItemAllergyDto[] = [];
  public searchText:string;
  loading:boolean = true;
  advancedFiltersVisible = false;
  menuItemCount:number;
  keyword = '';
  isActive: boolean | null;
  menus:MenuDto[]=[];



  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuService: MenuServiceProxy,
    public _restaurantService: RestaurantServiceProxy,
    private activeRoute: ActivatedRoute,
    private _router: Router,
    public _menuItemService:MenuItemServiceProxy,
    public __menuItemAllergyService: MenuItemAllergyServiceProxy,
    private _modalService: BsModalService,

  ) {
    super(injector);
  }

  ngOnInit(): void {
    let id: string = this.activeRoute.snapshot.params['id'];
    this.Iid =+ id;
    this._menuService.getMenuById(this.Iid).subscribe((result: MenuDtoListResultDto) => {
      this.menus = result.items;
      this.restaurant = this.menus[0].restaurantIdFkNavigation;
      this.menuId = this.menus[0].id;
      this.loading = false;
      this.menuItems = this.menus[0].menuItem;
      console.log('menuItems',this.menus[0].menuItem);
    });


  }

  save(): void {
    this.saving = true;

    this._menuService
      .update(this.menu)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
      });
  }



  delete(menuItem: MenuItemDto): void {
    this.__menuItemAllergyService.getAllergyByMenuItemId(menuItem.id).subscribe((result) => {
      this.menuItemAllergies = result.items;
      this.miAllergyIds = this.menuItemAllergies});

    abp.message.confirm(
      this.l('MenuItemDeleteWarningMessage', menuItem.menuItemName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._menuItemService
            .delete(menuItem.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                let id: string = this.activeRoute.snapshot.params['id'];
              this.Iid =+ id;
    this._menuService.getMenuById(this.Iid).subscribe((result: MenuDtoListResultDto) => {
      this.menus = result.items;
      this.restaurant = this.menus[0].restaurantIdFkNavigation;
      this.menuId = this.menus[0].id;
      this.loading = false;
      this.menuItems = this.menus[0].menuItem;
      console.log('menuItems',this.menus[0].menuItem);
    });

              })
            )
            .subscribe(() => {});
        }
      }
    );
    for(let x=0; x<this.miAllergyIds.length;x++){
      this.__menuItemAllergyService
      .delete(this.miAllergyIds[x].id)
      .pipe(
        finalize(() => {
          console.log('deleted mia', this.miAllergyIds[x].id);
        })
      )
      .subscribe(() => {});
    }

  }

  createMenuItem(): void {
    this.showCreateOrEditMenuItemDialog();
  }

  editMenuItem(menuItem: MenuItemDto): void {
    this.showCreateOrEditMenuItemDialog(menuItem.id);
  }

  showCreateOrEditMenuItemDialog(id?: number): void {
    let createOrEditMenuItemDialog: BsModalRef;
    if (!id) {
      createOrEditMenuItemDialog = this._modalService.show(
        CreateMenuItemDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditMenuItemDialog = this._modalService.show(
        EditMenuItemDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditMenuItemDialog.content.onSave.subscribe(() => {
      let id: string = this.activeRoute.snapshot.params['id'];
    this.Iid =+ id;
    this._menuService.getMenuById(this.Iid).subscribe((result: MenuDtoListResultDto) => {
      this.menus = result.items;
      this.restaurant = this.menus[0].restaurantIdFkNavigation;
      this.menuId = this.menus[0].id;
      this.loading = false;
      this.menuItems = this.menus[0].menuItem;
      console.log('menuItems',this.menus[0].menuItem);
    });
    });
  }

  editMenu(menu: MenuDto): void {
    this.showCreateOrEditMenuDialog(menu.id);
  }

  showCreateOrEditMenuDialog(id?: number): void {
    let createOrEditMenuDialog: BsModalRef;
    if (!id) {
      createOrEditMenuDialog = this._modalService.show(
        CreateMenuDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditMenuDialog = this._modalService.show(
        EditMenuDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditMenuDialog.content.onSave.subscribe(() => {
      let id: string = this.activeRoute.snapshot.params['id'];
      this.Iid =+ id;
      this._menuService.get(this.Iid).subscribe((result: MenuDto) => {
      this.menu = result;
      this.restaurantdIdFk = this.menu.restaurantIdFk;
      this.menuId = this.menu.id;
    });
    });
  }

  viewMenuItem(menuItem:MenuItemDto): void {
    const detailsUrl: string = `/app/menuItem/${menuItem.id}`;
    this._router.navigate([detailsUrl]);
  }


}
