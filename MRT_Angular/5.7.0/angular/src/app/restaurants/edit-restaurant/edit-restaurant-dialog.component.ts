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
  RestaurantServiceProxy,
  RestaurantDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-restaurant-dialog.component.html'
})
export class EditRestaurantDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  restaurant: RestaurantDto = new RestaurantDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _restaurantService: RestaurantServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._restaurantService.get(this.id).subscribe((result: RestaurantDto) => {
      this.restaurant = result;
    });
  }

  save(): void {
    this.saving = true;

    this._restaurantService
      .update(this.restaurant)
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
