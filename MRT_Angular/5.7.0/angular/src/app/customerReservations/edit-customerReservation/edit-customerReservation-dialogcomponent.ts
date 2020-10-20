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
  ReservationServiceProxy,
  ReservationDto, RestaurantDtoPagedResultDto, RestaurantServiceProxy, RestaurantDto, ReservationStatusDto, ReservationStatusDtoPagedResultDto, ReservationStatusServiceProxy
} from '../../../shared/service-proxies/service-proxies';
import { AppSessionService } from '@shared/session/app-session.service';

@Component({
  templateUrl: 'edit-customerReservation-dialog.component.html'
})
export class EditCustomerReservationDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  reservation: ReservationDto = new ReservationDto();
  id: number;
  sUserId:string;
  iUserId:number;
  currentDate;
  restaurants: RestaurantDto[] = [];
  reservationStatusses: ReservationStatusDto[]=[];
  defaultResStatusID:number = 1;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _reservationService: ReservationServiceProxy,
    public _restaurantService: RestaurantServiceProxy,
    public _reservationStatusService : ReservationStatusServiceProxy,
    public sessionService: AppSessionService,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._reservationService.get(this.id).subscribe((result: ReservationDto) => {
      this.reservation = result;
    });
    this.sUserId = localStorage.getItem('userId');
    this.iUserId = this.sessionService.userId;
    this.currentDate = new Date().toISOString().substring(0, 16);
     console.log(this.currentDate);
     this.reservation.reservationDateCreated = this.currentDate;
     this.reservation.userIdFk=this.iUserId;
    this._restaurantService
    .getAll(
      '',
      0,
      100
    )
    .pipe(
      finalize(() => {
        console.log('pipe');
      })
    )
    .subscribe((result: RestaurantDtoPagedResultDto) => {
      this.restaurants = result.items;
      //this.showPaging(result, pageNumber);
    });

    this._reservationStatusService
    .getAll(
      '',
      0,
      100
    )
    .pipe(
      finalize(() => {
        console.log(this.iUserId);
      })
    )
    .subscribe((result: ReservationStatusDtoPagedResultDto) => {
      this.reservationStatusses = result.items;
      //this.showPaging(result, pageNumber);
    });
  }

  save(): void {

    abp.message.success(
      this.l("Successfully Updated Reservation")
    );
    this.saving = true;

    this.reservation.reservationStatusIdFk=1;
    this._reservationService
      .update(this.reservation)
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
