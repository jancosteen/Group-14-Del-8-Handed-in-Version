import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  AdvertisementDateServiceProxy,
  AdvertisementDateDto,
  AdvertisementDateDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateAdvDateDialogComponent } from './create-advDate/create-advDate-dialog.component';
import { EditAdvDateDialogComponent } from './edit-advDate/edit-advDate-dialog.component';

class PagedAdvDatesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './advDates.component.html',
  animations: [appModuleAnimation()]
})
export class AdvDatesComponent extends PagedListingComponentBase<AdvertisementDateDto> {
  advDates: AdvertisementDateDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText:string;

  constructor(
    injector: Injector,
    private _advDateService: AdvertisementDateServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedAdvDatesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._advDateService
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
      .subscribe((result: AdvertisementDateDtoPagedResultDto) => {
        this.advDates = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(advDate: AdvertisementDateDto): void {
    abp.message.confirm(
      this.l('AdvDateDeleteWarningMessage', advDate.id),
      undefined,
      (result: boolean) => {
        if (result) {
          this._advDateService
            .delete(advDate.id)
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

  createAdvDate(): void {
    this.showCreateOrEditAdvDateDialog();
  }

  editAdvDate(advDate: AdvertisementDateDto): void {
    this.showCreateOrEditAdvDateDialog(advDate.id);
  }

  showCreateOrEditAdvDateDialog(id?: number): void {
    let createOrEditAdvDateDialog: BsModalRef;
    if (!id) {
      createOrEditAdvDateDialog = this._modalService.show(
        CreateAdvDateDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditAdvDateDialog = this._modalService.show(
        EditAdvDateDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditAdvDateDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
