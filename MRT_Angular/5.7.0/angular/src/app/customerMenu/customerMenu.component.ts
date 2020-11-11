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
  MenuDto, RestaurantServiceProxy, RestaurantDtoPagedResultDto, RestaurantDto, MenuItemServiceProxy, MenuItemDto, MenuItemDtoPagedResultDto, MenuItemAllergyServiceProxy, MenuItemAllergyDto, MenuDtoPagedResultDto, MenuItemCategoryDto, RestaurantCandUDto, MenuItemCategoryServiceProxy, MenuItemCategoryDetailsDtoListResultDto, MenuItemCategoryDetailsDto, MenuItemCandUDto, OrderDto, OrderServiceProxy, QrCodeSeatingServiceProxy, QrCodeSeatingDto
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
  //restautrant: RestaurantCandUDto = new RestaurantCandUDto();
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
  restaurant;
  cartCount:number=0;
  cart=[];
  cartItem:Cart=new Cart();
  startQty:number = 0;
  menuItemCategories:MenuItemCategoryDetailsDto[]=[];
  menuItems2:MenuItemDto[]=[];
  tempOrderId:string;
  order: OrderDto = new OrderDto();
  iOrderId:number;
  orderCheck:boolean;
  orderId:number;
  checkedIn:string;
  checkedInCheck:boolean;
  selectedMenuItem:MenuItemDto = new MenuItemDto();
  selectedMenuItems: MenuItemDto[]=[];
  selectedMenuItemCategories: MenuItemCategoryDetailsDto[]=[];
  selectedMenuItemCategory: MenuItemCategoryDetailsDto = new MenuItemCategoryDetailsDto();
  filteredMIC:MenuItemCategoryDetailsDto[]=[];
  sQrCodeSeatingId:string;
  iQrCodeSeatingId:number;
  qrCodeSeating: QrCodeSeatingDto = new QrCodeSeatingDto();

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
    private _menuItemCategoryService: MenuItemCategoryServiceProxy,
    public _menuItemService:MenuItemServiceProxy,
    public __menuItemAllergyService: MenuItemAllergyServiceProxy,
    private _modalService: BsModalService,
    private _sessionService: AppSessionService,
    private _orderService: OrderServiceProxy,
    private _qrCodeSeatingService: QrCodeSeatingServiceProxy

  ) {
    super(injector);
  }

  list(
    request: PagedMenuItemRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ) {
    request.keyword = '';
    this.checkedInCheck = false;
    this.checkedIn=localStorage.getItem('checkedIn');
    if(this.checkedIn != null){
      this.checkedInCheck = true;
    }
    this.menus = [];

    this.orderCheck = false;
    this.orderId = +localStorage.getItem('orderId');
    console.log('local storage orderId',this.orderId);
    let id: string = this.activeRoute.snapshot.params['id'];
    localStorage.setItem('resId', id);
    console.log('resId',id);
    this.Iid =+ id;

    this.sQrCodeSeatingId = localStorage.getItem('qrCodeSeatingId');
    this.iQrCodeSeatingId = parseInt(this.sQrCodeSeatingId);

    this._qrCodeSeatingService.get(this.iQrCodeSeatingId)
      .subscribe((res:QrCodeSeatingDto)=>{
        this.qrCodeSeating = res;
      })


    if(this.checkedIn == null){
      this._menuService.getMenuByResId(this.Iid).subscribe((result: MenuDtoPagedResultDto) => {
        this.menus = result.items;
        console.log(this.menus);
        this.restaurantdIdFk = this.menus[0].restaurantIdFk;
        //this.menuId = this.menus[0].id;
        this.restaurant = this.menus[0].restaurantIdFkNavigation.restaurantName;
        this.popCategories(this.menus[0]);
      });
    }else{
      this._menuService
        .getMenuById(this.Iid).subscribe((result: MenuDtoPagedResultDto) => {
          this.menus = result.items;
          console.log(this.menus);
          this.restaurantdIdFk = this.menus[0].restaurantIdFk;
          //this.menuId = this.menus[0].id;
          this.restaurant = this.menus[0].restaurantIdFkNavigation.restaurantName;
          this.popCategories(this.menus[0]);
        });
    }




    this.cartCount = 0;
    this.cart = this._sessionService.getCart();
    //this.cart = [];
    this.cartCount = this._sessionService.getCartItemCount();
    this._modalService.onHide.subscribe(() =>{
      this.cartCount = this._sessionService.getCartItemCount();
    });

  }

  updateQCS(){
    this.qrCodeSeating.orderIdFk = parseInt(localStorage.getItem('orderId'))

    this._qrCodeSeatingService.update(this.qrCodeSeating)
      .subscribe(res =>{
        console.log('qcs Update', res);
      })
  }

  addToOrder(item: MenuItemCandUDto){

    if(this.checkedInCheck == false){
      console.log('not', this.checkedIn);

        abp.message.confirm(
          ('Please check in before starting your order'),
          undefined,
          (result: boolean) => {
            if (result) {
              this.goToCheckIn();
            }
          }
        );

    }else{
      console.log('item', item);

      const mItem = {
        id : item.id,
        menuItemName : item.menuItemName,
        menuItemDescription : item.menuItemDescription,
        menuItemPrice : item.menuItemPrice,
        menuItemCategoryIdFk : item.menuItemCategoryIdFk
      };


      console.log('mItem', mItem);

        this._sessionService.addProduct(mItem);
        console.log('cartCountBefore GetCart', this.cartCount);
        this.cartCount = this._sessionService.getCartItemCount();
        console.log('cartCountAfter GetCartCount', this.cartCount);

        if(this.orderId > 0){
          this.orderCheck = true;
          console.log(localStorage.getItem('orderId'));
        }else{
          this.createOrder();
        }
    }


  }

  createOrder(){
      this.order.qrCodeSeatingIdFk = this.iQrCodeSeatingId;
      this.order.orderStatusIdFk = 1;
        this._orderService
          .create(this.order)
          .pipe(
            finalize(() => {
              console.log('Orderpipe');
            })
          )
          .subscribe((result) => {
            this.iOrderId = result.id;
            this.tempOrderId = this.iOrderId.toString();
            localStorage.setItem('orderId', this.tempOrderId)
            this.notify.info(this.l('SavedSuccessfully'));
            console.log('new orderId',this.tempOrderId)})
            this.orderCheck = true;
            this.updateQCS();
    }





  popCategories(menu){

    console.log('menu in PopCat', menu);

    this._menuItemCategoryService
      .getMicAndMi()
      .pipe(
        finalize(() => {
          console.log('Pop Categories');
        })
      )
      .subscribe((result: MenuItemCategoryDetailsDtoListResultDto) => {
        this.menuItemCategories = result.items;
        console.log(this.menuItemCategories);

        for(let x=0;x<this.menuItemCategories.length;x++){
          for(let y=0;y<menu.menuItem.length;y++){
            if(this.menuItemCategories[x].id == menu.menuItem[y].menuItemCategoryIdFk){
              this.selectedMenuItem = menu.menuItem[y];
              this.selectedMenuItems.push(this.selectedMenuItem)

              this.selectedMenuItemCategory = this.menuItemCategories[x];
              this.selectedMenuItemCategories.push(this.selectedMenuItemCategory);

            }
          }
        }
        this.filterMIC();
        console.log('selected menuItems', this.selectedMenuItems);
        console.log('selected menuItemCategories', this.selectedMenuItemCategories);
      });
  }

  popMenuItems(){
    for(let x=0;x<this.menuItemCategories.length;x++){
      for(let y=0;y<this.menus[0].menuItem.length;y++){
        if(this.menuItemCategories[x].id == this.menus[0].menuItem[y].menuItemCategoryIdFk){
          this.selectedMenuItem = this.menu[0].menuItem[y];
          this.selectedMenuItems.push(this.selectedMenuItem)
        }
      }
    }

    console.log('selected menuItems', this.selectedMenuItems);
  }

  public filterMIC(){
    this.filteredMIC= this.selectedMenuItemCategories.reduce((arr, item) => {
      let exists = !!arr.find(x => x.id === item.id);
      if(!exists){
          arr.push(item);
      }
      return arr;
  }, []);
  console.log('filtered MIC', this.filteredMIC);
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
      //this.cartCount = this._sessionService.getCartItemCount();
      this.cartCount = 0;
      this._sessionService.clearCart();
    });
  }

goToCheckIn(){
    const detailsUrl: string = `/app/qrScan`;
    this._router.navigate([detailsUrl]);
  }

}
