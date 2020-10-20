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
  OrderLineServiceProxy,
  OrderLineDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-orderLine-dialog.component.html'
})
export class EditOrderLineDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  orderLine: OrderLineDto = new OrderLineDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _orderLineService: OrderLineServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._orderLineService.get(this.id).subscribe((result: OrderLineDto) => {
      this.orderLine = result;
    });
  }

  save(): void {
    this.saving = true;

    this._orderLineService
      .update(this.orderLine)
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
