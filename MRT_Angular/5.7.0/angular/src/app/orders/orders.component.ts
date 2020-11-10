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
  RestaurantDto,
  QrCodeDto,
  RestaurantServiceProxy,
  QrCodeServiceProxy,
  RestaurantDtoPagedResultDto,
  QrCodeDtoPagedResultDto,
  OrderDtoListResultDto,
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
  restaurants:RestaurantDto[]=[];
  qrCodes:QrCodeDto[]=[];
  resId;
  resIdSelected:boolean = false;
  selectedQrCodes:QrCodeDto[]=[];
  qrCode:QrCodeDto= new QrCodeDto();
  selectedOrders:OrderDto[]=[];
  selectedOrder:OrderDto= new OrderDto();
  filteredQrCodes:QrCodeDto[]=[];
  finalOrders:OrderDto[]=[];
  finalOrders2:OrderDto[]=[];



  constructor(
    injector: Injector,
    private _orderService: OrderServiceProxy,
    private _modalService: BsModalService,
    private _router: Router,
    private _orderLineService: OrderLineServiceProxy,
    private _restaurantService: RestaurantServiceProxy,
    private _qrCodeService: QrCodeServiceProxy
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

    //this.resIdSelected = false;

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
        console.log('orders', this.orders);
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

      this._qrCodeService
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
      .subscribe((result: QrCodeDtoPagedResultDto) => {
        this.qrCodes = result.items;
      });


  }

  viewOrders(resId){
    this.selectedQrCodes = [];
    this.finalOrders = [];
    this.filteredQrCodes = [];


      for(let y=0;y<this.qrCodes.length;y++){
        if(resId == this.qrCodes[y].restaurantIdFk){
          this.qrCode = this.qrCodes[y];
          console.log('selected qrCode',this.qrCode);
          this.selectedQrCodes.push(this.qrCode);
        }
      }
      this.filterQrCodes(this.selectedQrCodes);
      console.log('selected QrCodes', this.filteredQrCodes);

      this.resIdSelected = true;


  }

  getOrdersByQrCodeId(qrCodes){
    for(let x=0;x<qrCodes.length;x++){
      this._orderService
      .getOrderByQrCodeId(this.qrCodes[x].id)
      .subscribe((result:OrderDtoListResultDto)=>{
        this.selectedOrders = result.items;
        for(let y=0;y<this.selectedOrders.length;y++){
          this.selectedOrder = this.selectedOrders[y];
          this.finalOrders.push(this.selectedOrder);
        }
      })

      console.log('finalOrders', this.finalOrders);
      this.finalOrders2=this.finalOrders;
      console.log('2',this.finalOrders2);
    }

  }

  filterQrCodes(qrCodes:QrCodeDto[]){
    this.filteredQrCodes= this.selectedQrCodes.reduce((arr, item) => {
      let exists = !!arr.find(x => x.id === item.id);
      if(!exists){
          arr.push(item);
      }
      return arr;
  }, []);
  //console.log('filteredOrders',this.filteredOrders);
  this.getOrdersByQrCodeId(this.filteredQrCodes);

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
