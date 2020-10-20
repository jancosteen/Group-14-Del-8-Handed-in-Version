import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  SeatingServiceProxy,
  SeatingDto,
  SeatingDtoPagedResultDto,
  ReservationDto,
  ReservationServiceProxy,
  ReservationDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateSeatingDialogComponent } from './create-seating/create-seating-dialog.component';
import { EditSeatingDialogComponent } from './edit-seating/edit-seating-dialog.component';

class PagedSeatingsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './seatings.component.html',
  animations: [appModuleAnimation()]
})
export class SeatingsComponent extends PagedListingComponentBase<SeatingDto> {
  seatings: SeatingDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText: string;
  isRelated=false;
  reservations:ReservationDto[]=[];

  constructor(
    injector: Injector,
    private _seatingService: SeatingServiceProxy,
    private _modalService: BsModalService,
    private _reservationService: ReservationServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedSeatingsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._seatingService
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
      .subscribe((result: SeatingDtoPagedResultDto) => {
        this.seatings = result.items;
        this.showPaging(result, pageNumber);
      });

      this._reservationService
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
      .subscribe((result: ReservationDtoPagedResultDto) => {
        this.reservations = result.items;

      });
  }

  checkIfRelated(id){
    for(let x=0;x<this.reservations.length;x++){
      for(let y=0;y<this.reservations[x].seating.length;y++){
        if(this.reservations[x].seating[y].id === id){
          this.isRelated=true;
          console.log(this.isRelated);
        }
      }
    }
  }

  delete(seating: SeatingDto): void {
    this.checkIfRelated(seating.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete Category, it has related menu items', seating.id)
      )
    }
    if(this.isRelated === false){
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', seating.id),
      undefined,
      (result: boolean) => {
        if (result) {
          this._seatingService
            .delete(seating.id)
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

  createSeating(): void {
    this.showCreateOrEditSeatingDialog();
  }

  editSeating(seating: SeatingDto): void {
    this.showCreateOrEditSeatingDialog(seating.id);
  }

  showCreateOrEditSeatingDialog(id?: number): void {
    let createOrEditSeatingDialog: BsModalRef;
    if (!id) {
      createOrEditSeatingDialog = this._modalService.show(
        CreateSeatingDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditSeatingDialog = this._modalService.show(
        EditSeatingDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditSeatingDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
