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
  RestaurantStatusDto,
  RestaurantStatusServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-restaurantStatus-dialog.component.html'
})
export class CreateRestaurantStatusDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  restaurantStatus: RestaurantStatusDto = new RestaurantStatusDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _restaurantStatusService: RestaurantStatusServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  save(): void {
    this.saving = true;

    this._restaurantStatusService
      .create(this.restaurantStatus)
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
