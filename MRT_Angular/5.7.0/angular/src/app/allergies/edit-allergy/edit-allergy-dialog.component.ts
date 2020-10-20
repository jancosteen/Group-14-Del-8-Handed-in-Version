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
  AllergyServiceProxy,
  AllergyDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-allergy-dialog.component.html'
})
export class EditAllergyDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  allergy: AllergyDto = new AllergyDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _allergyService: AllergyServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._allergyService.get(this.id).subscribe((result: AllergyDto) => {
      this.allergy = result;
    });
  }

  save(): void {
    this.saving = true;

    this._allergyService
      .update(this.allergy)
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
