import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  RestaurantTypeServiceProxy,
  RestaurantTypeDto,
  RestaurantTypeDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateRestaurantTypeDialogComponent } from './create-restaurantType/create-restaurantType-dialog.component';
import { EditRestaurantTypeDialogComponent } from './edit-restaurantType/edit-restaurantType-dialog.component';

class PagedRestaurantTypesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './restaurantTypes.component.html',
  animations: [appModuleAnimation()]
})
export class RestaurantTypesComponent extends PagedListingComponentBase<RestaurantTypeDto> {
  restaurantTypes: RestaurantTypeDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  searchText:string;

  constructor(
    injector: Injector,
    private _restaurantTypeService: RestaurantTypeServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedRestaurantTypesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._restaurantTypeService
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
      .subscribe((result: RestaurantTypeDtoPagedResultDto) => {
        this.restaurantTypes = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(restaurantType: RestaurantTypeDto): void {
    abp.message.confirm(
      this.l('RestaurantTypeDeleteWarningMessage', restaurantType.restaurantType1),
      undefined,
      (result: boolean) => {
        if (result) {
          this._restaurantTypeService
            .delete(restaurantType.id)
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

  createRestaurantType(): void {
    this.showCreateOrEditRestaurantTypeDialog();
  }

  editRestaurantType(restaurantType: RestaurantTypeDto): void {
    this.showCreateOrEditRestaurantTypeDialog(restaurantType.id);
  }

  showCreateOrEditRestaurantTypeDialog(id?: number): void {
    let createOrEditRestaurantTypeDialog: BsModalRef;
    if (!id) {
      createOrEditRestaurantTypeDialog = this._modalService.show(
        CreateRestaurantTypeDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditRestaurantTypeDialog = this._modalService.show(
        EditRestaurantTypeDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditRestaurantTypeDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
