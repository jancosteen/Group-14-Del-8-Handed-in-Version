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
  OrderLineDtoListResultDto,
  MenuItemCandUDto,
  OrderServiceProxy,
  OrderDto,

} from '../../shared/service-proxies/service-proxies';
import { CreateViewOrderDialogComponent } from './create-order/create-order-dialog.component';
import { EditViewOrderDialogComponent } from './edit-order/edit-order-dialog.component';
import { NumberValueAccessor } from '@angular/forms';
import { Router } from '@angular/router';

class PagedOrderLinesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './orders.component.html',
  animations: [appModuleAnimation()]
})
export class ViewOrdersComponent extends PagedListingComponentBase<OrderLineDto> {
  orderLines: OrderLineDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText: string;
  isRelated=false;
  sOrderId:string;
  iOrderId:number;
  menuItems;
  total:number;
  sRestaurantId:string;
  iRestaurantId:number;
  totalVat:number=0;
  order: OrderDto= new OrderDto();
  currentDate;

  constructor(
    injector: Injector,
    private _orderLineService: OrderLineServiceProxy,
    private _modalService: BsModalService,
    private _router:Router,
    private _orderService: OrderServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedOrderLinesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    this.sOrderId = localStorage.getItem('orderId');
    this.iOrderId = parseInt(this.sOrderId);
    this.currentDate = new Date().toISOString().substring(0, 16);

    this.sRestaurantId = localStorage.getItem('resId');
    this.iRestaurantId = parseInt(this.sRestaurantId);

    this._orderService
      .get(this.iOrderId)
      .subscribe((result:OrderDto) =>{
        this.order = result;
      })



    this._orderLineService
      .getOrderLineByOrderId(this.iOrderId)
        .subscribe((result:OrderLineDtoListResultDto) =>{
          this.orderLines = result.items;
          this.calculateTotal();
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

  goToMenu(){
    const detailsUrl: string = `/app/cusMenu/${this.iRestaurantId}`;
    this._router.navigate([detailsUrl]);
  }

  calculateTotal(){
    this.total = 0;
    for(let x=0;x<this.orderLines.length;x++){
      this.total += this.orderLines[x].itemQty * this.orderLines[x].menuItemIdFkNavigation.menuItemPrice;
    }
    console.log('total', this.total);
    this.totalVat = this.total * 15/115;
  }

  delete(orderLine: OrderLineDto): void {

    this.checkIfRelated(orderLine.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete OrderLine, it has related menu items', orderLine.id)
      )
    }
    if(this,this.isRelated === false){
      abp.message.confirm(
        this.l('Are you sure you want to delete this record?', orderLine.id),
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
        CreateViewOrderDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditOrderLineDialog = this._modalService.show(
        EditViewOrderDialogComponent,
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

  checkout(){
    this.order.orderStatusIdFk = 3;
    this.order.orderDateCompleted = this.currentDate;

    this._orderService
      .update(this.order)
      .pipe(
        finalize(() => {
          console.log('update pipe')
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('Thank You, Payment Received'));
      });

      this.backToHome();
      localStorage.removeItem('orderId');
      localStorage.removeItem('checkedIn')
  }

  backToHome(): void {
    const detailsUrl: string = `/app/home`;
    this._router.navigate([detailsUrl]);
  }
}
