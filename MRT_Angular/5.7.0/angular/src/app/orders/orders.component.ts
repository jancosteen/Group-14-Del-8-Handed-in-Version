import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  OrderServiceProxy,
  OrderDto,
  OrderDtoPagedResultDto,
  OrderLineServiceProxy,
  OrderLineDto,
  OrderLineDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateOrderDialogComponent } from './create-order/create-order-dialog.component';
import { EditOrderDialogComponent } from './edit-order/edit-order-dialog.component';
import { Router } from '@angular/router';

class PagedOrdersRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './orders.component.html',
  animations: [appModuleAnimation()]
})
export class OrdersComponent extends PagedListingComponentBase<OrderDto> {
  orders: OrderDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText: string;
  isRelated=false;
  orderLines:OrderLineDto[]=[];


  constructor(
    injector: Injector,
    private _orderService: OrderServiceProxy,
    private _modalService: BsModalService,
    private _router: Router,
    private _orderLineService: OrderLineServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedOrdersRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._orderService
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
      .subscribe((result: OrderDtoPagedResultDto) => {
        this.orders = result.items;
        this.showPaging(result, pageNumber);
      });

      this._orderLineService
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
      .subscribe((result: OrderLineDtoPagedResultDto) => {
        this.orderLines = result.items;

      });
  }

  checkIfRelated(id){
    for(let x=0;x<this.orderLines.length;x++){
      if(this.orderLines[x].orderIdFk === id){
        this.isRelated=true;
        console.log(this.isRelated);
    }
  }
  }

  delete(order: OrderDto): void {
    this.checkIfRelated(order.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete Order, it has related orderLines', order.id)
      )
    }
    if(this.isRelated === false){
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', order.id),
      undefined,
      (result: boolean) => {
        if (result) {
          this._orderService
            .delete(order.id)
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

  createOrder(): void {
    this.showCreateOrEditOrderDialog();
  }

  editOrder(order: OrderDto): void {
    this.showCreateOrEditOrderDialog(order.id);
  }

  showCreateOrEditOrderDialog(id?: number): void {
    let createOrEditOrderDialog: BsModalRef;
    if (!id) {
      createOrEditOrderDialog = this._modalService.show(
        CreateOrderDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditOrderDialog = this._modalService.show(
        EditOrderDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditOrderDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  viewOrder(order:OrderDto): void {
    const detailsUrl: string = `/app/order/${order.id}`;
    this._router.navigate([detailsUrl]);
  }
}
