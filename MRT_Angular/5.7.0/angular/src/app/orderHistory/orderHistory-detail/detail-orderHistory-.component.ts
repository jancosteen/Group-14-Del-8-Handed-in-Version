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
  OrderServiceProxy,
  OrderDto,
  OrderDtoListResultDto,
  QrCodeServiceProxy,
  QrCodeDto,
  QrCodeDtoPagedResultDto
} from '../../../shared/service-proxies/service-proxies';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  templateUrl: 'detail-orderHistory.component.html'
})
export class OrderHistoryDetailComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  order: OrderDto = new OrderDto();
  id: number;
  orders: OrderDto[]=[];
  Iid:number;
  total:number;
  totalVat:number;
  qrCodes: QrCodeDto[]=[];
  qrCode: QrCodeDto = new QrCodeDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _orderService: OrderServiceProxy,
    //public bsModalRef: BsModalRef,
    public _router:Router,
    private activeRoute: ActivatedRoute,
    private _qrCodeService: QrCodeServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    let id: string = this.activeRoute.snapshot.params['id'];
    this.Iid =+ id;
    this._orderService.getOrderById(this.Iid).subscribe((result: OrderDtoListResultDto) => {
      this.orders = result.items;
      console.log('order', this.orders);
      this.calculateTotal();
      this.getQrCodes(this.orders[0])
    });


  }

  calculateTotal(){
    this.total = 0;
    for(let x=0;x<this.orders[0].orderLine.length;x++){
      this.total += this.orders[0].orderLine[x].itemQty * this.orders[0].orderLine[x].menuItemIdFkNavigation.menuItemPrice;
    }
    console.log('total', this.total);
    this.totalVat = this.total * 15/115;
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

  save(): void {
    this.saving = true;

    this._orderService
      .update(this.order)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));

        this.onSave.emit();
      });
  }

}
