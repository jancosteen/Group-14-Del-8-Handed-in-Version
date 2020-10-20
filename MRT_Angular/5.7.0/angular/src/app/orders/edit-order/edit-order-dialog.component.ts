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
  OrderDto, OrderStatusDto, QrCodeSeatingDto, OrderStatusServiceProxy, QrCodeSeatingServiceProxy, OrderStatusDtoPagedResultDto, QrCodeSeatingDtoPagedResultDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-order-dialog.component.html'
})
export class EditOrderDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  order: OrderDto = new OrderDto();
  id: number;
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
    this._orderService.get(this.id).subscribe((result: OrderDto) => {
      this.order = result;
    });

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
      .update(this.order)
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
