import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  SocialMediaServiceProxy,
  SocialMediaDto,
  SocialMediaDtoPagedResultDto, RestaurantDto, SocialMediaTypeDto, SocialMediaTypeServiceProxy, RestaurantServiceProxy, SocialMediaTypeDtoPagedResultDto, RestaurantDtoPagedResultDto
} from '../../shared/service-proxies/service-proxies';
import { CreateSocialMediaDialogComponent } from './create-socialMedia/create-socialMedia-dialog.component';
import { EditSocialMediaDialogComponent } from './edit-socialMedia/edit-socialMedia-dialog.component';

class PagedSocialMediasRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './socialMedias.component.html',
  animations: [appModuleAnimation()]
})
export class SocialMediasComponent extends PagedListingComponentBase<SocialMediaDto> {
  socialMedias: SocialMediaDto[] = [];
  socialMediaType: SocialMediaTypeDto = new SocialMediaTypeDto();
  restaurant: RestaurantDto = new RestaurantDto();
  socialMediaTypes: SocialMediaTypeDto[]=[];
  restaurants: RestaurantDto[]=[];
  idR:number;
  idST: number;

  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText:string;

  constructor(
    injector: Injector,
    private _socialMediaService: SocialMediaServiceProxy,
    private _socialMediaTypeService: SocialMediaTypeServiceProxy,
    private _restaurantService: RestaurantServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }
//request1: PagedSocialMediaTypesRequestDto,
//request2: PagedRestaurantsRequestDto,
/*
request1.keyword1 = this.keyword;
    request1.isActive1 = this.isActive;
    request2.keyword2 = this.keyword;
    request2.isActive2 = this.isActive;
*/
  list(
    request: PagedSocialMediasRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._socialMediaService
      .getAll(
        request.keyword,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: SocialMediaDtoPagedResultDto) => {
        this.socialMedias = result.items;
        this.showPaging(result, pageNumber);
      });

      this._socialMediaTypeService
      .getAll(
        '',
        0,
        1000
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: SocialMediaTypeDtoPagedResultDto) => {
        this.socialMediaTypes = result.items;

      });

      this._restaurantService
      .getAll(
        '',
        0,
        1000
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: RestaurantDtoPagedResultDto) => {
        this.restaurants = result.items;

      });
  }




  delete(socialMedia: SocialMediaDto): void {
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', socialMedia.socialMediaAddress),
      undefined,
      (result: boolean) => {
        if (result) {
          this._socialMediaService
            .delete(socialMedia.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createSocialMedia(): void {
    this.showCreateOrEditSocialMediaDialog();
  }

  editSocialMedia(socialMedia: SocialMediaDto): void {
    this.showCreateOrEditSocialMediaDialog(socialMedia.id);
  }

  showCreateOrEditSocialMediaDialog(id?: number): void {
    let createOrEditSocialMediaDialog: BsModalRef;
    if (!id) {
      createOrEditSocialMediaDialog = this._modalService.show(
        CreateSocialMediaDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditSocialMediaDialog = this._modalService.show(
        EditSocialMediaDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditSocialMediaDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
