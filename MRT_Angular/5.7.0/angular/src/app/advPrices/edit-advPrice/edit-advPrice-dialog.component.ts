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
  AdvertisementPriceServiceProxy,
  AdvertisementPriceDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-advPrice-dialog.component.html'
})
export class EditAdvPriceDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  advPrice: AdvertisementPriceDto = new AdvertisementPriceDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _advPriceService: AdvertisementPriceServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._advPriceService.get(this.id).subscribe((result: AdvertisementPriceDto) => {
      this.advPrice = result;
    });
  }

  save(): void {
    this.saving = true;

    this._advPriceService
      .update(this.advPrice)
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
