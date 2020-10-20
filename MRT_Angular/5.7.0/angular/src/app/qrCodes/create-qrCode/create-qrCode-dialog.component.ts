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
  QrCodeDto,
  QrCodeServiceProxy,
  RestaurantDto,
  RestaurantDtoPagedResultDto,
  RestaurantServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-qrCode-dialog.component.html'
})
export class CreateQrCodeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  qrCode: QrCodeDto = new QrCodeDto();
  restaurants: RestaurantDto[]=[];


  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _qrCodeService: QrCodeServiceProxy,
    public _restaurantService: RestaurantServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._restaurantService
    .getAll(
      '',
      0,
      100
    )
    .pipe(
      finalize(() => {
        console.log('pipe');
      })
    )
    .subscribe((result: RestaurantDtoPagedResultDto) => {
      this.restaurants = result.items;
      //this.showPaging(result, pageNumber);
    });
  }

  save(): void {
    this.saving = true;

    this._qrCodeService
      .create(this.qrCode)
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
