import { FormGroup, FormControl } from '@angular/forms';
import { MenuItemDtoPagedResultDto, MenuItemServiceProxy, OrderLineServiceProxy, OrderServiceProxy } from './../../shared/service-proxies/service-proxies';
import { ReservationServiceProxy } from '@shared/service-proxies/service-proxies';
import { Component, OnInit } from '@angular/core';
import { request } from 'http';
import { finalize } from 'rxjs/operators';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import { random } from 'lodash';
import autoTable from 'jspdf-autotable'

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
  reservations;
  item;
  cust=false;
  menuitem=false;
  salesdown=false;
  reser=false;
  x=false;
  y=false;
  z=false;

  menuItemForm = new FormGroup({
    menuitem: new FormControl()
  });

  selection: number = 1;

  constructor(public repo: ReservationServiceProxy,
    public itemrepo: MenuItemServiceProxy,
    public repoOrder: OrderServiceProxy,
    public orderLineService: OrderLineServiceProxy
    ) { }

    //just check this file, i changed some of the repos i.e itemrepo  or orderLineService and one or two function names that wasnt found


  ngOnInit(): void {
    this.x=false;
    this.y=false;
    this.z=false;
    this.cust=false;
    this.menuitem=false;
    this.salesdown=false;
    this.reser=false;

    this.itemrepo
      .getMenuItems()
      .subscribe( x =>  {
        this.menuitems = x;
        //this.menuitems = x["result"]
        console.log('x',x)
        console.log('ites',this.menuitems)
        console.log('check',this.menuitems[0].id)
      })

      this.repo.getReservationByUser()
      .subscribe( res => {
        this.reservations = res;
        //this.reservations = res["result"];
        console.log('items',this.reservations)
      })

  }

  generateReport(){
    this.menuitem=false;
    this.cust=true;
    this.reser=false;
    this.x=true;
    this.y =false;
    this.z = false;
      this.repoOrder.getOrderByUser()
      .subscribe( res => {
        this.items = res;
        //this.items = res["result"];
        console.log('items',this.items)
      })


  }
  SalesbymenuItem(){
    this.cust=false;
    this.menuitem=true;
    this.reser=false;
  }

  ReservationsbyCust(){
    this.cust=false;
    this.menuitem=false;
    this.reser=true;
    this.z=true;
    this.y=false;
    this.x=false;
  }

  generateReport3(menuItemForm){
    this.y = true;
    this.z = false;
    this.x = false;
    this.salesdown=true;
    console.log('valueinini1', menuItemForm.value["menuitem"]);//

    this.orderLineService.salesByMenuItem(menuItemForm.value["menuitem"])
    .subscribe( res => {
      console.log('result',res)
      console.log('result2',res["result"])

      this.items2 = res["result"];
      console.log('items',this.items2)
      //this.items2 = res["result"];

      this.menuitem=true;
    })



  }

  downloadPdf(){
    console.log('custorders')
    let today = new Date().toLocaleDateString()
    var num = random(0,1000,false);
    var data = document.getElementById('Content');
    html2canvas(data,
      {
      useCORS: true,
      allowTaint:true,
      scrollY: -window.screenY
      }).then(canvas => {
        const contentDataUrl = canvas.toDataURL('image/PNG')
        var doc = new jsPDF("p");
        var imgData = new Image();

        imgData.src = './assets/PIC2.png';
        var pageWidth = doc.internal.pageSize.width;
        doc.setFontSize(25);
        doc.addImage(imgData,'PNG',(pageWidth/2) -100,9,85,85);
        doc.text('Orders per Customer',(pageWidth/2)-50,15);
        doc.setFontSize(15);

        doc.text('Report Generated on: ' + today, pageWidth*0.33,30);
        doc.text('Report Id: '+num.toString(), pageWidth*0.33,35);
        doc.setFontSize(10);
        doc.text('This report represents all orders made by each customer', pageWidth*0.33,40);
        doc.setFontSize(20);
       // doc.text('Customer Name : '+CustomerName, pageWidth*0.33,70);
        autoTable(doc,{html: '#Content', startY: 75});
        doc.save("ordersbycustomers.pdf");

    });



  }
  downloadPdf2(menuItemForm){

    let id = menuItemForm.value["menuitem"];
    console.log('ke ye id',id)
    let itemName : string = ""
    console.log('leng',this.menuitems["length"])
    for(let x = 0; x < this.menuitems["length"]; x++){
      console.log('this.menuitems[x].id',this.menuitems[x].id)
      if(this.menuitems[x].id == id){
        itemName = this.menuitems[x].menuItemName
        console.log('itemName',itemName)
      }

    }
    console.log('itemname',itemName)


    console.log('salesby menuitem')
    let today = new Date().toLocaleDateString()
    var num = random(0,1000,false);


    var data = document.getElementById('Content2');
      html2canvas(data,
        {
        useCORS: true,
        allowTaint:true,
        scrollY: -window.screenY
        }).then(canvas => {
          const contentDataUrl = canvas.toDataURL('image/PNG')
          var doc = new jsPDF("p");
          var imgData = new Image();

          imgData.src = './assets/PIC2.png';
          var pageWidth = doc.internal.pageSize.width;
          doc.setFontSize(25);
          doc.addImage(imgData,'PNG',(pageWidth/2) -100,9,85,85);
          doc.text('Sales by Menu Item Report',(pageWidth/2)-50,15);
          doc.setFontSize(15);

          doc.text('Report Generated on: ' + today, pageWidth*0.33,30);
          doc.text('Report Id: '+num.toString(), pageWidth*0.33,35);
          doc.setFontSize(10);
          doc.text('This report represents the sales by the selected menu item', pageWidth*0.33,40);
          doc.setFontSize(20);
          doc.text('Menu Item : '+itemName, pageWidth*0.33,70);
          autoTable(doc,{html: '#Content2', startY: 75});
          doc.save("SalesbymenuItem.pdf");

      });
  }


  downloadPdf3(){
    this.x=false;
    this.y=false;
    this.z = true;
    this.reser = true;
    let today = new Date().toLocaleDateString()
    var num = random(0,1000,false);
    var data = document.getElementById('Content3');
    html2canvas(data,
      {
      useCORS: true,
      allowTaint:true,
      scrollY: -window.screenY
      }).then(canvas => {
        const contentDataUrl = canvas.toDataURL('image/PNG')
        var doc = new jsPDF("p");
        var imgData = new Image();

        imgData.src = './assets/PIC2.png';
        var pageWidth = doc.internal.pageSize.width;
        doc.setFontSize(25);
        doc.addImage(imgData,'PNG',(pageWidth/2) -100,9,85,85);
        doc.text('Reservations per Customer',(pageWidth/2)-50,15);
        doc.setFontSize(15);

        doc.text('Report Generated on: ' + today, pageWidth*0.33,30);
        doc.text('Report Id: '+num.toString(), pageWidth*0.33,35);
        doc.setFontSize(10);
        doc.text('This report represents all reservations made by each customer', pageWidth*0.33,40);
        doc.setFontSize(20);
       // doc.text('Customer Name : '+CustomerName, pageWidth*0.33,70);
        autoTable(doc,{html: '#Content3', startY: 75});
        doc.save('ReservationsByCustomer.pdf');


      });
    }
}
