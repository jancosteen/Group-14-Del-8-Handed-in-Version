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
  MenuItemPriceDto,
  MenuItemPriceServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-menuItemPrice-dialog.component.html'
})
export class CreateMenuItemPriceDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  menuItemPrice: MenuItemPriceDto = new MenuItemPriceDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuItemPriceService: MenuItemPriceServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  save(): void {
    this.saving = true;

    this._menuItemPriceService
      .create(this.menuItemPrice)
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
