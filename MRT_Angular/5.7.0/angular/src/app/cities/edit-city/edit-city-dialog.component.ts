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
  CityServiceProxy,
  CityDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-city-dialog.component.html'
})
export class EditCityDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  city: CityDto = new CityDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _cityService: CityServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._cityService.get(this.id).subscribe((result: CityDto) => {
      this.city = result;
    });
  }

  save(): void {
    this.saving = true;

    this._cityService
      .update(this.city)
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
