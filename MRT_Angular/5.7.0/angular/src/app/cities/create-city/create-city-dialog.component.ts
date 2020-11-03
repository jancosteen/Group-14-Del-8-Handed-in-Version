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
  CityServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-city-dialog.component.html'
})
export class CreateCityDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  city: CityDto = new CityDto();


  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _cityService: CityServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

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
