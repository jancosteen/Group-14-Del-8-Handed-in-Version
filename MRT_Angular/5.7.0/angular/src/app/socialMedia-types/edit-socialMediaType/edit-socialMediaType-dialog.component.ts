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
  SocialMediaTypeServiceProxy,
  SocialMediaTypeDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-socialMediaType-dialog.component.html'
})
export class EditSocialMediaTypeDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  socialMediaType: SocialMediaTypeDto = new SocialMediaTypeDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _socialMediaTypeService: SocialMediaTypeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._socialMediaTypeService.get(this.id).subscribe((result: SocialMediaTypeDto) => {
      this.socialMediaType = result;
    });
  }

  save(): void {
    this.saving = true;

    this._socialMediaTypeService
      .update(this.socialMediaType)
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
