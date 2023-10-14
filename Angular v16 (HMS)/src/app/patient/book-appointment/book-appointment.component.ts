import { Component, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DatePipe } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { MakePaymentComponent } from '../make-payment/make-payment.component';

@Component({
  selector: 'app-book-appointment',
  templateUrl: './book-appointment.component.html',
  styleUrls: ['./book-appointment.component.css']
})
export class BookAppointmentComponent {
  DoctorId: any;
  appointmentForm!: FormGroup;

  timeSlots: any[] = [];
  DoctorName: any;

  minDate: Date;
  selectedDate: any;
  PatientId: any;

  bookingdata: any = { availabilityId: '', isBooked: '', bookedBy: '' }
  SendSmsData: any;
  PatientPhone: any;
  loader: boolean = false;
  constructor(private serviceCall: ApiService, private _Dialog: MatDialog, private datePipe: DatePipe, private snackBar: MatSnackBar, private fb: FormBuilder, public dialogRef: MatDialogRef<BookAppointmentComponent>, @Inject(MAT_DIALOG_DATA) public data: any, private toastr: ToastrService,
  private route:Router) {
    this.minDate = new Date()

    this.appointmentForm = this.fb.group({
      doctorId: [data.doctorId],
      doctorName: [{ value: data.doctorName, disabled: true }, Validators.required],
      dateAvailable: ['', Validators.required],
      availabilityId: ['', Validators.required],
    });
  }

  ngOnInit() {

    this.PatientId = localStorage.getItem('PatientId')
    console.log('this.PatientId: ', this.PatientId);

    this.DoctorId = this.data.doctorId;
    console.log("this.doctorId", this.DoctorId);

    this.appointmentForm.patchValue({
      doctorName: this.data.doctorName
    })
    this.GetPatientDataById(this.PatientId);
  }

  GetPatientDataById(Id: any) {
    this.serviceCall.GetPatientDataById(Id).subscribe((res: any) => {
      this.PatientPhone = res.patientPhone;
    })
  }

  onChangeEvents() {
    const selectedDateControl = this.appointmentForm.get('dateAvailable');

    if (selectedDateControl?.value) {
      const selectedDate = new Date(selectedDateControl.value);

      const selectedDateISO = selectedDate.toString();
      //this.selectedDate = selectedDateISO.split('T')[0];
      // Use DatePipe to format the date
      this.selectedDate = this.datePipe.transform(selectedDateISO, 'yyyy-MM-dd');

      if (this.selectedDate && this.DoctorId) {
        this.serviceCall.GetAvailableSlotByDoctorId(this.DoctorId, this.selectedDate).subscribe((res: any) => {
          this.timeSlots = res.availableSlots;
          console.warn(this.timeSlots);
        });
      }
    }
  }

  onPayment(){
    this._Dialog.open(MakePaymentComponent, {data: this.appointmentForm.value})
  }
}

