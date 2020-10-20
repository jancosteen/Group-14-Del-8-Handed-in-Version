import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  MenuItemCategoryServiceProxy,
  MenuItemCategoryDto,
  MenuItemCategoryDtoPagedResultDto,
  MenuItemDto,
  MenuItemServiceProxy,
  MenuItemDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateMenuItemCategoryDialogComponent } from './create-menuItemCategory/create-menuItemCategory-dialog.component';
import { EditMenuItemCategoryDialogComponent } from './edit-menuItemCategory/edit-menuItemCategory-dialog.component';

class PagedMenuItemCategorysRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './menuItemCategories.component.html',
  animations: [appModuleAnimation()]
})
export class MenuItemCategoriesComponent extends PagedListingComponentBase<MenuItemCategoryDto> {
  menuItemCategorys: MenuItemCategoryDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText:string;
  isRelated=false;
  menuItems:MenuItemDto[]=[];

  constructor(
    injector: Injector,
    private _menuItemCategoryService: MenuItemCategoryServiceProxy,
    private _modalService: BsModalService,
    private _menuItemService: MenuItemServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedMenuItemCategorysRequestDto,
    pageNumber: number,
    finishedCallback: Function,

  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._menuItemCategoryService
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
      .subscribe((result: MenuItemCategoryDtoPagedResultDto) => {
        this.menuItemCategorys = result.items;
        this.showPaging(result, pageNumber);
      });

      this._menuItemService
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
      .subscribe((result: MenuItemDtoPagedResultDto) => {
        this.menuItems = result.items;
        console.log(this.menuItems);
      });
  }

  checkIfRelated(id){
    for(let x=0;x<this.menuItems.length;x++){
      if(this.menuItems[x].menuItemCategoryIdFk === id){
        this.isRelated=true;
        console.log(this.isRelated);
      }
    }
  }

  delete(menuItemCategory: MenuItemCategoryDto): void {
    this.checkIfRelated(menuItemCategory.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete Category, it has related menu items', menuItemCategory.menuItemCategory1)
      )
    }
    if(this.isRelated === false){
      abp.message.confirm(
        this.l('Are you sure you want to delete this record?', menuItemCategory.menuItemCategory1),
        undefined,
        (result: boolean) => {
          if (result) {
            this._menuItemCategoryService
              .delete(menuItemCategory.id)
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

  createMenuItemCategory(): void {
    this.showCreateOrEditMenuItemCategoryDialog();
  }

  editMenuItemCategory(menuItemCategory: MenuItemCategoryDto): void {
    this.showCreateOrEditMenuItemCategoryDialog(menuItemCategory.id);
  }

  showCreateOrEditMenuItemCategoryDialog(id?: number): void {
    let createOrEditMenuItemCategoryDialog: BsModalRef;
    if (!id) {
      createOrEditMenuItemCategoryDialog = this._modalService.show(
        CreateMenuItemCategoryDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditMenuItemCategoryDialog = this._modalService.show(
        EditMenuItemCategoryDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditMenuItemCategoryDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
