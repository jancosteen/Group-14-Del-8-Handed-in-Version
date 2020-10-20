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
  AdvertisementDateServiceProxy,
  AdvertisementDateDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-advDate-dialog.component.html'
})
export class EditAdvDateDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  advDate: AdvertisementDateDto = new AdvertisementDateDto();
  id: number;
  currentDate;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _advDateService: AdvertisementDateServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._advDateService.get(this.id).subscribe((result: AdvertisementDateDto) => {
      this.advDate = result;
    });

    this.currentDate = new Date().toISOString().substring(0, 16);
  }

  save(): void {
    this.saving = true;

    this._advDateService
      .update(this.advDate)
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
