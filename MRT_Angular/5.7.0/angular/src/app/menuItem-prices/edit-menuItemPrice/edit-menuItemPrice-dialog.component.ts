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
  MenuItemPriceServiceProxy,
  MenuItemPriceDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-menuItemPrice-dialog.component.html'
})
export class EditMenuItemPriceDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  menuItemPrice: MenuItemPriceDto = new MenuItemPriceDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuItemPriceService: MenuItemPriceServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._menuItemPriceService.get(this.id).subscribe((result: MenuItemPriceDto) => {
      this.menuItemPrice = result;
    });
  }

  save(): void {
    this.saving = true;

    this._menuItemPriceService
      .update(this.menuItemPrice)
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
