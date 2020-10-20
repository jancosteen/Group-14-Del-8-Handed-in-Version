import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '../../../shared/app-component-base';
import {
  MenuItemServiceProxy,
  MenuItemDto, RestaurantServiceProxy, RestaurantDtoPagedResultDto, RestaurantDto, MenuItemCategoryServiceProxy, MenuItemCategoryDtoPagedResultDto, MenuItemCategoryDto, MenuDtoPagedResultDto, MenuDto, MenuServiceProxy, MenuItemPriceServiceProxy, MenuItemPriceDtoPagedResultDto, MenuItemPriceDto, MenuItemAllergyServiceProxy, MenuItemAllergyDto, AllergyServiceProxy, AllergyDto, AllergyDtoPagedResultDto
} from '../../../shared/service-proxies/service-proxies';
import { EditMenuItemDialogComponent } from '../edit-menuItem/edit-menuItem-dialog.component';
import { CreateMenuItemDialogComponent } from '../create-menuItem/create-menuItem-dialog.component';




@Component({
  templateUrl: 'menuItem-detail.component.html'
})
export class MenuItemDetailComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  menuItem: MenuItemDto = new MenuItemDto();
  Iid: number;
  miCategories: MenuItemCategoryDto[]=[];
  miCategory: MenuItemCategoryDto = new MenuItemCategoryDto();
  menus: MenuDto[]=[];
  menu: MenuDto = new MenuDto();
  restaurantdIdFk:number;
  menuItemId:number;
  public searchText:string;
  loading:boolean = true;
  advancedFiltersVisible = false;
  menuItemCategoryIdFk: number;
  menuItemPriceIdFk:number;
  menuIdFk:number;
  miPrices: MenuItemPriceDto[]=[];
  miPrice: MenuItemPriceDto;
  miAllergies: MenuItemAllergyDto[]=[];
  allergies: AllergyDto[]=[];
  shownAllergies:AllergyDto[]=[];
  allergyIds=[];
  allergyIds2=[];
  miAllergyIds=[];



  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuService: MenuServiceProxy,
    public _menuItemService: MenuItemServiceProxy,
    public _miCategoryService: MenuItemCategoryServiceProxy,
    private activeRoute: ActivatedRoute,
    private _menuItemPriceService: MenuItemPriceServiceProxy,
    private router: Router,
    private _modalService: BsModalService,
    private _miAllergyService: MenuItemAllergyServiceProxy,
    private _allergyService: AllergyServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    let id: string = this.activeRoute.snapshot.params['id'];
    this.Iid =+ id;
    this._menuItemService.get(this.Iid).subscribe((result: MenuItemDto) => {
      this.menuItem = result;
      this.menuItemCategoryIdFk = this.menuItem.menuItemCategoryIdFk;
      this.menuItemPriceIdFk = this.menuItem.menuItemPriceIdFk;
      this.menuIdFk = this.menuItem.menuIdFk;
      this.menuItemId = this.menuItem.id;
    });

    this._miCategoryService
    .getAll(
      '',
      0,
      1000
    )
    .pipe(
      finalize(() => {
        console.log('miCategory pipe');
      })
    )
    .subscribe((result: MenuItemCategoryDtoPagedResultDto) => {
      this.miCategories = result.items;
      this.getMiCategory(this.menuItemCategoryIdFk);
    });

    this._menuService
      .getAll(
        '',
        0,
        1000
      )
      .pipe(
        finalize(() => {
          console.log('menu pipe')
        })
      )
      .subscribe((result: MenuDtoPagedResultDto)=>{
        this.menus = result.items;
        this.getMenu(this.menuIdFk);
      });

      this._menuItemPriceService
        .getAll(
          '',
          0,
          1000
        ).pipe(
          finalize(()=>{
            console.log('price pipe')
          })
        ).subscribe((result: MenuItemPriceDtoPagedResultDto)=>{
          this.miPrices = result.items;
          this.getMiPrice(this.menuItemPriceIdFk);
        })



      this._allergyService
      .getAll(
        '',
        0,
        1000
      ).pipe(
        finalize(() => {
          console.log('allrgies pipe')
        })
      ).subscribe((res: AllergyDtoPagedResultDto)=>{
        this.allergies = res.items;

      });


  }

  save(): void {
    this.saving = true;

    this._menuItemService
      .update(this.menuItem)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
      });
  }

  getMiCategory(catId){
    for(let x=0;x<this.miCategories.length;x++){
      if(catId==this.miCategories[x].id){
        this.miCategory=this.miCategories[x];
        console.log(catId,this.miCategories[x]);
      }
    }
  }

  getMiPrice(pId){
    for(let x=0;x<this.miPrices.length;x++){
      if(pId==this.miPrices[x].id){
        this.miPrice=this.miPrices[x];
        console.log(pId,this.miPrices[x]);
      }
    }
  }


  getMenu(mId){
    for(let x=0;x<this.menus.length;x++){
      if(mId==this.menus[x].id){
        this.menu=this.menus[x];
        console.log(mId,this.menus[x]);
      }
    }
  }


  delete(menuItemAllergy: MenuItemAllergyDto): void {

    abp.message.confirm(
      this.l('MenuItemDeleteWarningMessage', menuItemAllergy.id),
      undefined,
      (result: boolean) => {
        if (result) {
          this._menuItemService
            .delete(menuItemAllergy.allergyIdFk)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));

              })
            )
            .subscribe(() => {});
        }
      }
    );

  }


  editMenuItem(menuItem: MenuItemDto): void {
    this.showCreateOrEditMenuItemDialog(menuItem.id);
  }

  showCreateOrEditMenuItemDialog(id?: number): void {
    let createOrEditMenuItemDialog: BsModalRef;
    if (!id) {
      createOrEditMenuItemDialog = this._modalService.show(
        CreateMenuItemDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditMenuItemDialog = this._modalService.show(
        EditMenuItemDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditMenuItemDialog.content.onSave.subscribe(() => {
      let id: string = this.activeRoute.snapshot.params['id'];
    this.Iid =+ id;
    this._menuItemService.get(this.Iid).subscribe((result: MenuItemDto) => {
      this.menuItem = result;
      this.menuItemCategoryIdFk = this.menuItem.menuItemCategoryIdFk;
      this.menuItemPriceIdFk = this.menuItem.menuItemPriceIdFk;
      this.menuIdFk = this.menuItem.menuIdFk;
      this.menuItemId = this.menuItem.id;
    });
  });

  }


}
