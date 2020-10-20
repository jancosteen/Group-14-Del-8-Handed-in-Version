import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { QrCodeDto, QrCodeDtoPagedResultDto, QrCodeSeatingDto, QrCodeServiceProxy, RestaurantDto, RestaurantDtoPagedResultDto, RestaurantServiceProxy, SeatingDto, SeatingDtoPagedResultDto, SeatingServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-checkIn',
  templateUrl: './checkIn.component.html',
})
export class CheckInComponent extends AppComponentBase
implements OnInit {
  title = 'app';
  elementType = 'url';
  value:string;
  user;

  qrCodes:QrCodeDto[]=[];
  seatings:SeatingDto[]=[];
  restaurants:RestaurantDto[]=[];
  restaurantId:number;
  restaurantSelected = false;
  restaurantName:string;
  qrCodeSeating:QrCodeSeatingDto = new QrCodeSeatingDto();
  invalidSelection = false;

  generated=false;
  constructor( private _qrCodeService:QrCodeServiceProxy
      ,private _seatingService: SeatingServiceProxy
      ,private _restaurantService: RestaurantServiceProxy
      ,injector: Injector) {  super(injector);}

  ngOnInit(): void {
    this.value ="";

    this.user = this.appSession.user;
    this._qrCodeService
    .getAll(
      '',
      0,
      1000
    )
    .pipe(
      finalize(() => {
        console.log('qrCodes');
      })
    )
    .subscribe((result: QrCodeDtoPagedResultDto) => {
      this.qrCodes = result.items;
      console.log(this.qrCodes);
      //this.showPaging(result, pageNumber);
    });

    this._restaurantService
    .getAll(
      '',
      0,
      1000
    )
    .pipe(
      finalize(() => {
        console.log('qrCodes');
      })
    )
    .subscribe((result: RestaurantDtoPagedResultDto) => {
      this.restaurants = result.items;
      console.log(this.restaurants);
      //this.showPaging(result, pageNumber);
    });

    this._seatingService
    .getAll(
      '',
      0,
      1000
    )
    .pipe(
      finalize(() => {
        console.log('qrCodes');
      })
    )
    .subscribe((result: SeatingDtoPagedResultDto) => {
      this.seatings = result.items;
      console.log(this.seatings);
      //this.showPaging(result, pageNumber);
    });
  }

  selectRestaurant(id){

    for(let x=0;x<this.restaurants.length;x++){
      if(this.restaurants[x].id === id){
        this.restaurantName = this.restaurants[x].restaurantName;
        break;
      }
    }
    this.restaurantSelected = true;
    console.log(this.restaurantName);
  }

  generateQrCode(item: QrCodeSeatingDto){
    let qrCodeId = item.qrCodeIdFk;
    let seatingId = item.seatingIdFk;

    if(qrCodeId === undefined || seatingId === undefined){
      this.invalidSelection = true;
    } else{
      this.value = qrCodeId+','+seatingId;
      this.generated = true;
      this.invalidSelection = false;
    }


  }

}
