import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '../../shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '../../shared/paged-listing-component-base';
import {
  MenuItemPriceServiceProxy,
  MenuItemPriceDto,
  MenuItemPriceDtoPagedResultDto,
  MenuItemServiceProxy,
  MenuItemDto,
  MenuItemDtoPagedResultDto,
} from '../../shared/service-proxies/service-proxies';
import { CreateMenuItemPriceDialogComponent } from './create-menuItemPrice/create-menuItemPrice-dialog.component';
import { EditMenuItemPriceDialogComponent } from './edit-menuItemPrice/edit-menuItemPrice-dialog.component';

class PagedMenuItemPricesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  templateUrl: './menuItemPrices.component.html',
  animations: [appModuleAnimation()]
})
export class MenuItemPricesComponent extends PagedListingComponentBase<MenuItemPriceDto> {
  menuItemPrices: MenuItemPriceDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;
  public searchText: string;
  isRelated=false;
  menuItems: MenuItemDto[]=[];

  constructor(
    injector: Injector,
    private _menuItemPriceService: MenuItemPriceServiceProxy,
    private _modalService: BsModalService,
    private _menuItemService: MenuItemServiceProxy
  ) {
    super(injector);
  }

  list(
    request: PagedMenuItemPricesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._menuItemPriceService
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
      .subscribe((result: MenuItemPriceDtoPagedResultDto) => {
        this.menuItemPrices = result.items;
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
      if(this.menuItems[x].menuItemPriceIdFk === id){
        this.isRelated=true;
        console.log(this.isRelated);
      }
    }
  }

  delete(menuItemPrice: MenuItemPriceDto): void {

    this.checkIfRelated(menuItemPrice.id);
    if(this.isRelated === true){
      abp.message.error(
        this.l('Unable to delete Price, it has related menu items', menuItemPrice.menuItemPrice1)
      )
    }
    if(this.isRelated === false){
    abp.message.confirm(
      this.l('Are you sure you want to delete this record?', menuItemPrice.menuItemPrice1),
      undefined,
      (result: boolean) => {
        if (result) {
          this._menuItemPriceService
            .delete(menuItemPrice.id)
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

  createMenuItemPrice(): void {
    this.showCreateOrEditMenuItemPriceDialog();
  }

  editMenuItemPrice(menuItemPrice: MenuItemPriceDto): void {
    this.showCreateOrEditMenuItemPriceDialog(menuItemPrice.id);
  }

  showCreateOrEditMenuItemPriceDialog(id?: number): void {
    let createOrEditMenuItemPriceDialog: BsModalRef;
    if (!id) {
      createOrEditMenuItemPriceDialog = this._modalService.show(
        CreateMenuItemPriceDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditMenuItemPriceDialog = this._modalService.show(
        EditMenuItemPriceDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditMenuItemPriceDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }

  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }
}
