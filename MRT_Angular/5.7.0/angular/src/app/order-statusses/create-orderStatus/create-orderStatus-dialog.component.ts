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
  OrderStatusDto,
  OrderStatusServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-orderStatus-dialog.component.html'
})
export class CreateOrderStatusDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  orderStatus: OrderStatusDto = new OrderStatusDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _orderStatusService: OrderStatusServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  save(): void {
    this.saving = true;

    this._orderStatusService
      .create(this.orderStatus)
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
