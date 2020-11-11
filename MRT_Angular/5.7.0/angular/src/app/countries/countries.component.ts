import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  CountryServiceProxy,
  CountryDto,
  CountryDtoPagedResultDto,
  ProvinceDto,
  RestaurantDto,
  ProvinceServiceProxy,
  RestaurantServiceProxy,
  RestaurantDtoPagedResultDto,
  ProvinceDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateCountryDialogComponent } from './create-country/create-country-dialog.component';
import { EditCountryDialogComponent } from './edit-country/edit-country-dialog.component';

class PagedCountrysRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './countries.component.html',
  animations: [appModuleAnimation()]
})
export class CountriesComponent extends PagedListingComponentBase<CountryDto> {
  countrys: CountryDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText: string;
  isRelated=false;
  provinces:ProvinceDto[]=[];
  restaurants:RestaurantDto[]=[];

  constructor(
    injector: Injector,
    private _countryService: CountryServiceProxy,
    private _modalService: BsModalService,
    private _provinceService:ProvinceServiceProxy,
    private _restaurantService:RestaurantServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedCountrysRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._countryService
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
      .subscribe((result: CountryDtoPagedResultDto) => {
        this.countrys = result.items;
        this.showPaging(result, pageNumber);
      });

      this._restaurantService.getAll(
        '',
        0,
        100
      ).subscribe((result:RestaurantDtoPagedResultDto)=>{
        this.restaurants = result.items;
      })

      this._provinceService.getAll(
        '',
        0,
        100
      ).subscribe((result:ProvinceDtoPagedResultDto)=>{
        this.provinces = result.items;
      })


  }

  checkIfRelated(id){
    for(let x=0;x<this.restaurants.length;x++){
      if(this.restaurants[x].countryIdFk === id){
        this.isRelated=true;
        console.log(this.isRelated);
      }
    }

    for(let x=0;x<this.provinces.length;x++){
      if(this.provinces[x].countryIdFk === id){
        this.isRelated=true;
        console.log(this.isRelated);
      }
    }
  }

  delete(country: CountryDto): void {

    this.checkIfRelated(country.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete Country, it has related items', country.countryName)
      )
    }
    if(this,this.isRelated === false){
      abp.message.confirm(
        this.l('Are you sure you want to delete this record?', country.countryName),
        undefined,
        (result: boolean) => {
          if (result) {
            this._countryService
              .delete(country.id)
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

  createCountry(): void {
    this.showCreateOrEditCountryDialog();
  }

  editCountry(country: CountryDto): void {
    this.showCreateOrEditCountryDialog(country.id);
  }

  showCreateOrEditCountryDialog(id?: number): void {
    let createOrEditCountryDialog: BsModalRef;
    if (!id) {
      createOrEditCountryDialog = this._modalService.show(
        CreateCountryDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditCountryDialog = this._modalService.show(
        EditCountryDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditCountryDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
