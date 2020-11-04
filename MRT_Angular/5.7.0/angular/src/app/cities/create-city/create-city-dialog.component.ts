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
  CityDto,
  CityServiceProxy,
  ProvinceDto,
  ProvinceDtoPagedResultDto,
  ProvinceServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-city-dialog.component.html'
})
export class CreateCityDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  city: CityDto = new CityDto();
  provinces: ProvinceDto[]=[];


  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _cityService: CityServiceProxy,
    public bsModalRef: BsModalRef,
    public _provinceService: ProvinceServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
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
    .subscribe((result: ProvinceDtoPagedResultDto) => {
      this.provinces = result.items;
      //this.showPaging(result, pageNumber);
    });
  }

  save(): void {
    this.saving = true;

    this._cityService
      .create(this.city)
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
