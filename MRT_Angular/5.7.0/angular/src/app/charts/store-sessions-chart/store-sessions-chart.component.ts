import { Component, Injector, OnInit } from '@angular/core';
import { ReservationServiceProxy } from '@shared/service-proxies/service-proxies';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Label } from 'ng2-charts';

@Component({
  selector: 'app-store-sessions-chart',
  templateUrl: './store-sessions-chart.component.html',
  styleUrls: ['./store-sessions-chart.component.css']
})
export class StoreSessionsChartComponent implements OnInit {

  public barChartOptions: ChartOptions = {
    responsive: true,
  };
  public barChartLabels: Label[] = ['2006', '2007', '2008', '2009', '2010', '2011', '2012'];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [];

  public barChartData: ChartDataSets[] = [
    { data: [65, 59, 80, 81, 56, 55, 40], label: 'Series A' },
    { data: [28, 48, 40, 19, 86, 27, 90], label: 'Series B' }
  ];

  constructor(injector: Injector,
    public _service: ReservationServiceProxy) { }

  ngOnInit() {
    this._service.getTotalTodayOrders()
      .subscribe(data => {
        console.log('object',data);
        console.log('are bone',data["result"][0].Day);
        console.log('are bone',data["result"][0].Num);
        this.barChartData[0].label = data["result"][0].Day;
        this.barChartData[1].label = data["result"][1].Day;
        this.barChartData[0].data = data["result"][0].Num;
        this.barChartData[1].data = data["result"][1].Num;   


      })
  }

}
