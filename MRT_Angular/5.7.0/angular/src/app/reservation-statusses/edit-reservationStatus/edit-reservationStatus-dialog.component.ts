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
  ReservationStatusServiceProxy,
  ReservationStatusDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-reservationStatus-dialog.component.html'
})
export class EditReservationStatusDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  reservationStatus: ReservationStatusDto = new ReservationStatusDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _reservationStatusService: ReservationStatusServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._reservationStatusService.get(this.id).subscribe((result: ReservationStatusDto) => {
      this.reservationStatus = result;
    });
  }

  save(): void {
    this.saving = true;

    this._reservationStatusService
      .update(this.reservationStatus)
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
