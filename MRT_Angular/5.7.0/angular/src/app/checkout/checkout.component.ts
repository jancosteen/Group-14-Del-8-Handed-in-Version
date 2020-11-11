import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { OrderServiceProxy } from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  total;
  public checkoutForm : FormGroup;

  currentDate;



  constructor(public _orderService: OrderServiceProxy,
    public _router: Router) {

      this.checkoutForm = new FormGroup({
        cardNumer: new FormControl('',[Validators.required, Validators.maxLength(16)]),
        cardExpire: new FormControl('',[Validators.required, Validators.min(this.currentDate)]),
        cardCvc: new FormControl('',[Validators.required, Validators.maxLength(3)]),
        cardName: new FormControl('',[Validators.required]),
      });
  }

  public validateControl = (controlName: string) => {
    if (this.checkoutForm.controls[controlName].invalid && this.checkoutForm.controls[controlName].touched)
      return true;

    return false;
  }

  public hasError = (controlName: string, errorName: string) => {
    if (this.checkoutForm.controls[controlName].hasError(errorName))
      return true;

    return false;
  }


  minDate = moment(new Date).format("MM-YYYY")

  ngOnInit(): void {
    this.total = localStorage.getItem('totalamount');
    this.currentDate = new Date().toISOString().substring(0, 16);
  }

  checkout(){
    this.backToHome();
    abp.notify.success('You have successfully Paid!!!',"Payment");

  }
  backToHome(): void {
    const detailsUrl: string = `/app/home`;
    this._router.navigate([detailsUrl]);
  }

}
