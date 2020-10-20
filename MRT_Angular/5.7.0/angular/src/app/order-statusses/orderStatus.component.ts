import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  OrderStatusServiceProxy,
  OrderStatusDto,
  OrderStatusDtoPagedResultDto,
  OrderDto,
  OrderServiceProxy,
  OrderDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateOrderStatusDialogComponent } from './create-orderStatus/create-orderStatus-dialog.component';
import { EditOrderStatusDialogComponent } from './edit-orderStatus/edit-orderStatus-dialog.component';

class PagedOrderStatussRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './orderStatus.component.html',
  animations: [appModuleAnimation()]
})
export class OrderStatussesComponent extends PagedListingComponentBase<OrderStatusDto> {
  orderStatuss: OrderStatusDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText:string;
  isRelated=false;
  orders:OrderDto[]=[];

  constructor(
    injector: Injector,
    private _orderStatusService: OrderStatusServiceProxy,
    private _modalService: BsModalService,
    private _orderService:OrderServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedOrderStatussRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._orderStatusService
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
      .subscribe((result: OrderStatusDtoPagedResultDto) => {
        this.orderStatuss = result.items;
        this.showPaging(result, pageNumber);
      });

      this._orderService
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
      .subscribe((result: OrderDtoPagedResultDto) => {
        this.orders = result.items;

      });
  }

  checkIfRelated(id){
    for(let x=0;x<this.orders.length;x++){
      if(this.orders[x].orderStatusIdFk === id){
        this.isRelated=true;
        console.log(this.isRelated);
      }
    }
  }

  delete(orderStatus: OrderStatusDto): void {
    this.checkIfRelated(orderStatus.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete Order Status, it has related menu items', orderStatus.orderStatus1)
      )
    }
    if(this.isRelated === false){
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', orderStatus.orderStatus1),
      undefined,
      (result: boolean) => {
        if (result) {
          this._orderStatusService
            .delete(orderStatus.id)
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

  createOrderStatus(): void {
    this.showCreateOrEditOrderStatusDialog();
  }

  editOrderStatus(orderStatus: OrderStatusDto): void {
    this.showCreateOrEditOrderStatusDialog(orderStatus.id);
  }

  showCreateOrEditOrderStatusDialog(id?: number): void {
    let createOrEditOrderStatusDialog: BsModalRef;
    if (!id) {
      createOrEditOrderStatusDialog = this._modalService.show(
        CreateOrderStatusDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditOrderStatusDialog = this._modalService.show(
        EditOrderStatusDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditOrderStatusDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
