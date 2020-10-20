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
  RestaurantStatusServiceProxy,
  RestaurantStatusDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-restaurantStatus-dialog.component.html'
})
export class EditRestaurantStatusDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  restaurantStatus: RestaurantStatusDto = new RestaurantStatusDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _restaurantStatusService: RestaurantStatusServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._restaurantStatusService.get(this.id).subscribe((result: RestaurantStatusDto) => {
      this.restaurantStatus = result;
    });
  }

  save(): void {
    this.saving = true;

    this._restaurantStatusService
      .update(this.restaurantStatus)
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
