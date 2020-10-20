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
  MenuItemCategoryServiceProxy,
  MenuItemCategoryDto,
  OrderServiceProxy,
  OrderLineServiceProxy,
  OrderDto,
  OrderLineDto
} from '../../../shared/service-proxies/service-proxies';
import { AppSessionService } from '@shared/session/app-session.service';
import { timeStamp } from 'console';

@Component({
  templateUrl: 'cartModal.component.html'
})
export class CartModalComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  menuItemCategory: MenuItemCategoryDto = new MenuItemCategoryDto();
  id: number;
  order: OrderDto = new OrderDto();
  orderLine: OrderLineDto = new OrderLineDto();
  orderLines:OrderLineDto[]=[];
  tempOrderId:string;
  currentDate;
  sDate:string;
  iOrderId:number;

  cart=[];
  cartTotal:number=0;
  cartCount:number=0;
  orderId = 0;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuItemCategoryService: MenuItemCategoryServiceProxy,
    public bsModalRef: BsModalRef,
    public _sessionService: AppSessionService,
    public _orderService: OrderServiceProxy,
    public _orderLineService: OrderLineServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.cart = this._sessionService.getCart();
    console.log(this.cart);
    this.currentDate = new Date().toISOString().substring(0, 16);
    this.sDate = this.currentDate.toString();
    console.log('date',this.currentDate);
    this.calculateTotal();
    this.orderId =+ localStorage.getItem('orderId');
    console.log('orderId',this.orderId);
  }

  decreaseItem(x){
    this._sessionService.decreaseProduct(x);
    this.calculateTotal();
    this.cartCount = this._sessionService.getCartItemCount();
    console.log(this.cart);
  }

  calculateTotal(){
    this.cartTotal = 0;
    if(this.cart.length === 0){
      this.cartTotal = 0;
    }
    for(let x=0;x<this.cart.length;x++){
      this.cartTotal += this.cart[x].item.menuItemPriceIdFkNavigation.menuItemPrice1 * this.cart[x].qty;
    }
    console.log(this.cartTotal);
  }

  createOrderLines(orderId){
    this.orderLine.orderIdFk = orderId;
    this.orderLine.userIdFk = this._sessionService.userId;

    for(let x=0;x<this.cart.length;x++){
      this.orderLine.menuItemIdFk = this.cart[x].item.id;
      this.orderLine.itemQty = this.cart[x].qty;

      this._orderLineService
        .create(this.orderLine)
        .pipe(
          finalize(()=>{
            console.log("orderLinePipe");
          })
        )
        .subscribe((result)=>{
          console.log('orderLine Id',result.id);
          this.bsModalRef.hide();
          this.onSave.emit()
        });


    }
  }

  sendToKitchen(){
    abp.message.success(
      this.l("Order Sent To The Kitchen")
    );
    if(this.orderId === 0){
        this.order.orderDateCreated = this.sDate;
        this.order.qrCodeSeatingIdFk = 1;
        this.order.orderStatusIdFk = 1;
      this._orderService
        .create(this.order)
        .pipe(
          finalize(() => {
            console.log('Orderpipe');
          })
        )
        .subscribe((result) => {
          this.iOrderId = result.id;
          this.tempOrderId = this.iOrderId.toString();
          localStorage.setItem('orderId', this.tempOrderId)
          this.notify.info(this.l('SavedSuccessfully'));
          console.log(this.tempOrderId);
          this.onSave.emit();
          this.createOrderLines(result.id);
        });
    }if(this.orderId !=0){
      this.createOrderLines(this.orderId);
    }

    this._sessionService.clearCart();
  }

  save(): void {
    this.saving = true;
  }
}
