import { ReservationServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { Component, Injector, OnInit } from '@angular/core';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { repo } from '@shared/service-proxies/repo';

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

  public lineChartColors: Color[] = [
    {
      backgroundColor: 'rgba(148,159,177,0.2)',
      borderColor: 'rgba(148,159,177,1)',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    },
  ];
  public lineChartLegend = true;
  public lineChartType: ChartType = 'line';
  public lineChartPlugins = [];

  constructor(injector: Injector,
    public _service: ReservationServiceProxy,
    public _repo: repo) { }

  ngOnInit() {

    //get number of sales for each month
    //console.log('total sales',res)
    this._repo.getTotalMonthlySales()
    .subscribe(data => {
      //console.log('object',data);
      //console.log('are bone',data["result"]);

      data["result"].forEach(el => {
        this.lineChartLabels.push(el["Month"])
        this.lineChartData[0].data.push(el["Sales"])
      });
      })

  }
  public lineChartOptions: (ChartOptions) = {
    responsive: true,

  };

  public chartClicked({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }

  public chartHovered({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(event, active);
  }

}
