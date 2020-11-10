import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

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

  constructor(private cd: ChangeDetectorRef,
    private _router:Router) { }

  ngOnInit(): void {
  }

  public scanSuccessHandler($event: any) {
    this.scannerEnabled = false;
    this.information = $event;
    console.log('scan result', this.information);
    localStorage.setItem('checkedIn', 'true');
    console.log(localStorage.getItem('checkedIn'));
    this.goToMenu();
  }

  goToMenu(){
    const detailsUrl: string = `/app/home`;
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
