import { FormGroup, FormControl } from '@angular/forms';
import { MenuItemDtoPagedResultDto, MenuItemServiceProxy, OrderLineServiceProxy } from './../../shared/service-proxies/service-proxies';
import { ReservationServiceProxy } from '@shared/service-proxies/service-proxies';
import { Component, OnInit } from '@angular/core';
import { request } from 'http';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  keyword = '';
  isActive: boolean | null;
  items;
  items2;
  menuitems;
  item;
  cust=false;
  menuitem=false;
  salesdown=false;
  x=false;
  y=false;
  options = [
    {id:1,text:"Orders By Customer"},
    {id:1,text:""}
  ]
  menuItemForm = new FormGroup({
    menuitem: new FormControl()
  });

  selection: number = 1;

  constructor(public repo: ReservationServiceProxy,
    public itemrepo: MenuItemServiceProxy,
    public orderlinerepo: OrderLineServiceProxy) { }
 

  ngOnInit(): void {
    this.x=false;
    this.y=false;
    this.cust=false;
    this.menuitem=false;
    this.salesdown=false;

    this.itemrepo
      .getMenuItems()
      .subscribe( x =>  {
        this.menuitems = x["result"]
        console.log('ites',this.menuitems)
      })

  }

  generateReport(){
    this.menuitem=false;
    this.cust=true;
    this.x=true;
      this.repo.getOrderByuser()
      .subscribe( res => {
        this.items = res["result"];
        console.log('items',this.items)
      })
    
    
  }
  SalesbymenuItem(){
    this.cust=false;
    this.menuitem=true;
  }
  
  generateReport3(menuItemForm){
    this.salesdown=true;
    console.log('valueinini1', menuItemForm.value["menuitem"])
    
    this.orderlinerepo.SalesByMenuItem(menuItemForm.value["menuitem"])
    .subscribe( res => {
      this.items2 = res["result"];
      console.log('items',this.items2)
    })

    this.menuitem=true;
    
  }

  downloadPdf(){
    console.log('custorders')
  }
  downloadPdf2(){
    console.log('salesby menuitem')
  }

}
