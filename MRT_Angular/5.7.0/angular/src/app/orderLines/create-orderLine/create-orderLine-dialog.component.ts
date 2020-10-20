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
  ConfigurationServiceProxy,
  MenuItemDto,
  MenuItemDtoPagedResultDto,
  MenuItemServiceProxy,
  OrderLineDto,
  OrderLineDtoListResultDto,
  OrderLineServiceProxy
} from '../../../shared/service-proxies/service-proxies';
import { Router } from '@angular/router';

export class lineAmount{
  menuItem:MenuItemDto;
  itemQty?:number;
  total?:number;
}

@Component({
  templateUrl: 'create-orderLine-dialog.component.html'
})

export class CreateOrderLineDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  orderLine: OrderLineDto = new OrderLineDto();
  addedOrderLine: OrderLineDto = new OrderLineDto();
  menuItems: MenuItemDto[]=[];
  public searchText: string;
  loading = true;
  selectedMenuItems: MenuItemDto[]=[];
  selectedOL:OrderLineDto[]=[];
  lineAmounts : lineAmount[]=[];
  lineAmount: lineAmount = new lineAmount();
  orderId:number;
  itemQuantity:number;
  clicked = false;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _orderLineService: OrderLineServiceProxy,
    //public bsModalRef: BsModalRef,
    public _menuItemService: MenuItemServiceProxy,
    public _router:Router
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.orderId =+ localStorage.getItem('orderId')
    console.log(this.orderId);


    this._menuItemService
      .getAll(
        '',
        0,
        1000
      )
      .pipe(
        finalize(() => {
          console.log('menuItemsPipe');
        })
      )
      .subscribe((result: MenuItemDtoPagedResultDto) => {
        this.menuItems = result.items;
        this.loading = false;
        console.log(this.menuItems);

      });

      this._orderLineService
        .getOrderLineByOrderId(this.orderId).subscribe((results:OrderLineDtoListResultDto)=>{
          this.selectedOL = results.items;
        })
  }

  addItem(item: MenuItemDto, ItemQty){

      this.lineAmount.menuItem = item;
      this.lineAmount.itemQty = ItemQty;
      this.lineAmount.total = this.lineAmount.menuItem.menuItemPriceIdFkNavigation.menuItemPrice1 * ItemQty;

      console.log('lineAmount',this.lineAmount);
      this.lineAmounts.push(this.lineAmount);
      console.log(this.lineAmounts);
  }

  delete(orderLine: OrderLineDto): void {
    abp.message.confirm(
      this.l('OrderDeleteWarningMessage', orderLine.id),
      undefined,
      (result: boolean) => {
        if (result) {
          this._orderLineService
            .delete(orderLine.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this._orderLineService
                  .getOrderLineByOrderId(this.orderId).subscribe((results:OrderLineDtoListResultDto)=>{
                  this.selectedOL = results.items;
        })
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  save(item: MenuItemDto, qty): void {
    this.saving = true;

    this.orderLine.orderIdFk = this.orderId;
    this.orderLine.menuItemIdFk = item.id;
    this.orderLine.userIdFk = this.appSession.userId;
    this.orderLine.itemQty = qty;

    this._orderLineService
      .create(this.orderLine)
      .pipe(
        finalize(() => {
          this.saving = false;
          this._orderLineService
        .getOrderLineByOrderId(this.orderId).subscribe((results:OrderLineDtoListResultDto)=>{
          this.selectedOL = results.items;
        })
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
      });
  }

  viewOrder(): void {
    const detailsUrl: string = `/app/order/${this.orderId}`;
    this._router.navigate([detailsUrl]);
  }



}
