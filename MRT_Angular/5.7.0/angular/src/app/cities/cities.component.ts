import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  CityServiceProxy,
  CityDto,
  CityDtoPagedResultDto,
  ProvinceDto,
  ProvinceServiceProxy,
  ProvinceDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateCityDialogComponent } from './create-city/create-city-dialog.component';
import { EditCityDialogComponent } from './edit-city/edit-city-dialog.component';

class PagedCitysRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

class CityAndProvince{
  cityId:number;
  cityName:string;
  provinceIdFk:number;
  provinceName:string;
}

@Component({
  templateUrl: './cities.component.html',
  animations: [appModuleAnimation()]
})
export class CitiesComponent extends PagedListingComponentBase<CityDto> {
  citys: CityDto[] = [];
  provinces: ProvinceDto[]=[];
  cityAndProv:CityAndProvince[]=[];
  cAp: CityAndProvince = new CityAndProvince();
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText: string;
  isRelated=false;

  constructor(
    injector: Injector,
    private _cityService: CityServiceProxy,
    private _modalService: BsModalService,
    private _provinceService: ProvinceServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedCitysRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._cityService
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
      .subscribe((result: CityDtoPagedResultDto) => {
        this.citys = result.items;
        this.showPaging(result, pageNumber);
      });

      this._provinceService
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
      .subscribe((result: ProvinceDtoPagedResultDto) => {
        this.provinces = result.items;
      });

      this.createCityAndProv();

  }

  createCityAndProv(){
    for(let x=0;x<this.citys.length;x++){
      for(let y=0;y<this.provinces.length;y++){
        if(this.citys[x].provinceIdFk === this.provinces[y].id){
          this.cAp.cityId = this.citys[x].id;
          this.cAp.cityName = this.citys[x].cityName;
          this.cAp.provinceIdFk = this.citys[x].provinceIdFk;
          this.cAp.provinceName = this.provinces[y].provinceName;
          this.cityAndProv.push(this.cAp);
          console.log(this.cityAndProv);
        }
      }
    }
  }

  checkIfRelated(id){
    /*for(let x=0;x<this.menuItemCities.length;x++){
      if(this.menuItemCities[x].cityIdFk === id){
        this.isRelated=true;
        console.log(this.isRelated);
      }
    }*/
  }

  delete(city: CityDto): void {

    this.checkIfRelated(city.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete City, it has related menu items', city.cityName)
      )
    }
    if(this,this.isRelated === false){
      abp.message.confirm(
        this.l('Are you sure you want to delete this record?', city.cityName),
        undefined,
        (result: boolean) => {
          if (result) {
            this._cityService
              .delete(city.id)
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

  createCity(): void {
    this.showCreateOrEditCityDialog();
  }

  editCity(city: CityDto): void {
    this.showCreateOrEditCityDialog(city.id);
  }

  showCreateOrEditCityDialog(id?: number): void {
    let createOrEditCityDialog: BsModalRef;
    if (!id) {
      createOrEditCityDialog = this._modalService.show(
        CreateCityDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditCityDialog = this._modalService.show(
        EditCityDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditCityDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
