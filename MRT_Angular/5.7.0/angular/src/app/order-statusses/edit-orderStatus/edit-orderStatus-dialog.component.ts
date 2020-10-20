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
  OrderStatusServiceProxy,
  OrderStatusDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-orderStatus-dialog.component.html'
})
export class EditOrderStatusDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  orderStatus: OrderStatusDto = new OrderStatusDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _orderStatusService: OrderStatusServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._orderStatusService.get(this.id).subscribe((result: OrderStatusDto) => {
      this.orderStatus = result;
    });
  }

  save(): void {
    this.saving = true;

    this._orderStatusService
      .update(this.orderStatus)
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
