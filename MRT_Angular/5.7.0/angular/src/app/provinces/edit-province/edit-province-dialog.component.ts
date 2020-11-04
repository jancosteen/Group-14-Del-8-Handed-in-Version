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
  ProvinceServiceProxy,
  ProvinceDto,
  CountryDtoPagedResultDto,
  CountryDto,
  CountryServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-province-dialog.component.html'
})
export class EditProvinceDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  province: ProvinceDto = new ProvinceDto();
  id: number;
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
    this._provinceService.get(this.id).subscribe((result: ProvinceDto) => {
      this.province = result;
    });

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
      .update(this.province)
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
