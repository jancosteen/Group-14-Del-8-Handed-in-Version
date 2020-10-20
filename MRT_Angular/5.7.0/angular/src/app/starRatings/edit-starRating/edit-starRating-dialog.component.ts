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
  StarRatingServiceProxy,
  StarRatingDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-starRating-dialog.component.html'
})
export class EditStarRatingDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  starRating: StarRatingDto = new StarRatingDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _starRatingService: StarRatingServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._starRatingService.get(this.id).subscribe((result: StarRatingDto) => {
      this.starRating = result;
    });
  }

  save(): void {
    this.saving = true;

    this._starRatingService
      .update(this.starRating)
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
