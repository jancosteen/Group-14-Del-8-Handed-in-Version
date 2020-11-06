import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@Injectable()
export class repo {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "";
    }





    private createCompleteRoute = (envAddress: string, route: string) => {
        // console.log('address',envAddress + '/' + route);
         return envAddress + '/' + route;
       }

    sendMessage(smsdetails) {
        console.log('2nddto', smsdetails)
        let url = this.baseUrl + "/api/services/app/Reservation/SendEmail";
        url = url.replace(/[?&]$/, "");
       // const content = JSON.stringify(smsdetails); 
        return this.http.post(url,smsdetails);
        //http://localhost:21021/api/services/app/Reservation/SendMessage
    }

    getTotalMonthlySales(){
        let url = this.baseUrl + "/api/services/app/OrderLine/TotalNumberOfSales";
        url = url.replace(/[?&]$/, "");
        return this.http.get(url);
    }

    getTotalTodayOrders(){
        let url = this.baseUrl + "/api/services/app/OrderLine/TodayOrders";
        url = url.replace(/[?&]$/, "");
        return this.http.get(url);
    }
} 