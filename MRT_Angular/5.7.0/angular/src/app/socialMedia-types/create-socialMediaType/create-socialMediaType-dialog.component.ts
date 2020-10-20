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
  SocialMediaTypeDto,
  SocialMediaTypeServiceProxy
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'create-socialMediaType-dialog.component.html'
})
export class CreateSocialMediaTypeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  socialMediaType: SocialMediaTypeDto = new SocialMediaTypeDto();

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _socialMediaTypeService: SocialMediaTypeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }

  save(): void {
    this.saving = true;

    this._socialMediaTypeService
      .create(this.socialMediaType)
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
