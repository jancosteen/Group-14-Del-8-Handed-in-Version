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
  RestaurantDto, RestaurantServiceProxy, RestaurantDtoPagedResultDto, MenuItemServiceProxy, MenuServiceProxy, MenuDto, MenuDtoPagedResultDto, RestaurantStatusDtoPagedResultDto, RestaurantStatusServiceProxy, RestaurantStatusDto
} from '../../../shared/service-proxies/service-proxies';
import { EditRestaurantDialogComponent } from '../edit-restaurant/edit-restaurant-dialog.component';
import { CreateRestaurantDialogComponent } from '../create-restaurant/create-restaurant-dialog.component';
import { EditMenuDialogComponent } from '@app/menus/edit-menu/edit-menu-dialog.component';
import { CreateMenuDialogComponent } from '@app/menus/create-menu/create-menu-dialog.component';




@Component({
  templateUrl: 'restaurant-detail.component.html'
})
export class RestaurantDetailComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  restaurant: RestaurantDto = new RestaurantDto();
  Iid: number;
  menus: MenuDto[]=[];
  linkedMenus:MenuDto[]=[];
  restautrant: RestaurantDto = new RestaurantDto();
  restaurantdIdFk:number;
  restaurantId:number;
  public searchText:string;
  loading:boolean = true;
  advancedFiltersVisible = false;
  statusses: RestaurantStatusDto[]=[];
  resStatus:RestaurantStatusDto = new RestaurantStatusDto();
  restaurantStatusIdFk:number;



  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuService: MenuServiceProxy,
    public _restaurantService: RestaurantServiceProxy,
    private activeRoute: ActivatedRoute,
    private _router: Router,
    private _modalService: BsModalService,
    private _statusService: RestaurantStatusServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    let id: string = this.activeRoute.snapshot.params['id'];
    this.Iid =+ id;
    this._restaurantService.get(this.Iid).subscribe((result: RestaurantDto) => {
      this.restaurant = result;
      this.restaurantStatusIdFk = this.restaurant.restaurantStatusIdFk;
      this.restaurantId = this.restaurant.id;
    });

    this._statusService
    .getAll(
      '',
      0,
      100
    )
    .pipe(
      finalize(() => {
        console.log('menus pipe');
      })
    )
    .subscribe((result: RestaurantStatusDtoPagedResultDto) => {
      this.statusses = result.items;
      this.getRestaurantStatus(this.restaurantStatusIdFk);
      //this.showPaging(result, pageNumber);
    });
    this.getAllMenus();

  }

  save(): void {
    this.saving = true;

    this._restaurantService
      .update(this.restaurant)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
      });
  }



  getAllMenus(){
    this._menuService
    .getAll(
      '',
      0,
      100
    )
    .pipe(
      finalize(() => {
        console.log('menus pipe');
      })
    )
    .subscribe((result: MenuDtoPagedResultDto) => {
      this.menus = result.items;
      this.getLinkedMenus(this.restaurantStatusIdFk)
      //this.showPaging(result, pageNumber);
    });
  }

  getLinkedMenus(rId){
    console.log(this.menus,rId);
    for(let x=0;x<this.menus.length;x++){
      if(rId==this.menus[x].restaurantIdFk){
        this.linkedMenus.push(this.menus[x]);
        console.log('linked Menus',rId,this.linkedMenus[x]);
      }
    }
    this.loading = false;
  }

  getAllStatusses(){

  }

  getRestaurantStatus(statId){
    for(let x=0;x<this.statusses.length;x++){
      if(statId==this.statusses[x].id){
        this.resStatus=this.statusses[x];
        console.log('status',statId,this.statusses[x]);
      }
    }
  }



  delete(menu: MenuDto): void {
    abp.message.confirm(
      this.l('MenuDeleteWarningMessage', menu.menuName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._menuService
            .delete(menu.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.getAllMenus();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createMenu(): void {
    this.showCreateOrEditMenuDialog();
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
      this.getAllMenus();
    });
  }

  editRestaurant(restaurant: RestaurantDto): void {
    this.showCreateOrEditRestaurantDialog(restaurant.id);
  }

  showCreateOrEditRestaurantDialog(id?: number): void {
    let createOrEditRestaurantDialog: BsModalRef;
    if (!id) {
      createOrEditRestaurantDialog = this._modalService.show(
        CreateRestaurantDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditRestaurantDialog = this._modalService.show(
        EditRestaurantDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditRestaurantDialog.content.onSave.subscribe(() => {
      let id: string = this.activeRoute.snapshot.params['id'];
      this.Iid =+ id;
      this._restaurantService.get(this.Iid).subscribe((result: RestaurantDto) => {
      this.restaurant = result;
      this.restaurantStatusIdFk = this.restaurant.restaurantStatusIdFk;
      this.restaurantId = this.restaurant.id;
    });
    });
  }

  viewMenu(menu:MenuDto): void {
    const detailsUrl: string = `/app/menu/${menu.id}`;
    this._router.navigate([detailsUrl]);
  }


}
