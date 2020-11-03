import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  ProvinceServiceProxy,
  ProvinceDto,
  ProvinceDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateProvinceDialogComponent } from './create-province/create-province-dialog.component';
import { EditProvinceDialogComponent } from './edit-province/edit-province-dialog.component';

class PagedProvincesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './provinces.component.html',
  animations: [appModuleAnimation()]
})
export class ProvincesComponent extends PagedListingComponentBase<ProvinceDto> {
  provinces: ProvinceDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText: string;
  isRelated=false;

  constructor(
    injector: Injector,
    private _provinceService: ProvinceServiceProxy,
    private _modalService: BsModalService,
  ) {
    super(injector);
  }

  list(
    request: PagedProvincesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._provinceService
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
      .subscribe((result: ProvinceDtoPagedResultDto) => {
        this.provinces = result.items;
        this.showPaging(result, pageNumber);
      });


  }

  checkIfRelated(id){
    /*for(let x=0;x<this.menuItemProvinces.length;x++){
      if(this.menuItemProvinces[x].provinceIdFk === id){
        this.isRelated=true;
        console.log(this.isRelated);
      }
    }*/
  }

  delete(province: ProvinceDto): void {

    this.checkIfRelated(province.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete Province, it has related menu items', province.provinceName)
      )
    }
    if(this,this.isRelated === false){
      abp.message.confirm(
        this.l('Are you sure you want to delete this record?', province.provinceName),
        undefined,
        (result: boolean) => {
          if (result) {
            this._provinceService
              .delete(province.id)
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

  createProvince(): void {
    this.showCreateOrEditProvinceDialog();
  }

  editProvince(province: ProvinceDto): void {
    this.showCreateOrEditProvinceDialog(province.id);
  }

  showCreateOrEditProvinceDialog(id?: number): void {
    let createOrEditProvinceDialog: BsModalRef;
    if (!id) {
      createOrEditProvinceDialog = this._modalService.show(
        CreateProvinceDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditProvinceDialog = this._modalService.show(
        EditProvinceDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditProvinceDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
