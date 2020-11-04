import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { ServiceProxyModule } from './../../shared/service-proxies/service-proxy.module';
import { SharedModule } from './../../shared/shared.module';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { LayoutModule } from '@angular/cdk/layout';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { ChartsModule } from 'ng2-charts';
import { AppRoutingModule } from './../app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';
import { NgxQRCodeModule } from '@techiediaries/ngx-qrcode/lib/qrcode.module';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgxPaginationModule } from 'ngx-pagination/dist/ngx-pagination.module';
import { TabsModule } from 'ngx-bootstrap/tabs';
//import { DashComponent } from './dash.component';
//import { MonthlySalesChartComponent } from '../charts/monthly-sales-chart/monthly-sales-chart.component';



@NgModule({
  declarations: [
    
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientJsonpModule,
    ModalModule.forChild(),
    BsDropdownModule,
    CollapseModule,
    TabsModule,
    AppRoutingModule,
    ServiceProxyModule,
    SharedModule,
    NgxPaginationModule,
    NgxQRCodeModule,
    ChartsModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    LayoutModule
  ]
})
export class DashModule { }
 