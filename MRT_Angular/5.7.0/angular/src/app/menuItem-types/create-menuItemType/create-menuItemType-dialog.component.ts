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
  MenuItemTypeDto,
  MenuItemTypeServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-menuItemType-dialog.component.html'
})
export class CreateMenuItemTypeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  menuItemType: MenuItemTypeDto = new MenuItemTypeDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuItemTypeService: MenuItemTypeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  save(): void {
    this.saving = true;

    this._menuItemTypeService
      .create(this.menuItemType)
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
