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
  AdvertisementDateDto,
  AdvertisementDateServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-advDate-dialog.component.html'
})
export class CreateAdvDateDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  advDate: AdvertisementDateDto = new AdvertisementDateDto();
  currentDate

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _advDateService: AdvertisementDateServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
     this.currentDate = new Date().toISOString().substring(0, 16);
     console.log(this.currentDate);
  }

  save(): void {
    this.saving = true;

    this._advDateService
      .create(this.advDate)
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
