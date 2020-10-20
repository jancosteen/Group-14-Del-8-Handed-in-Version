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
  MenuItemTypeServiceProxy,
  MenuItemTypeDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-menuItemType-dialog.component.html'
})
export class EditMenuItemTypeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  menuItemType: MenuItemTypeDto = new MenuItemTypeDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuItemTypeService: MenuItemTypeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._menuItemTypeService.get(this.id).subscribe((result: MenuItemTypeDto) => {
      this.menuItemType = result;
    });
  }

  save(): void {
    this.saving = true;

    this._menuItemTypeService
      .update(this.menuItemType)
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
