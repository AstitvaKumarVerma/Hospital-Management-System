///<reference types="@stripe/stripe-js" />

import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Stripe } from '@stripe/stripe-js';
import { ApiService } from 'src/app/services/api.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


@Component({
  selector: 'app-make-payment',
  templateUrl: './make-payment.component.html',
  styleUrls: ['./make-payment.component.css']
})
export class MakePaymentComponent {

  PatientPhone: any;
  PatientId: any;
  formData: any = { doctorId: '', dateAvailable: '', availabilityId: '' };

  formdataString: any;
  bookingdata: any = { availabilityId: '', isBooked: '', bookedBy: '' }
  SendSmsData: any;
  loader: boolean = false;
  striptokendata: any;
  ConvertedAmount: string = '';
  currentUrl: string = '';
  stripe: Stripe | null = null;

  constructor(private serviceCall: ApiService, private router: Router, private _Dialog: MatDialog, public dialogRef: MatDialogRef<MakePaymentComponent>, @Inject(MAT_DIALOG_DATA) public data: any, private toastr: ToastrService) {

  }

  async ngOnInit() {
    this.PatientId = localStorage.getItem('PatientId');
    console.log('this.PatientId: ', this.PatientId);
  
    this.formData = this.data;
    console.warn('formData=> ', this.formData);
  
    try {
      const intPatientId = parseInt(this.PatientId, 10);
      const res: any = await this.serviceCall.GetPatientDataById(intPatientId).toPromise();
      
      console.log("res =>", res);
      this.PatientPhone = res.patientPhone;
      console.log("res.phoneNumber  =>", res.patientPhone);
      
      localStorage.setItem('availabilityId', this.formData.availabilityId);
      localStorage.setItem('phoneNumber', this.PatientPhone);
    } catch (error) {
      console.error("Error:", error);
      // Handle the error condition here
    }
  }
  

  GetPatientPhoneById(Id: number) {
    this.serviceCall.GetPatientDataById(Id).subscribe((res: any) => {
      console.log("res =>", res);
      this.PatientPhone = res.patientPhone;
      console.log("res.phoneNumber  =>", res.patientPhone);
    });
  }


  makePayment(amount: string) {
    console.warn('Amount=> ', amount);

    console.warn('typeof amount=> ', typeof (amount));
    this.serviceCall.MakePaymentApi(amount).subscribe(
      (res: any) => {
        if (res.url) {
          window.location.href = res.url;
        }
        else {
          // Handle error
        }
      },
      (error: any) => console.error('Error:', error)
    );
  }
}