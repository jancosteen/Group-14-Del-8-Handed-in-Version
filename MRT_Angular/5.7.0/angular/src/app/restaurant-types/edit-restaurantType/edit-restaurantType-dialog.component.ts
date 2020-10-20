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
  RestaurantTypeServiceProxy,
  RestaurantTypeDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-restaurantType-dialog.component.html'
})
export class EditRestaurantTypeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  restaurantType: RestaurantTypeDto = new RestaurantTypeDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _restaurantTypeService: RestaurantTypeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._restaurantTypeService.get(this.id).subscribe((result: RestaurantTypeDto) => {
      this.restaurantType = result;
    });
  }

  save(): void {
    this.saving = true;

    this._restaurantTypeService
      .update(this.restaurantType)
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
