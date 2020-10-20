import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  StarRatingServiceProxy,
  StarRatingDto,
  StarRatingDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateStarRatingDialogComponent } from './create-starRating/create-starRating-dialog.component';
import { EditStarRatingDialogComponent } from './edit-starRating/edit-starRating-dialog.component';

class PagedStarRatingsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './starRatings.component.html',
  animations: [appModuleAnimation()]
})
export class StarRatingsComponent extends PagedListingComponentBase<StarRatingDto> {
  starRatings: StarRatingDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText: string;

  constructor(
    injector: Injector,
    private _starRatingService: StarRatingServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedStarRatingsRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._starRatingService
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
      .subscribe((result: StarRatingDtoPagedResultDto) => {
        this.starRatings = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(starRating: StarRatingDto): void {
    abp.message.confirm(
      this.l('StarRatingDeleteWarningMessage', starRating.starRatingValue),
      undefined,
      (result: boolean) => {
        if (result) {
          this._starRatingService
            .delete(starRating.id)
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

  createStarRating(): void {
    this.showCreateOrEditStarRatingDialog();
  }

  editStarRating(starRating: StarRatingDto): void {
    this.showCreateOrEditStarRatingDialog(starRating.id);
  }

  showCreateOrEditStarRatingDialog(id?: number): void {
    let createOrEditStarRatingDialog: BsModalRef;
    if (!id) {
      createOrEditStarRatingDialog = this._modalService.show(
        CreateStarRatingDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditStarRatingDialog = this._modalService.show(
        EditStarRatingDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditStarRatingDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
