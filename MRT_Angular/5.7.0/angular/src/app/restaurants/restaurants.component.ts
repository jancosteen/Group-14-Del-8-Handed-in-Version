import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  RestaurantServiceProxy,
  RestaurantDto,
  RestaurantDtoPagedResultDto,
  MenuServiceProxy,
  MenuDto,
  MenuDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateRestaurantDialogComponent } from './create-restaurant/create-restaurant-dialog.component';
import { EditRestaurantDialogComponent } from './edit-restaurant/edit-restaurant-dialog.component';
import { Router } from '@angular/router';

class PagedRestaurantsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './restaurants.component.html',
  animations: [appModuleAnimation()]
})
export class RestaurantsComponent extends PagedListingComponentBase<RestaurantDto> {
  restaurants: RestaurantDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  searchText:string;
  menus:MenuDto[]=[];
  isRelated=false;

  constructor(
    injector: Injector,
    private _restaurantService: RestaurantServiceProxy,
    private _modalService: BsModalService,
    private _router: Router,
    private _menuService: MenuServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedRestaurantsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._restaurantService
      .getAll(
        request.keyword,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: RestaurantDtoPagedResultDto) => {
        this.restaurants = result.items;
        this.showPaging(result, pageNumber);
      });

      this._menuService
      .getAll(
        '',
        0,
        1000
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: MenuDtoPagedResultDto) => {
        this.menus = result.items;

      });
  }

  checkIfRelated(id){
    for(let x=0;x<this.menus.length;x++){
      if(this.menus[x].restaurantIdFk === id){
        this.isRelated=true;
        console.log(this.isRelated);
      }
    }
  }

  delete(restaurant: RestaurantDto): void {
    this.checkIfRelated(restaurant.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete Category, it has related menu items', restaurant.restaurantName)
      )
    }
    if(this.isRelated === false){
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', restaurant.restaurantName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._restaurantService
            .delete(restaurant.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
    }
  }

  createRestaurant(): void {
    this.showCreateOrEditRestaurantDialog();
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
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  viewRestaurant(res:RestaurantDto): void {
    const detailsUrl: string = `/app/restaurant/${res.id}`;
    this._router.navigate([detailsUrl]);
  }
}
