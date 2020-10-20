import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  AdvertisementPriceServiceProxy,
  AdvertisementPriceDto,
  AdvertisementPriceDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateAdvPriceDialogComponent } from './create-advPrice/create-advPrice-dialog.component';
import { EditAdvPriceDialogComponent } from './edit-advPrice/edit-advPrice-dialog.component';

class PagedAdvPricesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './advPrices.component.html',
  animations: [appModuleAnimation()]
})
export class AdvPricesComponent extends PagedListingComponentBase<AdvertisementPriceDto> {
  advPrices: AdvertisementPriceDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText:string;

  constructor(
    injector: Injector,
    private _advPriceService: AdvertisementPriceServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedAdvPricesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._advPriceService
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
      .subscribe((result: AdvertisementPriceDtoPagedResultDto) => {
        this.advPrices = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(advPrice: AdvertisementPriceDto): void {
    abp.message.confirm(
      this.l('AdvPriceDeleteWarningMessage', advPrice.advertismentPrice),
      undefined,
      (result: boolean) => {
        if (result) {
          this._advPriceService
            .delete(advPrice.id)
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

  createAdvPrice(): void {
    this.showCreateOrEditAdvPriceDialog();
  }

  editAdvPrice(advPrice: AdvertisementPriceDto): void {
    this.showCreateOrEditAdvPriceDialog(advPrice.id);
  }

  showCreateOrEditAdvPriceDialog(id?: number): void {
    let createOrEditAdvPriceDialog: BsModalRef;
    if (!id) {
      createOrEditAdvPriceDialog = this._modalService.show(
        CreateAdvPriceDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditAdvPriceDialog = this._modalService.show(
        EditAdvPriceDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditAdvPriceDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
