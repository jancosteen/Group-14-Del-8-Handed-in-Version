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
  RestaurantFacilityServiceProxy,
  RestaurantFacilityDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-restaurantFacility-dialog.component.html'
})
export class EditRestaurantFacilityDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  restaurantFacility: RestaurantFacilityDto = new RestaurantFacilityDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _restaurantFacilityService: RestaurantFacilityServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._restaurantFacilityService.get(this.id).subscribe((result: RestaurantFacilityDto) => {
      this.restaurantFacility = result;
    });
  }

  save(): void {
    this.saving = true;

    this._restaurantFacilityService
      .update(this.restaurantFacility)
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
