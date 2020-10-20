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
  OrderDto,
  OrderServiceProxy,
  OrderStatusDto,
  OrderStatusDtoPagedResultDto,
  OrderStatusServiceProxy,
  QrCodeSeatingDto,
  QrCodeSeatingDtoPagedResultDto,
  QrCodeSeatingServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-order-dialog.component.html'
})
export class CreateOrderDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  order: OrderDto = new OrderDto();
  qrCodeSeatings: QrCodeSeatingDto[]=[];
  orderStatusses: OrderStatusDto[]=[];
  currentDate;


  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _orderService: OrderServiceProxy,
    public _qrCodeSeatingService: QrCodeSeatingServiceProxy,
    public _orderStatusses: OrderStatusServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

    this.currentDate = new Date().toISOString().substring(0, 16);

    this._qrCodeSeatingService
    .getAll(
      '',
      0,
      100
    )
    .pipe(
      finalize(() => {
        console.log('pipe');
      })
    )
    .subscribe((result: QrCodeSeatingDtoPagedResultDto) => {
      this.qrCodeSeatings = result.items;
      //this.showPaging(result, pageNumber);
    });

    this._orderStatusses
    .getAll(
      '',
      0,
      100
    )
    .pipe(
      finalize(() => {
        console.log('pipe');
      })
    )
    .subscribe((result: OrderStatusDtoPagedResultDto) => {
      this.orderStatusses = result.items;
      //this.showPaging(result, pageNumber);
    });

  }

  save(): void {
    this.saving = true;

    this._orderService
      .create(this.order)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });
  }
}
