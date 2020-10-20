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
  AdvertisementPriceDto,
  AdvertisementPriceServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-advPrice-dialog.component.html'
})
export class CreateAdvPriceDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  advPrice: AdvertisementPriceDto = new AdvertisementPriceDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _advPriceService: AdvertisementPriceServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  save(): void {
    this.saving = true;

    this._advPriceService
      .create(this.advPrice)
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
