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
  MenuItemCategoryServiceProxy,
  MenuItemCategoryDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-menuItemCategory-dialog.component.html'
})
export class EditMenuItemCategoryDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  menuItemCategory: MenuItemCategoryDto = new MenuItemCategoryDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuItemCategoryService: MenuItemCategoryServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._menuItemCategoryService.get(this.id).subscribe((result: MenuItemCategoryDto) => {
      this.menuItemCategory = result;
    });
  }

  save(): void {
    this.saving = true;

    this._menuItemCategoryService
      .update(this.menuItemCategory)
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
