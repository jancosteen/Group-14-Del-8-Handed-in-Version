import { Component, Injector, Pipe, PipeTransform } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  MenuItemTypeServiceProxy,
  MenuItemTypeDto,
  MenuItemTypeDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateMenuItemTypeDialogComponent } from './create-menuItemType/create-menuItemType-dialog.component';
import { EditMenuItemTypeDialogComponent } from './edit-menuItemType/edit-menuItemType-dialog.component';

class PagedMenuItemTypesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './menuItemTypes.component.html',
  animations: [appModuleAnimation()]
})
export class MenuItemTypesComponent extends PagedListingComponentBase<MenuItemTypeDto> {
  menuItemTypes: MenuItemTypeDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText:string;

  constructor(
    injector: Injector,
    private _menuItemTypeService: MenuItemTypeServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedMenuItemTypesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._menuItemTypeService
      .getAll(
        request.keyword,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
          console.log(request.keyword);
        })
      )
      .subscribe((result: MenuItemTypeDtoPagedResultDto) => {
        this.menuItemTypes = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(menuItemType: MenuItemTypeDto): void {
    abp.message.confirm(
      this.l('MenuItemTypeDeleteWarningMessage', menuItemType.menuItemType1),
      undefined,
      (result: boolean) => {
        if (result) {
          this._menuItemTypeService
            .delete(menuItemType.id)
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

  createMenuItemType(): void {
    this.showCreateOrEditMenuItemTypeDialog();
  }

  editMenuItemType(menuItemType: MenuItemTypeDto): void {
    this.showCreateOrEditMenuItemTypeDialog(menuItemType.id);
  }

  showCreateOrEditMenuItemTypeDialog(id?: number): void {
    let createOrEditMenuItemTypeDialog: BsModalRef;
    if (!id) {
      createOrEditMenuItemTypeDialog = this._modalService.show(
        CreateMenuItemTypeDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditMenuItemTypeDialog = this._modalService.show(
        EditMenuItemTypeDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditMenuItemTypeDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }


}
