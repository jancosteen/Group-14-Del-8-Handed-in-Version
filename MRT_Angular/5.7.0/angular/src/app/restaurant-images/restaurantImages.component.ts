import { Component, Injector, SecurityContext } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  RestaurantImageServiceProxy,
  RestaurantImageDto,
  RestaurantImageDtoPagedResultDto, RestaurantServiceProxy, RestaurantDtoPagedResultDto, RestaurantDto
} from '../../shared/service-proxies/service-proxies';
import { CreateRestaurantImageDialogComponent } from './create-restaurantImage/create-restaurantImage-dialog.component';
import { EditRestaurantImageDialogComponent } from './edit-restaurantImage/edit-restaurantImage-dialog.component';
import { DomSanitizer } from '@angular/platform-browser';



class PagedRestaurantImagesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}


@Component({
  templateUrl: './restaurantImages.component.html',
  animations: [appModuleAnimation()]
})
export class RestaurantImagesComponent extends PagedListingComponentBase<RestaurantImageDto> {
  restaurantImages: RestaurantImageDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  restaurants: RestaurantDto[] = [];
  images:any =[];
  public searchText: string;
  isRelated=false;




  constructor(
    injector: Injector,
    private _restaurantImageService: RestaurantImageServiceProxy,
    private _modalService: BsModalService,
    private sanitizer: DomSanitizer
  ) {
    super(injector);
  }

  list(
    request: PagedRestaurantImagesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._restaurantImageService
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
      .subscribe((result: RestaurantImageDtoPagedResultDto) => {
        this.restaurantImages = result.items;
        this.convertImage(this.restaurantImages);
        this.showPaging(result, pageNumber);
      });

  }

  convertImage(resImages:RestaurantImageDto[]){
    for(let i=0;i<resImages.length;i++){
      //this.images[i]=this.sanitizer.bypassSecurityTrustResourceUrl('data:image/png;base64,'+resImages[i].imageFile)
      this.restaurantImages[i].imageFile = 'data:image/jpg;base64,'+this.restaurantImages[i].imageFile
      //this.restaurantImages[i].imageFile = this.images;
    }
  }

  checkIfRelated(id){
    for(let x=0;x<this.restaurants.length;x++){
      for(let y=0;y<this.restaurants[x].restaurantImage.length;y++){
        if(this.restaurants[x].restaurantImage[y].id === id){
          this.isRelated=true;
          console.log(this.isRelated);
        }
      }

    }
  }

  delete(restaurantImage: RestaurantImageDto): void {
    this.checkIfRelated(restaurantImage.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete Image, it has related restaurants', restaurantImage.imageDescription)
      )
    }
    if(this.isRelated === false){
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', restaurantImage.imageDescription),
      undefined,
      (result: boolean) => {
        if (result) {
          this._restaurantImageService
            .delete(restaurantImage.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );}
  }

  createRestaurantImage(): void {
    this.showCreateOrEditRestaurantImageDialog();
  }

  editRestaurantImage(restaurantImage: RestaurantImageDto): void {
    this.showCreateOrEditRestaurantImageDialog(restaurantImage.id);
  }

  showCreateOrEditRestaurantImageDialog(id?: number): void {
    let createOrEditRestaurantImageDialog: BsModalRef;
    if (!id) {
      createOrEditRestaurantImageDialog = this._modalService.show(
        CreateRestaurantImageDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditRestaurantImageDialog = this._modalService.show(
        EditRestaurantImageDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditRestaurantImageDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
