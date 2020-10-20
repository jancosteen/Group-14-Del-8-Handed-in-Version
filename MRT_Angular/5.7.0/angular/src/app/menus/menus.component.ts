import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  MenuServiceProxy,
  MenuDto,
  MenuDtoPagedResultDto,
  MenuItemDto,
  MenuItemServiceProxy,
  MenuItemDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateMenuDialogComponent } from './create-menu/create-menu-dialog.component';
import { EditMenuDialogComponent } from './edit-menu/edit-menu-dialog.component';
import { Router } from '@angular/router';

class PagedMenusRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './menus.component.html',
  animations: [appModuleAnimation()]
})
export class MenusComponent extends PagedListingComponentBase<MenuDto> {
  menus: MenuDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText: string;
  isRelated=false;
  menuItems:MenuItemDto[]=[];

  constructor(
    injector: Injector,
    private _menuService: MenuServiceProxy,
    private _modalService: BsModalService,
    private _router: Router,
    private _menuItemService:MenuItemServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedMenusRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._menuService
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
      .subscribe((result: MenuDtoPagedResultDto) => {
        this.menus = result.items;
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

      });
  }

  checkIfRelated(id){
    for(let x=0;x<this.menuItems.length;x++){
      if(this.menuItems[x].menuIdFk === id){
        this.isRelated=true;
        console.log(this.isRelated);
      }
    }
  }

  delete(menu: MenuDto): void {
    this.checkIfRelated(menu.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete Menu, it has related menu items', menu.menuName)
      )
    }
    if(this.isRelated === false){
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', menu.menuName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._menuService
            .delete(menu.id)
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

  createMenu(): void {
    this.showCreateOrEditMenuDialog();
  }

  editMenu(menu: MenuDto): void {
    this.showCreateOrEditMenuDialog(menu.id);
  }

  showCreateOrEditMenuDialog(id?: number): void {
    let createOrEditMenuDialog: BsModalRef;
    if (!id) {
      createOrEditMenuDialog = this._modalService.show(
        CreateMenuDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditMenuDialog = this._modalService.show(
        EditMenuDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditMenuDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  viewMenu(menu:MenuDto): void {
    const detailsUrl: string = `/app/menu/${menu.id}`;
    this._router.navigate([detailsUrl]);
  }
}
