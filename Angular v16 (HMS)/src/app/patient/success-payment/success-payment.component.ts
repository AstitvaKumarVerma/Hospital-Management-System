import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-success-payment',
  templateUrl: './success-payment.component.html',
  styleUrls: ['./success-payment.component.css']
})
export class SuccessPaymentComponent {
  PatientId: any;
  formData: any;
  bookingdata: any = { availabilityId: '', isBooked: '', bookedBy: '' }
  SendSmsData: any;
  PatientPhone: any;
  formDataString: any;
  currentUrl: string = '';
  paymentData: any;
  constructor(private serviceCall: ApiService, private router: Router, private toastr: ToastrService) {

  }


  ngOnInit() {
    this.PatientId = localStorage.getItem('PatientId')

    const availabilityId = localStorage.getItem('availabilityId');
    const phoneNumber = localStorage.getItem('phoneNumber');

    this.bookingdata = { availabilityId: availabilityId, isBooked: true, bookedBy: this.PatientId }
    console.warn("this.bookingdata=> ", this.bookingdata);

    this.SendSmsData = { userId: this.PatientId, SlotAvailabilityId: availabilityId, toPhoneNumber: phoneNumber }
    console.warn("this.SendSmsData=> ", this.SendSmsData);

    this.SlotBook();
  }


  SlotBook() {
    this.serviceCall.SlotBooking(this.bookingdata).subscribe((res: any) => {
      console.warn('Slot Booked');
    });
    this.serviceCall.SendSMS(this.SendSmsData).subscribe((res: any) => {
      console.warn("Message: ", res.Message);
      //alert('Your Slot has Been booked');

      this.toastr.success('Your Slot has Been booked', '', {
        timeOut: 2000,
      });
    });
  }
}
