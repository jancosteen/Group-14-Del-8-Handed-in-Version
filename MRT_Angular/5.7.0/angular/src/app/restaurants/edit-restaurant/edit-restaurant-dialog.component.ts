import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '../../../shared/app-component-base';
import {
  RestaurantServiceProxy,
  RestaurantDto,
  CityDto,
  CountryDto,
  ProvinceDto,
  CityServiceProxy,
  CountryServiceProxy,
  ProvinceServiceProxy,
  CityDtoPagedResultDto,
  CountryDtoPagedResultDto,
  ProvinceDtoPagedResultDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-restaurant-dialog.component.html'
})
export class EditRestaurantDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  restaurant: RestaurantDto = new RestaurantDto();
  id: number;
  provinces: ProvinceDto[]=[];
  cities: CityDto[]=[];
  countries: CountryDto[]=[];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _restaurantService: RestaurantServiceProxy,
    public bsModalRef: BsModalRef,
    public _provinceService:ProvinceServiceProxy,
    public _cityService: CityServiceProxy,
    public _countryService: CountryServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._restaurantService.get(this.id).subscribe((result: RestaurantDto) => {
      this.restaurant = result;
    });

    this._provinceService
      .getAll(
        '',
        0,
        1000
      )
      .pipe(
        finalize(() => {
          console.log('provinces');
        })
      )
      .subscribe((res:ProvinceDtoPagedResultDto) =>{
        this.provinces = res.items;
      });

      this._cityService
      .getAll(
        '',
        0,
        1000
      )
      .pipe(
        finalize(() => {
          console.log('cities');
        })
      )
      .subscribe((res:CityDtoPagedResultDto) =>{
        this.cities = res.items;
      });

      this._countryService
      .getAll(
        '',
        0,
        1000
      )
      .pipe(
        finalize(() => {
          console.log('countries');
        })
      )
      .subscribe((res:CountryDtoPagedResultDto) =>{
        this.countries = res.items;
      });
  }

  save(): void {
    this.saving = true;

    this._restaurantService
      .update(this.restaurant)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
