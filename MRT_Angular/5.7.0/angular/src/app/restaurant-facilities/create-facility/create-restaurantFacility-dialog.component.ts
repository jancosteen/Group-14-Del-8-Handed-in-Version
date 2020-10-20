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
  RestaurantFacilityDto,
  RestaurantFacilityServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-restaurantFacility-dialog.component.html'
})
export class CreateRestaurantFacilityDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  restaurantFacility: RestaurantFacilityDto = new RestaurantFacilityDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _restaurantFacilityService: RestaurantFacilityServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  save(): void {
    this.saving = true;

    this._restaurantFacilityService
      .create(this.restaurantFacility)
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
