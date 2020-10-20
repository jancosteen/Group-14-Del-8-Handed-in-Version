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
  RestaurantImageServiceProxy,
  RestaurantImageDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-restaurantImage-dialog.component.html'
})
export class EditRestaurantImageDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  restaurantImage: RestaurantImageDto = new RestaurantImageDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _restaurantImageService: RestaurantImageServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._restaurantImageService.get(this.id).subscribe((result: RestaurantImageDto) => {
      this.restaurantImage = result;
    });
  }

  save(): void {
    this.saving = true;

    this._restaurantImageService
      .update(this.restaurantImage)
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
