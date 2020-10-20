import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter,
  ViewChild,
  ElementRef
} from '@angular/core';
import{BehaviorSubject} from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  MenuServiceProxy,
  MenuDto, RestaurantServiceProxy, RestaurantDtoPagedResultDto, RestaurantDto, MenuItemServiceProxy, MenuItemDto, MenuItemDtoPagedResultDto, MenuItemAllergyServiceProxy, MenuItemAllergyDto, MenuDtoPagedResultDto, MenuItemCategoryDto
} from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { AppSessionService } from '@shared/session/app-session.service';
import { ThrowStmt } from '@angular/compiler';
import { CartModalComponent } from './cart-modal/cartModal.component';



class PagedMenuItemRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

class Cart{
  menuItemId:number;
  name:string;
  price:number;
  qty:number;
  total:number;
}

@Component({
  templateUrl: 'customerMenu.component.html'
})
export class CustomerMenuComponent extends PagedListingComponentBase<MenuItemDto>{

  saving = false;
  menu: MenuDto = new MenuDto();
  Iid: number;
  restaurants: RestaurantDto[]=[];
  restautrant: RestaurantDto = new RestaurantDto();
  restaurantdIdFk:number;
  menuItems: MenuItemDto[]=[];
  menus:MenuDto[]=[];
  linkedMenuItems:MenuItemDto[]=[];
  menuId:number;
  menuItemAllergies: MenuItemAllergyDto[]=[];
  miAllergyIds:MenuItemAllergyDto[] = [];
  public searchText:string;
  loading:boolean = true;
  advancedFiltersVisible = false;
  finalMenuItems:MenuItemDto[]=[];
  restaurant:RestaurantDto = new RestaurantDto();
  miBEER:MenuItemDto[]=[];
  miLAGERS:MenuItemDto[]=[];
  miPILSNER:MenuItemDto[]=[];
  miWEIS:MenuItemDto[]=[];
  miGOLDEN:MenuItemDto[]=[];
  miAMBER:MenuItemDto[]=[];
  miBLONDE:MenuItemDto[]=[];
  miSTRONG:MenuItemDto[]=[];
  miIPA:MenuItemDto[]=[];
  miPALE:MenuItemDto[]=[];
  miSTOUT:MenuItemDto[]=[];
  miTRAPPIST:MenuItemDto[]=[];
  miCIDER:MenuItemDto[]=[];
  cartCount:number=0;
  cart=[];
  cartItem:Cart=new Cart();
  startQty:number = 0;
  menuItemCategories:MenuItemCategoryDto[]=[];

  cart3 = [];
  cartItemCount: BehaviorSubject<number>;

  @ViewChild('cart', {static: false, read: ElementRef})fab: ElementRef;

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
    private _sessionService: AppSessionService

  ) {
    super(injector);
  }

  list(
    request: PagedMenuItemRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = '';

    let id: string = this.activeRoute.snapshot.params['id'];
    this.Iid =+ id;
    this._menuService.getMenuByResId(this.Iid).subscribe((result: MenuDtoPagedResultDto) => {
      this.menus = result.items;
      this.restaurantdIdFk = this.menus[0].restaurantIdFk;
      //this.menuId = this.menus[0].id;
      this.restaurant = this.menus[0].restaurantIdFkNavigation;
      this.populateMenuItems(this.menus[0]);
    });

    this.cartCount = 0;
    this.cart3 = this._sessionService.getCart();
    this.cartCount = this._sessionService.getCartItemCount();
    this.cart = [];
  }

  addToOrder(item){
      this._sessionService.addProduct(item);
      this.cartCount = this._sessionService.getCartItemCount();
  }

  popCategories(){
    for(let x=0;x<this.menuItems.length;x++){
      this.menuItemCategories.push(this.menuItems[x].menuItemCategoryIdFkNavigation);
    }
  }


  populateMenuItems(menu:MenuDto){
      this.finalMenuItems= [];
      this.miBEER=[];
  this.miLAGERS=[];
  this.miPILSNER=[];
  this.miWEIS=[];
  this.miGOLDEN=[];
  this.miAMBER=[];
  this.miBLONDE=[];
  this.miSTRONG=[];
  this.miIPA=[];
  this.miPALE=[];
  this.miSTOUT=[];
  this.miTRAPPIST=[];
  this.miCIDER=[];
      this.finalMenuItems = menu.menuItem;

      for(let x=0;x<this.finalMenuItems.length;x++){
        if(this.finalMenuItems[x].menuItemCategoryIdFk === 14){
          this.miBEER.push(this.finalMenuItems[x]);
        }else if(this.finalMenuItems[x].menuItemCategoryIdFk === 15){
          this.miLAGERS.push(this.finalMenuItems[x]);
        }else if(this.finalMenuItems[x].menuItemCategoryIdFk === 16){
          this.miPILSNER.push(this.finalMenuItems[x]);
        }else if(this.finalMenuItems[x].menuItemCategoryIdFk === 17){
          this.miWEIS.push(this.finalMenuItems[x]);
        }else if(this.finalMenuItems[x].menuItemCategoryIdFk === 18){
          this.miGOLDEN.push(this.finalMenuItems[x]);
        }else if(this.finalMenuItems[x].menuItemCategoryIdFk === 19){
          this.miAMBER.push(this.finalMenuItems[x]);
        }else if(this.finalMenuItems[x].menuItemCategoryIdFk === 20){
          this.miBLONDE.push(this.finalMenuItems[x]);
        }else if(this.finalMenuItems[x].menuItemCategoryIdFk === 21){
          this.miSTRONG.push(this.finalMenuItems[x]);
        }else if(this.finalMenuItems[x].menuItemCategoryIdFk === 22){
          this.miIPA.push(this.finalMenuItems[x]);
        }else if(this.finalMenuItems[x].menuItemCategoryIdFk === 23){
          this.miPALE.push(this.finalMenuItems[x]);
        }else if(this.finalMenuItems[x].menuItemCategoryIdFk === 24){
          this.miSTOUT.push(this.finalMenuItems[x]);
        }else if(this.finalMenuItems[x].menuItemCategoryIdFk === 25){
          this.miTRAPPIST.push(this.finalMenuItems[x]);
        }else if(this.finalMenuItems[x].menuItemCategoryIdFk === 26){
          this.miCIDER.push(this.finalMenuItems[x]);
        }
      }

  }

  delete(menuItem: MenuItemDto): void {
    this.__menuItemAllergyService.getAllergyByMenuItemId(menuItem.id).subscribe((result) => {
      this.menuItemAllergies = result.items;
      this.miAllergyIds = this.menuItemAllergies});

    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', menuItem.menuItemName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._menuItemService
            .delete(menuItem.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                //location.reload();

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

  createMenuItemCategory(): void {
    this.showCreateOrEditMenuItemCategoryDialog();
  }

  editMenuItemCategory(menuItemCategory: MenuItemCategoryDto): void {
    this.showCreateOrEditMenuItemCategoryDialog(menuItemCategory.id);
  }

  showCreateOrEditMenuItemCategoryDialog(id?: number): void {
    let createOrEditMenuItemCategoryDialog: BsModalRef;
    if (!id) {
      createOrEditMenuItemCategoryDialog = this._modalService.show(
        CartModalComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditMenuItemCategoryDialog = this._modalService.show(
        CartModalComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditMenuItemCategoryDialog.content.onSave.subscribe(() => {
      this.cartCount = this._sessionService.getCartItemCount();
    });
  }



}
