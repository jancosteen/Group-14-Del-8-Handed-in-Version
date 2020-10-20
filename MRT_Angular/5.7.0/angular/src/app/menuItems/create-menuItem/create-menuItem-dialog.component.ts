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
  AllergyDto,
  AllergyDtoPagedResultDto,
  AllergyServiceProxy,
  MenuDto,
  MenuDtoPagedResultDto,
  MenuItemAllergyDto,
  MenuItemAllergyServiceProxy,
  MenuItemCategoryDto,
  MenuItemCategoryDtoPagedResultDto,
  MenuItemCategoryServiceProxy,
  MenuItemDto,
  MenuItemPriceDto,
  MenuItemPriceDtoPagedResultDto,
  MenuItemPriceServiceProxy,
  MenuItemServiceProxy,
  MenuServiceProxy
} from '../../../shared/service-proxies/service-proxies';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  templateUrl: 'create-menuItem-dialog.component.html'
})
export class CreateMenuItemDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  menuItem: MenuItemDto = new MenuItemDto();
  menuItemPrices: MenuItemPriceDto[]=[];
  menuItemCategories: MenuItemCategoryDto[]=[];
  menuItemId:number;
  allergies: AllergyDto[]=[];
  miAllergies:[];
  menuItemAllergy: MenuItemAllergyDto = new MenuItemAllergyDto();
  form: FormGroup;
  allergyIds:any=[];
  allergyId:number;
  filtered:[];
  currentDate;
  sCurrentDate: string;
  menus: MenuDto[]=[];



  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _menuItemService: MenuItemServiceProxy,
    public _menuItemPriceService: MenuItemPriceServiceProxy,
    public _menuItemCategoryService: MenuItemCategoryServiceProxy,
    public _allergyService: AllergyServiceProxy,
    public _menuItemAllergyService: MenuItemAllergyServiceProxy,
    public bsModalRef: BsModalRef,
    private fb: FormBuilder,
    private _menuService: MenuServiceProxy
  ) {
    super(injector);
  }

  ngOnInit(): void {

    this.currentDate = new Date().toISOString().substring(0, 16);
    this.sCurrentDate = this.currentDate.toString();

    this._allergyService
    .getAll(
      '',
      0,
      1000
    )
    .pipe(
      finalize(() => {
        console.log('allergies');
      })
    )
    .subscribe((result: AllergyDtoPagedResultDto) => {
      this.allergies = result.items;
      console.log(this.allergies);
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
  }

  show(id){
      this.allergyIds.push(id);
      console.log('add',this.allergyIds);
      var count = 0
    for(let x=0;x<this.allergyIds.length;x++){
      if(id == this.allergyIds[x]){
        var index1:number;
        var index2:number;
        count++
        if(count == 2){
           index1 = this.allergyIds.indexOf(id);
           delete this.allergyIds[index1];
           index2 = this.allergyIds.indexOf(id);
           delete this.allergyIds[index2];
          console.log('delete',this.allergyIds);
        }
    }
  }
  this.filtered = this.allergyIds.filter(function (el){
    return el !=null;
  });
  console.log('final', this.filtered);
  }

  save(): void {
    this.saving = true;

    this._menuItemService
      .create(this.menuItem)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe((res) => {
        this.menuItemId = res.id;
        console.log('create MI',this.menuItemId);
        localStorage.setItem('menuItemId', this.menuItemId.toString());
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
        this.createMenuItemAllergy();
      });
      localStorage.removeItem('menuItemId');
  }

  createMenuItemAllergy(){
    for(let x=0;x<this.filtered.length;x++){
      this.menuItemAllergy.menuItemIdFk =+ localStorage.getItem('menuItemId');
      this.menuItemAllergy.allergyIdFk = this.filtered[x];

      console.log('allergyId',this.menuItemAllergy.allergyIdFk);
      console.log('menuItemId',this.menuItemAllergy.menuItemIdFk);
      console.log('object MI',this.menuItemAllergy);

      this._menuItemAllergyService
    .create(this.menuItemAllergy)
    .pipe(
      finalize(() => {
        this.saving = false;
      })
    )
    .subscribe(() => {
      this.notify.info(this.l('SavedSuccessfully'));
      this.bsModalRef.hide();
      this.onSave.emit();
    });
    }
  }
}
