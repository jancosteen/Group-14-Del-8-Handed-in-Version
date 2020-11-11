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
  OrderDtoListResultDto,
  QrCodeDto,
  QrCodeDtoPagedResultDto,
  QrCodeServiceProxy,

} from '../../shared/service-proxies/service-proxies';
import { CreateOrderHistoryDialogComponent } from './create-orderHistory/create-orderHistory-dialog.component';
import { EditOrderHistoryDialogComponent } from './edit-orderHistory/edit-orderHistory-dialog.component';
import { NumberValueAccessor } from '@angular/forms';
import { Router } from '@angular/router';
import { AppSessionService } from '@shared/session/app-session.service';


class PagedOrderLinesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './orderHistory.component.html',
  animations: [appModuleAnimation()]
})
export class OrderHistoryComponent extends PagedListingComponentBase<OrderLineDto> {
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
  userId:number;
  orders: OrderDto[]=[];
  filteredOrders:OrderDto[]=[];
  orderRes: OrderDto[]=[];
  filteredOLs: OrderLineDto[]=[];
  qrCodes: QrCodeDto[]=[];
  qrCode: QrCodeDto = new QrCodeDto();

  constructor(
    injector: Injector,
    private _orderLineService: OrderLineServiceProxy,
    private _modalService: BsModalService,
    private _router:Router,
    private _sessionService: AppSessionService,
    private _orderService: OrderServiceProxy,
    private _qrCodeService: QrCodeServiceProxy

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

    this.sRestaurantId = localStorage.getItem('resId');
    this.iRestaurantId = parseInt(this.sRestaurantId);

    this

    this.userId = this._sessionService.userId
    console.log('userId', this.userId);

    this._orderLineService
    .getOrderLinesByUserIdId(this.userId)
    .subscribe((result:OrderLineDtoListResultDto) =>{
      this.orderLines = result.items;
      console.log('orderLines',this.orderLines);
      this.filteredOrderLines();
      this.calculateTotal();

    });

  }

  getQrCodes(order:OrderDto){
    this._qrCodeService.getAll(
      '',
      0,
      100
    ).pipe(
      finalize(() => {
        console.log('qrCodePipe')
      })
    )
    .subscribe((result: QrCodeDtoPagedResultDto) => {
      this.qrCodes = result.items;
      for(let x=0;x<this.qrCodes.length;x++){
        if(order.qrCodeSeating.qrCodeIdFk == this.qrCodes[x].id){
          this.qrCode = this.qrCodes[x];
          console.log('this.qrCode',this.qrCode);
          break;
        }
      }
    });


  }

  getOrderDetails(){
    for(let x=0;x<this.filteredOLs.length;x++){
      this._orderService.getOrderById(this.filteredOLs[x].orderIdFk)
        .subscribe((result:OrderDtoListResultDto) =>{
          this.orderRes = result.items;
          console.log('orderRes',this.orderRes);
          this.orders.push(this.orderRes[0]);


          this.orders =this.orders.sort((a, b) => {
            return a.id - b.id;
          });
          console.log('getOrderDetails',this.orders);
          //this.filterOrderIds();

          this.getQrCodes(this.orders[0]);
        });
    }

    //console.log('filtered Orders', this.filteredOrders);


  }

  filterOrderIds(){
    this.filteredOrders= this.orders.reduce((arr, item) => {
      let exists = !!arr.find(x => x.id === item.id);
      if(!exists){
          arr.push(item);
      }
      return arr;
  }, []);
  //console.log('filteredOrders',this.filteredOrders);

  }

  filteredOrderLines(){
    this.filteredOLs= this.orderLines.reduce((arr, item) => {
      let exists = !!arr.find(x => x.orderIdFk === item.orderIdFk);
      if(!exists){
          arr.push(item);
      }
      return arr;
  }, []);

    console.log('filtered OLs', this.filteredOLs);
    this.getOrderDetails();
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
    const detailsUrl: string = `/app/qrScan`;
    this._router.navigate([detailsUrl]);
  }

  viewOrder(res:OrderDto): void {
    const detailsUrl: string = `/app/orderHistory/${res.id}`;
    this._router.navigate([detailsUrl]);
  }

  calculateTotal(){
    this.total = 0;
    for(let x=0;x<this.orderLines.length;x++){
      this.total += this.orderLines[x].itemQty * this.orderLines[x].menuItemIdFkNavigation.menuItemPrice;
    }
    console.log('total', this.total);
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
        CreateOrderHistoryDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditOrderLineDialog = this._modalService.show(
        EditOrderHistoryDialogComponent,
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
