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
  SocialMediaServiceProxy,
  SocialMediaDto, SocialMediaTypeServiceProxy, RestaurantServiceProxy, SocialMediaTypeDtoPagedResultDto, SocialMediaTypeDto, RestaurantDto, RestaurantDtoPagedResultDto
} from '../../../shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-socialMedia-dialog.component.html'
})
export class EditSocialMediaDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  socialMedia: SocialMediaDto = new SocialMediaDto();
  socialMediaTypes: SocialMediaTypeDto[] = [];
  restaurants: RestaurantDto[] = [];

  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _socialMediaService: SocialMediaServiceProxy,
    public _socialMediaTypeService: SocialMediaTypeServiceProxy,
    public _restaurantService: RestaurantServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._socialMediaService.get(this.id).subscribe((result: SocialMediaDto) => {
      this.socialMedia = result;
    });

    this._socialMediaTypeService
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
      .subscribe((result: SocialMediaTypeDtoPagedResultDto) => {
        this.socialMediaTypes = result.items;
        //this.showPaging(result, pageNumber);
      });

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

    this._socialMediaService
      .update(this.socialMedia)
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
