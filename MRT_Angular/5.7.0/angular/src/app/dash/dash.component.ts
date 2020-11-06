
import { OrderDto } from './../../shared/service-proxies/service-proxies';
import { ReservationServiceProxy } from '@shared/service-proxies/service-proxies';
import { Component, OnInit, ViewChild } from '@angular/core';
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { MatTable, MatTableDataSource } from '@angular/material/table';



@Component({
  selector: 'dash',
  templateUrl: './dash.component.html',
  styleUrls: ['./dash.component.css']
})
export class DashComponent implements OnInit {
Orders : OrderDto[];
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
    this.repo.getTotalTodayOrders()
    .subscribe( x=> {
      this.Orders = x as OrderDto[]
      console.log('this',this.Orders)
    })

  }


 
 addbut(){
   window.alert("addbutton");
 }
 editbut(){
   window.alert("editbutton");
 }
}
