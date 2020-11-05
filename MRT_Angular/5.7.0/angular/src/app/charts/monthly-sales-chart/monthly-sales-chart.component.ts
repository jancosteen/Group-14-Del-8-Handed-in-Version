import { ReservationServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { Component, Injector, OnInit } from '@angular/core';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Color, Label } from 'ng2-charts';

@Component({
  selector: 'app-monthly-sales-chart',
  templateUrl: './monthly-sales-chart.component.html',
  styleUrls: ['./monthly-sales-chart.component.css']
})
export class MonthlySalesChartComponent implements OnInit {

  public lineChartData: ChartDataSets[] = [
    { data: [], label: 'Total Monthly Sales' },
  ];
  public lineChartLabels: Label[] = [];
  public lineChartOptions: ChartOptions = {
    responsive: true,
  };
  public lineChartColors: Color[] = [
    {
      borderColor: 'black',
      backgroundColor: 'rgba(255,0,0,0.3)',
    },
  ];
  public lineChartLegend = true;
  public lineChartType: ChartType = 'line';
  public lineChartPlugins = [];

  constructor(injector: Injector,
    public _service: ReservationServiceProxy) { }

  ngOnInit() {

    //get number of sales for each month
    //console.log('total sales',res)
    this._service.getTotalMonthlySales()
    .subscribe(data => {
      //console.log('object',data);
      //console.log('are bone',data["result"]);
      
      data["result"].forEach(el => {
        this.lineChartLabels.push(el["Month"])
        this.lineChartData[0].data.push(el["Sales"])       
      });
      })
     
      //console.log('labels',this.lineChartLabels);
      //console.log('values',this.lineChartData);
  }

}
