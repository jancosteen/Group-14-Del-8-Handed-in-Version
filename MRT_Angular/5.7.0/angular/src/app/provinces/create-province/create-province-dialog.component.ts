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
  CountryDto,
  CountryDtoPagedResultDto,
  CountryServiceProxy,
  ProvinceDto,
  ProvinceServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-province-dialog.component.html'
})
export class CreateProvinceDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  province: ProvinceDto = new ProvinceDto();
  countries: CountryDto[]=[];


  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _provinceService: ProvinceServiceProxy,
    public bsModalRef: BsModalRef,
    public _countryService: CountryServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._countryService
      .getAll(
        '',
        0,
        1000
      )
      .pipe(
        finalize(() => {
          console.log('country');
        })
      )
      .subscribe((result: CountryDtoPagedResultDto) => {
        this.countries = result.items;
        //this.showPaging(result, pageNumber);
      });
  }

  save(): void {
    this.saving = true;

    this._provinceService
      .create(this.province)
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
