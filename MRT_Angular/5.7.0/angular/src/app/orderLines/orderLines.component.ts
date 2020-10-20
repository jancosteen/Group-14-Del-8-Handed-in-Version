import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  OrderLineServiceProxy,
  OrderLineDto,
  OrderLineDtoPagedResultDto,
  OrderDto,
  OrderServiceProxy,
  OrderDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateOrderLineDialogComponent } from './create-orderLine/create-orderLine-dialog.component';
import { EditOrderLineDialogComponent } from './edit-orderLine/edit-orderLine-dialog.component';

class PagedOrderLinesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './orderLines.component.html',
  animations: [appModuleAnimation()]
})
export class OrderLinesComponent extends PagedListingComponentBase<OrderLineDto> {
  orderLines: OrderLineDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText: string;
  orders:OrderDto[]=[];
  isRelated=false;

  constructor(
    injector: Injector,
    private _orderLineService: OrderLineServiceProxy,
    private _modalService: BsModalService,
    private _orderService: OrderServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedOrderLinesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._orderLineService
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
      .subscribe((result: OrderLineDtoPagedResultDto) => {
        this.orderLines = result.items;
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
      for(let y=0;y<this.orders[x].orderLine.length;y++)
      if(this.orders[x].orderLine[y].id === id){
        this.isRelated=true;
        console.log(this.isRelated);
      }
    }
  }

  delete(orderLine: OrderLineDto): void {
    this.checkIfRelated(orderLine.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete orderLine, it has related orders', orderLine.id)
      )
    }
    if(this.isRelated === false){
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', orderLine.itemQty),
      undefined,
      (result: boolean) => {
        if (result) {
          this._orderLineService
            .delete(orderLine.id)
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

  createOrderLine(): void {
    this.showCreateOrEditOrderLineDialog();
  }

  editOrderLine(orderLine: OrderLineDto): void {
    this.showCreateOrEditOrderLineDialog(orderLine.id);
  }

  showCreateOrEditOrderLineDialog(id?: number): void {
    let createOrEditOrderLineDialog: BsModalRef;
    if (!id) {
      createOrEditOrderLineDialog = this._modalService.show(
        CreateOrderLineDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditOrderLineDialog = this._modalService.show(
        EditOrderLineDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditOrderLineDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
