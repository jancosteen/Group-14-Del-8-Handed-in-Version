import { Component, OnInit } from '@angular/core';
import { QrCodeDto, QrCodeDtoPagedResultDto, QrCodeSeatingDto, QrCodeSeatingServiceProxy, QrCodeServiceProxy, RestaurantDto, RestaurantDtoPagedResultDto, RestaurantServiceProxy, SeatingDto, SeatingDtoPagedResultDto, SeatingServiceProxy } from '@shared/service-proxies/service-proxies';
import { timeStamp } from 'console';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-qr-code-generator',
  templateUrl: './qr-code-generator.component.html',
  styleUrls: ['./qr-code-generator.component.css']
})
export class QrCodeGeneratorComponent implements OnInit {
  title = 'app';
  elementType = 'url';
  value:string;

  qrCodes:QrCodeDto[]=[];
  seatings:SeatingDto[]=[];
  restaurants:RestaurantDto[]=[];
  restaurantId:number;
  restaurantSelected = false;
  restaurantName:string;
  qrCodeSeating:QrCodeSeatingDto = new QrCodeSeatingDto();
  invalidSelection = false;
  qrCodeSeatingId:number;

  generated=false;
  constructor( private _qrCodeService:QrCodeServiceProxy
      ,private _seatingService: SeatingServiceProxy
      ,private _restaurantService: RestaurantServiceProxy
      ,private _qrCodeSeatingSerive: QrCodeSeatingServiceProxy) { }

  ngOnInit(): void {
    this.value ="";

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

  //qrcodeId,seatingId
  generateQrCode(item: QrCodeSeatingDto){
    let qrCodeId = item.qrCodeIdFk;
    let seatingId = item.seatingIdFk;

    this.qrCodeSeating.qrCodeIdFk = qrCodeId;
    this.qrCodeSeating.seatingIdFk = seatingId;
    this.qrCodeSeating.nrOfPeople = 4;


    if(qrCodeId === undefined || seatingId === undefined){
      this.invalidSelection = true;
    } else{
      this._qrCodeSeatingSerive.create(this.qrCodeSeating)
      .pipe(
        finalize(() => {
          console.log('qrcs pipe');
        })
      )
      .subscribe((result) => {
        this.qrCodeSeatingId = result.id;
        console.log(this.qrCodeSeatingId);
        this.value = this.qrCodeSeatingId.toString();
        this.generated = true;
        this.invalidSelection = false;
      });
    }


  }

}
