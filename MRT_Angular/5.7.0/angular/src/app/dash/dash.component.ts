
import { OrderDto } from './../../shared/service-proxies/service-proxies';
import { ReservationServiceProxy } from '@shared/service-proxies/service-proxies';
import { Component, OnInit, ViewChild } from '@angular/core';
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { jsPDF } from "jspdf";
import html2canvas from 'html2canvas';



@Component({
  selector: 'dash',
  templateUrl: './dash.component.html',
  styleUrls: ['./dash.component.css']
})
export class DashComponent implements OnInit {
Orders : OrderDto[];

items;
options={
  timeOut: 3000,
  showProgressBar: true,
  pauseOnHover: true,
  clickToClose: true
};

  /** Based on the screen size, switch from standard to one column per row */
  cardLayout = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
    map(({ matches }) => {
      if (matches) {
        return {
          columns: 1,
          miniCard: { cols: 1, rows: 1 },
          chart: { cols: 1, rows: 2 },
          table: { cols: 1, rows: 4 },
        };
      }

      return {
        columns: 4,
        miniCard: { cols: 1, rows: 1 },
        chart: { cols: 2, rows: 2 },
        table: { cols: 4, rows: 4 },
      };
    })
  );

  constructor(private breakpointObserver: BreakpointObserver,
    public repo: ReservationServiceProxy) {
     

    }

  ngOnInit(){ 
    this.repo.getReservationByuser()
      .subscribe( res => {
        this.items = res["result"];
        console.log('items',this.items)
      })

  }

  downloadpdf(){
    var el = document.getElementById('ResbyCus');
    html2canvas(el).then(canvas => {
      
      var imgWidth = 208;
      var pageHeight = 295;
      var imgHeight = canvas.height * imgWidth /canvas.width;
      var heightLeft = imgHeight;
      const imgData = canvas.toDataURL('image/png');

      const doc = new jsPDF('p','mm','a4');
      
      doc.text("Reservations By Customer",80,20)
      doc.addImage(imgData,'PNG',120,40,120,100)
      setTimeout(function(){
        doc.save("ReservationsByCustomer.pdf")
        },2000);
      
    })

  }

}
