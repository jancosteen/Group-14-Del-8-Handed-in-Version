import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  ReservationServiceProxy,
  ReservationDto,
  ReservationDtoPagedResultDto,
  SeatingServiceProxy,
  SeatingDto,
  SeatingDtoPagedResultDto,
  RestaurantServiceProxy,
  RestaurantDto,
  RestaurantDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateReservationDialogComponent } from './create-reservation/create-reservation-dialog.component';
import { EditReservationDialogComponent } from './edit-reservation/edit-reservation-dialog.component';

class PagedReservationsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './reservations.component.html',
  animations: [appModuleAnimation()]
})
export class ReservationsComponent extends PagedListingComponentBase<ReservationDto> {
  reservations: ReservationDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText: string;
  isRelated=false;
  seatings: SeatingDto[]=[];
  dateTest;
  resIdSelected:boolean;
  restaurants:RestaurantDto[]=[];
  resId:number;
  selectedReservations:ReservationDto[]=[];
  reservation:ReservationDto = new ReservationDto();

  constructor(
    injector: Injector,
    private _reservationService: ReservationServiceProxy,
    private _modalService: BsModalService,
    private _seatingService: SeatingServiceProxy,
    private _restaurantService: RestaurantServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedReservationsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this.resIdSelected = false;

    this._reservationService
      .getAll(
        request.keyword,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: ReservationDtoPagedResultDto) => {
        this.reservations = result.items;
        this.showPaging(result, pageNumber);
        //this.dateTest = this.reservations[0].creationTime.
      });
      console.log(this.appSession.userId);

      this._seatingService
      .getAll(
        '',
        0,
        1000
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: SeatingDtoPagedResultDto) => {
        this.seatings = result.items;
      });

      this._restaurantService
        .getAll(
          '',
        0,
        1000
        )
        .pipe(
          finalize(() => {
            finishedCallback();
          })
        )
        .subscribe((result: RestaurantDtoPagedResultDto) => {
          this.restaurants = result.items;
        });

  }

  checkIfRelated(id){
    for(let x=0;x<this.restaurants.length;x++){
      if(this.restaurants[x].id === id){
        this.isRelated=true;
        console.log(this.isRelated);
      }
    }
  }

  viewReservations(resId){
    this.selectedReservations = [];
    for(let x=0;x<this.reservations.length;x++){
      if(this.reservations[x].restaurantIdFk == resId){
        this.reservation = this.reservations[x];
        this.selectedReservations.push(this.reservation);
      }
    }
    console.log('selected Reservations', this.selectedReservations);
    this.resIdSelected = true;
  }

  delete(reservation: ReservationDto): void {
    this.checkIfRelated(reservation.restaurantIdFk);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete Reservation, it has related table bookings', reservation.id)
      )
    }
    if(this.isRelated === false){
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', reservation.id),
      undefined,
      (result: boolean) => {
        if (result) {
          this._reservationService
            .delete(reservation.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
    }
  }

  createReservation(): void {
    this.showCreateOrEditReservationDialog();
  }

  editReservation(reservation: ReservationDto): void {
    this.showCreateOrEditReservationDialog(reservation.id);
  }

  showCreateOrEditReservationDialog(id?: number): void {
    let createOrEditReservationDialog: BsModalRef;
    if (!id) {
      createOrEditReservationDialog = this._modalService.show(
        CreateReservationDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditReservationDialog = this._modalService.show(
        EditReservationDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditReservationDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
