import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  RestaurantFacilityServiceProxy,
  RestaurantFacilityDto,
  RestaurantFacilityDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateRestaurantFacilityDialogComponent } from './create-facility/create-restaurantFacility-dialog.component';
import { EditRestaurantFacilityDialogComponent } from './edit-facility/edit-restaurantFacility-dialog.component';

class PagedRestaurantFacilitysRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './restaurantFacilities.component.html',
  animations: [appModuleAnimation()]
})
export class RestaurantFacilitiesComponent extends PagedListingComponentBase<RestaurantFacilityDto> {
  restaurantFacilitys: RestaurantFacilityDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText:string;

  constructor(
    injector: Injector,
    private _restaurantFacilityService: RestaurantFacilityServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedRestaurantFacilitysRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._restaurantFacilityService
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
      .subscribe((result: RestaurantFacilityDtoPagedResultDto) => {
        this.restaurantFacilitys = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(restaurantFacility: RestaurantFacilityDto): void {
    abp.message.confirm(
      this.l('RestaurantFacilityDeleteWarningMessage', restaurantFacility.restaurantFacility1),
      undefined,
      (result: boolean) => {
        if (result) {
          this._restaurantFacilityService
            .delete(restaurantFacility.id)
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

  createRestaurantFacility(): void {
    this.showCreateOrEditRestaurantFacilityDialog();
  }

  editRestaurantFacility(restaurantFacility: RestaurantFacilityDto): void {
    this.showCreateOrEditRestaurantFacilityDialog(restaurantFacility.id);
  }

  showCreateOrEditRestaurantFacilityDialog(id?: number): void {
    let createOrEditRestaurantFacilityDialog: BsModalRef;
    if (!id) {
      createOrEditRestaurantFacilityDialog = this._modalService.show(
        CreateRestaurantFacilityDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditRestaurantFacilityDialog = this._modalService.show(
        EditRestaurantFacilityDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditRestaurantFacilityDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
