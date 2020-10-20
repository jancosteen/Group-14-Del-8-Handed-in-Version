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
  RestaurantTypeDto,
  RestaurantTypeServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-restaurantType-dialog.component.html'
})
export class CreateRestaurantTypeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  restaurantType: RestaurantTypeDto = new RestaurantTypeDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _restaurantTypeService: RestaurantTypeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  save(): void {
    this.saving = true;

    this._restaurantTypeService
      .create(this.restaurantType)
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
