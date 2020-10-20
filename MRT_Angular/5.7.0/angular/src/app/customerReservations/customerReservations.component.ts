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
} from '../../shared/service-proxies/service-proxies';
import { CreateCustomerReservationDialogComponent } from './create-customerReservation/create-customerReservation-dialog.component';
import { EditCustomerReservationDialogComponent } from './edit-customerReservation/edit-customerReservation-dialogcomponent';

class PagedCustomerCustomerReservationsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './customerReservations.component.html',
  animations: [appModuleAnimation()]
})
export class CustomerReservationsComponent extends PagedListingComponentBase<ReservationDto> {
  reservations: ReservationDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText: string;
  userId;
  upcomingReservations: ReservationDto[]=[];
  pastReservations: ReservationDto[]=[];
  currentDate;
  userName;

  constructor(
    injector: Injector,
    private _ReservationService: ReservationServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedCustomerCustomerReservationsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;
    this.currentDate = new Date().toISOString().substring(0, 16);
    this._ReservationService
      .getReservationByUserId(this.appSession.userId)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: ReservationDtoPagedResultDto) => {
        this.reservations = result.items;
        this.populateUpcomingOrPastReservations();
        this.showPaging(result, pageNumber);
      });
      console.log(this.appSession.userId);

      this.userName=this.appSession.user.userName;

  }

  populateUpcomingOrPastReservations(){
    this.pastReservations = [];
    this.upcomingReservations = [];
    for(let x=0;x<this.reservations.length;x++){
      if(this.reservations[x].reservationDateReserved > this.currentDate ){
        this.upcomingReservations.push(this.reservations[x]);
      }else{
        this.pastReservations.push(this.reservations[x]);
      }
    }
    console.log("upcomingRes", this.upcomingReservations);
    console.log("past", this.pastReservations);
  }

  delete(customerReservation: ReservationDto): void {
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', customerReservation.id),
      undefined,
      (result: boolean) => {
        if (result) {
          this._ReservationService
            .delete(customerReservation.id)
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

  createCustomerReservation(): void {
    this.showCreateOrEditCustomerReservationDialog();
  }

  editCustomerReservation(reservation: ReservationDto): void {
    this.showCreateOrEditCustomerReservationDialog(reservation.id);
  }

  showCreateOrEditCustomerReservationDialog(id?: number): void {
    let createOrEditCustomerReservationDialog: BsModalRef;
    if (!id) {
      createOrEditCustomerReservationDialog = this._modalService.show(
        CreateCustomerReservationDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditCustomerReservationDialog = this._modalService.show(
        EditCustomerReservationDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditCustomerReservationDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
