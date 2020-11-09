import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '../../../shared/app-component-base';
import {
  MenuDto,
  MenuItemDto,
  MenuItemDtoPagedResultDto,
  MenuItemServiceProxy,
  MenuRestaurantDto,
  MenuRestaurantServiceProxy,
  MenuServiceProxy,
  RestaurantDto,
  RestaurantDtoPagedResultDto,
  RestaurantServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-menu-dialog.component.html'
})
export class CreateMenuDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  menu: MenuDto = new MenuDto();
  restaurants: RestaurantDto[]=[];
  menuItems: MenuItemDto[]=[];
  menuRestaurant:MenuRestaurantDto = new MenuRestaurantDto();
  createdMenuId;
  createdMenu:MenuDto = new MenuDto();
  sRestuarantIdCheck: string;
  restaurantIdCheck: number;
  restaurantName:string;


  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuService: MenuServiceProxy,
    public _restaurantService: RestaurantServiceProxy,
    public _menuItemService: MenuItemServiceProxy,
    public _menuRestaurantService: MenuRestaurantServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.sRestuarantIdCheck = localStorage.getItem('restaurantId');
    this.restaurantIdCheck = parseInt(this.sRestuarantIdCheck);
    console.log('resId', this.restaurantIdCheck);

    this._restaurantService
    .getAll(
      '',
      0,
      100
    )
    .pipe(
      finalize(() => {
        console.log('pipe');
      })
    )
    .subscribe((result: RestaurantDtoPagedResultDto) => {
      this.restaurants = result.items;
      this.getRestaurant();
      //this.showPaging(result, pageNumber);
    });

    this._menuItemService
    .getAll(
      '',
      0,
      100
    )
    .pipe(
      finalize(() => {
        console.log('pipe');
      })
    )
    .subscribe((result: MenuItemDtoPagedResultDto) => {
      this.menuItems = result.items;
      //this.showPaging(result, pageNumber);
    });



  }

  getRestaurant(){
    for(let x=0;x<this.restaurants.length;x++){
      if(this.restaurantIdCheck === this.restaurants[x].id){
        this.restaurantName = this.restaurants[x].restaurantName;
        console.log('restaurant Name', this.restaurantName);
        break;
      }
    }
  }

  save(): void {
    this.saving = true;

    if(this.sRestuarantIdCheck != null){
      this.menu.restaurantIdFk = this.restaurantIdCheck;


    this._menuService
      .create(this.menu)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe((res) => {
        this.createdMenuId = res.id;
        console.log('createdMID subscribe', this.createdMenuId);
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();

      });
    }else{
      this._menuService
      .create(this.menu)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe((res) => {
        this.createdMenuId = res.id;
        console.log('createdMID subscribe', this.createdMenuId);
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();

      });
    }
  }


}
