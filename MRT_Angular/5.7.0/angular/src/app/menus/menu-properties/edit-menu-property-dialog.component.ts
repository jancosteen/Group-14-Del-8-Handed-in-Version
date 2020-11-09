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
  MenuServiceProxy,
  MenuDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-menu-property-dialog.component.html'
})
export class MenuPropertiesDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  menu: MenuDto = new MenuDto();
  id: number;
  sMenuId:string;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuService: MenuServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

    this.sMenuId= localStorage.getItem('menuId');
    this.id = parseInt(this.sMenuId);
    this._menuService.get(this.id).subscribe((result: MenuDto) => {
      this.menu = result;
      console.log(this.menu);
    });
  }

  save(): void {

    this.bsModalRef.hide();
    this.onSave.emit();

    /*this._menuService
      .update(this.menu)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      });*/
  }
}
