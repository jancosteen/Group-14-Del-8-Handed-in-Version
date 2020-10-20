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
  AllergyDto,
  AllergyServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-allergy-dialog.component.html'
})
export class CreateAllergyDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  allergy: AllergyDto = new AllergyDto();


  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _allergyService: AllergyServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  save(): void {
    this.saving = true;

    this._allergyService
      .create(this.allergy)
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
