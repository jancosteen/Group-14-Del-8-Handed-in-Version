import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuDto, MenuDtoListResultDto, MenuServiceProxy, QrCodeDto, QrCodeSeatingDto, QrCodeSeatingServiceProxy, QrCodeServiceProxy, RestaurantDto } from '@shared/service-proxies/service-proxies';

export class OperationResponse {
  code: number = 0;
  message: string = '';
  exceptionDetail: string = '';
  object: any = null;
}

export class Appointment {
  identifier: string = '';

  constructor(identifier: string) {
      this.identifier = identifier;
  }
}

@Component({
  selector: 'app-qr-code-scanner',
  templateUrl: './qr-code-scanner.component.html',
  styleUrls: ['./qr-code-scanner.component.css']
})
export class QrCodeScannerComponent implements OnInit {

  public scannerEnabled: boolean = false;
  public transports: Transport[] = [];
  information;
  qrCode:QrCodeDto = new QrCodeDto();
  qrCodeSeating: QrCodeSeatingDto = new QrCodeSeatingDto();
  menu: MenuDto[]=[];
  menuId:number;

  constructor(private cd: ChangeDetectorRef,
    private _router:Router,
    private _qrCodeService: QrCodeServiceProxy,
    private _menuService: MenuServiceProxy,
    private _qrCodeSeatingService: QrCodeSeatingServiceProxy) { }

  ngOnInit(): void {
  }

  public scanSuccessHandler($event: any) {
    this.scannerEnabled = false;
    this.information = $event;
    console.log('scan result', this.information);
    localStorage.setItem('qrCodeSeatingId',this.information);
    localStorage.setItem('checkedIn', 'true');
    console.log(localStorage.getItem('checkedIn'));
    this.getQCSDetails();

  }

  getQCSDetails(){
    this._qrCodeSeatingService
    .get(this.information)
    .subscribe((result:QrCodeSeatingDto) =>{
      this.qrCodeSeating = result;
      console.log('qcs Details', this.qrCodeSeating);
      this.getQCDetails();
    })
  }

  getQCDetails(){
    this._qrCodeService
      .get(this.qrCodeSeating.qrCodeIdFk)
      .subscribe((result:QrCodeDto) =>{
        this.qrCode = result;
        console.log('qrCode details', this.qrCode);
        this.getMenuDetails();
      })
  }

  getMenuDetails(){
    this._menuService
      .getMenuByResId(this.qrCode.restaurantIdFk)
        .subscribe((result:MenuDtoListResultDto) =>{
          this.menu = result.items;
          this.menuId = this.menu[0].id;
          console.log('menuDetails', this.menu[0]);
          this.goToMenu();
        })
  }

  goToMenu(){
    const detailsUrl: string = `/app/cusMenu2/${this.menuId}`;
    this._router.navigate([detailsUrl]);
  }

  public enableScanner() {
    this.scannerEnabled = !this.scannerEnabled;
    console.log('scanner enabled');
  }

}

interface Transport {
  plates: string;
  slot: Slot;
}

interface Slot {
  name: string;
  description: string;
}
