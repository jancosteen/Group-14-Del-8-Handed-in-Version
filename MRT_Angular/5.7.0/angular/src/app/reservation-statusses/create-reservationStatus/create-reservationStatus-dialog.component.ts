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
  ReservationStatusDto,
  ReservationStatusServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-reservationStatus-dialog.component.html'
})
export class CreateReservationStatusDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  reservationStatus: ReservationStatusDto = new ReservationStatusDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _reservationStatusService: ReservationStatusServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  save(): void {
    this.saving = true;

    this._reservationStatusService
      .create(this.reservationStatus)
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
