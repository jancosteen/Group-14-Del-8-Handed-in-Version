import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '../../../shared/app-component-base';
import {
  MenuItemServiceProxy,
  MenuItemDto, MenuItemCategoryDtoPagedResultDto, MenuItemCategoryServiceProxy, MenuItemCategoryDto, MenuItemPriceDto, MenuItemPriceServiceProxy, MenuItemPriceDtoPagedResultDto, MenuItemAllergyServiceProxy, MenuItemAllergyDto, AllergyDto, AllergyServiceProxy, AllergyDtoPagedResultDto, MenuDtoPagedResultDto, MenuServiceProxy, MenuDto, MenuItemAllergyDtoListResultDto
} from '../../../shared/service-proxies/service-proxies';
import { ElementSchemaRegistry } from '@angular/compiler';

@Component({
  templateUrl: 'edit-menuItem-dialog.component.html'
})
export class EditMenuItemDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  menuItem: MenuItemDto = new MenuItemDto();
  menuItemId:number;
  menuItemId2:number;
  id: number;
  menuItemCategories: MenuItemCategoryDto[]=[];
  menuItemPrices: MenuItemPriceDto[]=[];
  menuItemAllergies: MenuItemAllergyDto[]=[];
  miAllergyIds=[];
  allergies: AllergyDto[]=[];
  allergyIds=[];
  allergyIds2=[];
  filtered=[];
  menuItemAllergy: MenuItemAllergyDto = new MenuItemAllergyDto();
  uniqueSet=[];
  menus:MenuDto[]=[];
  changed:boolean=false;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuItemService: MenuItemServiceProxy,
    public bsModalRef: BsModalRef,
    public _allergiesService: AllergyServiceProxy,
    public _menuItemCategoryService: MenuItemCategoryServiceProxy,
    public _menuItemPriceService: MenuItemPriceServiceProxy,
    public _menuItemAllergyService: MenuItemAllergyServiceProxy,
    public _menuService: MenuServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._menuItemService.get(this.id).subscribe((result: MenuItemDto) => {
      this.menuItem = result;
      this.menuItemId2 = this.menuItem.id;
      localStorage.setItem('menuItemId2', this.menuItemId2.toString());
    });

    console.log(this.changed);

    this._menuItemAllergyService.getAllergyByMenuItemId(this.id).subscribe((result) => {
      this.menuItemAllergies = result.items;
      console.log('allergyId by MI',result);
      this.populateAllergyIds(this.menuItemAllergies);
    });


    this._allergiesService
    .getAll(
      '',
      0,
      100
    )
    .pipe(
      finalize(() => {
        console.log('allergies');
      })
    )
    .subscribe((result: AllergyDtoPagedResultDto) => {
      this.allergies = result.items;
      //this.showPaging(result, pageNumber);
    });

    this._menuItemCategoryService
    .getAll(
      '',
      0,
      100
    )
    .pipe(
      finalize(() => {
        console.log('categories');
      })
    )
    .subscribe((result: MenuItemCategoryDtoPagedResultDto) => {
      this.menuItemCategories = result.items;
      //this.showPaging(result, pageNumber);
    });

    this._menuItemPriceService
    .getAll(
      '',
      0,
      100
    )
    .pipe(
      finalize(() => {
        console.log('prices');
      })
    )
    .subscribe((result: MenuItemPriceDtoPagedResultDto) => {
      this.menuItemPrices = result.items;
      //this.showPaging(result, pageNumber);
    });

    this._menuService
    .getAll(
      '',
      0,
      1000
    )
    .pipe(
      finalize(() => {
        console.log('menus');
      })
    )
    .subscribe((result: MenuDtoPagedResultDto) => {
      this.menus = result.items;
      console.log(this.menus);
    });
  }

  isChecked(id){
    return this.allergyIds.includes(id);
  }

  populateAllergyIds(res: MenuItemAllergyDto[]){
    for(let x=0;x<res.length;x++){
      this.allergyIds.push(res[x].allergyIdFk);
      this.miAllergyIds.push(res[x].id);
    }
    console.log('populated allergyIds',this.allergyIds);
    this.allergyIds2 = this.allergyIds;
    console.log('populated allergyIds2', this.allergyIds2);
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
      .subscribe((res) => {
        this.menuItemId = res.id;
        console.log('update MI',this.menuItemId);
        localStorage.setItem('menuItemId', this.menuItemId.toString());
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
        this.updateMenuItemAllergy();
      });
  }

  show(id){
    this.changed=true;
    console.log(this.changed);
    this.allergyIds2.push(id);
    console.log('add aIds2',this.allergyIds2);
    var count = 0
  for(let x=0;x<this.allergyIds2.length;x++){
    if(id == this.allergyIds2[x]){
      var index1:number;
      var index2:number;
      count++
      if(count == 2){
         index1 = this.allergyIds2.indexOf(id);
         delete this.allergyIds2[index1];
         index2 = this.allergyIds2.indexOf(id);
         delete this.allergyIds2[index2];
        console.log('delete aIds2',this.allergyIds2);
      }
  }
}
this.filtered = this.allergyIds2.filter(function (el){
  return el !=null;
});

this.uniqueSet = this.filtered.filter(function(elem,index,self){
  return index === self.indexOf(elem);
})
console.log('uniqueSet', this.uniqueSet);
}

updateMenuItemAllergy(){
  for(let x=0;x<this.allergyIds.length;x++){
    this.menuItemAllergy.id = this.miAllergyIds[x];
    this.menuItemAllergy.menuItemIdFk =+ localStorage.getItem('menuItemId2');
    this.menuItemAllergy.allergyIdFk = this.allergyIds[x];

    console.log('delete aID',this.menuItemAllergy.allergyIdFk);
    console.log('deleted menuItemId',this.menuItemAllergy.menuItemIdFk);
    //console.log('object MI',this.menuItemAllergy);

    if(this.changed != false){
      this._menuItemAllergyService
      .delete(this.menuItemAllergy.id)
      .pipe(
        finalize(() => {
          console.log('removed allergy', this.menuItemAllergy.allergyIdFk)
        })
      )
      .subscribe(() => {});
    }
  }

  if(this.changed !=false){
    for(let y=0;y<this.uniqueSet.length;y++){

      this.menuItemAllergy.menuItemIdFk =+ localStorage.getItem('menuItemId2');
      this.menuItemAllergy.allergyIdFk = this.uniqueSet[y];

      this._menuItemAllergyService
      .create(this.menuItemAllergy)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        console.log('created allergy', this.menuItemAllergy.allergyIdFk)
        this.bsModalRef.hide();
        this.onSave.emit();
      });
    }
  }







}
}
