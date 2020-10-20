import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  RestaurantStatusServiceProxy,
  RestaurantStatusDto,
  RestaurantStatusDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateRestaurantStatusDialogComponent } from './create-restaurantStatus/create-restaurantStatus-dialog.component';
import { EditRestaurantStatusDialogComponent } from './edit-restaurantStatus/edit-restaurantStatus-dialog.component';

class PagedRestaurantStatussRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './restaurantStatusses.component.html',
  animations: [appModuleAnimation()]
})
export class RestaurantStatussesComponent extends PagedListingComponentBase<RestaurantStatusDto> {
  restaurantStatuss: RestaurantStatusDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText:string;

  constructor(
    injector: Injector,
    private _restaurantStatusService: RestaurantStatusServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedRestaurantStatussRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._restaurantStatusService
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
      .subscribe((result: RestaurantStatusDtoPagedResultDto) => {
        this.restaurantStatuss = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(restaurantStatus: RestaurantStatusDto): void {
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', restaurantStatus.restaurantStatus1),
      undefined,
      (result: boolean) => {
        if (result) {
          this._restaurantStatusService
            .delete(restaurantStatus.id)
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

  createRestaurantStatus(): void {
    this.showCreateOrEditRestaurantStatusDialog();
  }

  editRestaurantStatus(restaurantStatus: RestaurantStatusDto): void {
    this.showCreateOrEditRestaurantStatusDialog(restaurantStatus.id);
  }

  showCreateOrEditRestaurantStatusDialog(id?: number): void {
    let createOrEditRestaurantStatusDialog: BsModalRef;
    if (!id) {
      createOrEditRestaurantStatusDialog = this._modalService.show(
        CreateRestaurantStatusDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditRestaurantStatusDialog = this._modalService.show(
        EditRestaurantStatusDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditRestaurantStatusDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
