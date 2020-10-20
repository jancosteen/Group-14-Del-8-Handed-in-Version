import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  SocialMediaTypeServiceProxy,
  SocialMediaTypeDto,
  SocialMediaTypeDtoPagedResultDto,
  SocialMediaDto,
  SocialMediaServiceProxy,
  SocialMediaDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateSocialMediaTypeDialogComponent } from './create-socialMediaType/create-socialMediaType-dialog.component';
import { EditSocialMediaTypeDialogComponent } from './edit-socialMediaType/edit-socialMediaType-dialog.component';

class PagedSocialMediaTypesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './socialMediaTypes.component.html',
  animations: [appModuleAnimation()]
})
export class SocialMediaTypesComponent extends PagedListingComponentBase<SocialMediaTypeDto> {
  socialMediaTypes: SocialMediaTypeDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  searchText:string;
  isRelated=false;
  socialMedias:SocialMediaDto[]=[];

  constructor(
    injector: Injector,
    private _socialMediaTypeService: SocialMediaTypeServiceProxy,
    private _modalService: BsModalService,
    private _socialMediaService:SocialMediaServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedSocialMediaTypesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._socialMediaTypeService
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
      .subscribe((result: SocialMediaTypeDtoPagedResultDto) => {
        this.socialMediaTypes = result.items;
        this.showPaging(result, pageNumber);
      });

      this._socialMediaService
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
      .subscribe((result: SocialMediaDtoPagedResultDto) => {
        this.socialMedias = result.items;

      });
  }

  checkIfRelated(id){
    for(let x=0;x<this.socialMedias.length;x++){
      if(this.socialMedias[x].socialMediaTypeIdFk === id){
        this.isRelated=true;
        console.log(this.isRelated);
      }
    }
  }

  delete(socialMediaType: SocialMediaTypeDto): void {
    this.checkIfRelated(socialMediaType.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete Social Media Type, it has related accounts', socialMediaType.socialMediaType1)
      )
    }
    if(this.isRelated === false){
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', socialMediaType.socialMediaType1),
      undefined,
      (result: boolean) => {
        if (result) {
          this._socialMediaTypeService
            .delete(socialMediaType.id)
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
  }

  createSocialMediaType(): void {
    this.showCreateOrEditSocialMediaTypeDialog();
  }

  editSocialMediaType(socialMediaType: SocialMediaTypeDto): void {
    this.showCreateOrEditSocialMediaTypeDialog(socialMediaType.id);
  }

  showCreateOrEditSocialMediaTypeDialog(id?: number): void {
    let createOrEditSocialMediaTypeDialog: BsModalRef;
    if (!id) {
      createOrEditSocialMediaTypeDialog = this._modalService.show(
        CreateSocialMediaTypeDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditSocialMediaTypeDialog = this._modalService.show(
        EditSocialMediaTypeDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditSocialMediaTypeDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
