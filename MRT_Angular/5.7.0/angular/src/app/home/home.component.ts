import { Component, Injector, ChangeDetectionStrategy, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { RestaurantDto, RestaurantDtoPagedResultDto, RestaurantServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AppSessionService } from '@shared/session/app-session.service';


class PagedRestaurantsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}
@Component({
  templateUrl: './home.component.html',
  animations: [appModuleAnimation()],
})
export class HomeComponent extends PagedListingComponentBase<RestaurantDto> {

  cart=[];
  restaurants: RestaurantDto[]=[];

  constructor(injector: Injector
    ,public _restaurantService: RestaurantServiceProxy
    ,public _router:Router
    ,public _appSessionService: AppSessionService) {
    super(injector);
  }

  list(
    request: PagedRestaurantsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = '';
    ;

    this._restaurantService
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
      .subscribe((result: RestaurantDtoPagedResultDto) => {
        this.restaurants = result.items;
        console.log(this.restaurants);
        this.convertImage(this.restaurants);
        //this.showPaging(result, pageNumber);
      });
  }

  convertImage(restaurants:RestaurantDto[]){
    for(let i=0;i<restaurants.length;i++){
      for(let x=0; x<restaurants[i].restaurantImage.length;x++){
        console.log(this.restaurants[i].restaurantImage[x].imageDescription);
        this.restaurants[i].restaurantImage[x].imageFile = 'data:image/jpg;base64,'+this.restaurants[i].restaurantImage[x].imageFile
      }
      //this.images[i]=this.sanitizer.bypassSecurityTrustResourceUrl('data:image/png;base64,'+resImages[i].imageFile)

      //this.restaurantImages[i].imageFile = this.images;
    }
    this.cart = this._appSessionService.getCart();
    console.log(this.cart);

  }

  delete(restaurant: RestaurantDto): void {
    abp.message.confirm(
      this.l('RestaurantDeleteWarningMessage', restaurant.restaurantName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._restaurantService
            .delete(restaurant.id)
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

  goToMenu(res:RestaurantDto){
    const detailsUrl: string = `/app/cusMenu/${res.id}`;
    this._router.navigate([detailsUrl]);
  }




  }


