import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  QrCodeServiceProxy,
  QrCodeDto,
  QrCodeDtoPagedResultDto,
  QrCodeSeatingServiceProxy,
  QrCodeSeatingDto,
  QrCodeSeatingDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateQrCodeDialogComponent } from './create-qrCode/create-qrCode-dialog.component';
import { EditQrCodeDialogComponent } from './edit-qrCode/edit-qrCode-dialog.component';

class PagedQrCodesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './qrCodes.component.html',
  animations: [appModuleAnimation()]
})
export class QrCodesComponent extends PagedListingComponentBase<QrCodeDto> {
  qrCodes: QrCodeDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText: string;
  qrCodeSeatings: QrCodeSeatingDto[]=[];
  isRelated:boolean;

  constructor(
    injector: Injector,
    private _qrCodeService: QrCodeServiceProxy,
    private _modalService: BsModalService,
    private _qrCodeSeatingService: QrCodeSeatingServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedQrCodesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this.isRelated=false;

    this._qrCodeService
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
      .subscribe((result: QrCodeDtoPagedResultDto) => {
        this.qrCodes = result.items;
        this.showPaging(result, pageNumber);
      });

      this._qrCodeSeatingService
        .getAll(
          '',
          0,
          100
        ).subscribe((result:QrCodeSeatingDtoPagedResultDto)=>{
          this.qrCodeSeatings = result.items;
        })
  }

  checkIfRelated(id){
    for(let x=0;x<this.qrCodeSeatings.length;x++){
        if(this.qrCodeSeatings[x].qrCodeIdFk === id){
          this.isRelated=true;
          console.log(this.isRelated);
        }
    }
  }

  delete(qrCode: QrCodeDto): void {
    this.checkIfRelated(qrCode.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete Category, it has related tables', qrCode.id)
      )
    }
    if(this.isRelated === false){
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', qrCode.id),
      undefined,
      (result: boolean) => {
        if (result) {
          this._qrCodeService
            .delete(qrCode.id)
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

  createQrCode(): void {
    this.showCreateOrEditQrCodeDialog();
  }

  editQrCode(qrCode: QrCodeDto): void {
    this.showCreateOrEditQrCodeDialog(qrCode.id);
  }

  showCreateOrEditQrCodeDialog(id?: number): void {
    let createOrEditQrCodeDialog: BsModalRef;
    if (!id) {
      createOrEditQrCodeDialog = this._modalService.show(
        CreateQrCodeDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditQrCodeDialog = this._modalService.show(
        EditQrCodeDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditQrCodeDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
