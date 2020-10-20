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
  SeatingServiceProxy,
  SeatingDto, ReservationServiceProxy, ReservationDtoPagedResultDto, ReservationDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-seating-dialog.component.html'
})
export class EditSeatingDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  seating: SeatingDto = new SeatingDto();
  id: number;
  currentDate;
  currentTime;
  reservations: ReservationDto[]=[];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _seatingService: SeatingServiceProxy,
    public _reservationService: ReservationServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._seatingService.get(this.id).subscribe((result: SeatingDto) => {
      this.seating = result;
    });

    this.currentDate = new Date().toISOString().substring(0, 16);
    this.currentTime = Date.now();

    this._reservationService
      .getAll(
        '',
        0,
        100
      )
      .pipe(
        finalize(() => {
          console.log('reservations')
        })
      )
      .subscribe((result: ReservationDtoPagedResultDto) => {
        this.reservations = result.items;
        //this.showPaging(result, pageNumber);
      });
  }

  save(): void {
    this.saving = true;

    this._seatingService
      .update(this.seating)
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
