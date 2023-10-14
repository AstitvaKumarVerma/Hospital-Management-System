import { NgModule } from '@angular/core';
import { DatePipe } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CommonModule } from '@angular/common';
import { BookAppointmentComponent } from './book-appointment/book-appointment.component';
import { MakePaymentComponent } from './make-payment/make-payment.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { PatientRoutingModule } from './patient-routing.module';
import { MatIconModule } from '@angular/material/icon';

import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { EditPatientComponent } from './edit-patient/edit-patient.component';
import { PatientDetailsComponent } from './patient-details/patient-details.component';
import { DoctorListForAppointmentComponent } from './doctor-list-for-appointment/doctor-list-for-appointment.component'
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { EditPateintProfileComponent } from './edit-pateint-profile/edit-pateint-profile.component';
import { PatientAppoinmentsComponent } from './patient-appoinments/patient-appoinments.component';
import { SuccessPaymentComponent } from './success-payment/success-payment.component';
import { FailurePaymentComponent } from './failure-payment/failure-payment.component';
import { NgxPaginationModule } from 'ngx-pagination';
@NgModule({
  declarations: [
    BookAppointmentComponent,
    MakePaymentComponent,
    EditPatientComponent,
    PatientDetailsComponent,
    DoctorListForAppointmentComponent,
    EditPateintProfileComponent,
    PatientAppoinmentsComponent,
    SuccessPaymentComponent,
    FailurePaymentComponent
  ],
  imports: [
    CommonModule,
    PatientRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatInputModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatTableModule,
    MatSortModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSnackBarModule,
    MatIconModule,
    MatSelectModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    NgxPaginationModule
  ],
  providers: [ DatePipe ]
})
export class PatientModule { }
