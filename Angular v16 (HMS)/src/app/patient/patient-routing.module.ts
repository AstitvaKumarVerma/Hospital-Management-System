import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PatientListComponent } from './patient-list/patient-list.component';
import { BookAppointmentComponent } from './book-appointment/book-appointment.component';
import { EditPatientComponent } from './edit-patient/edit-patient.component';
import { PatientDetailsComponent } from './patient-details/patient-details.component';
import { DoctorListForAppointmentComponent } from './doctor-list-for-appointment/doctor-list-for-appointment.component';
import { AuthGuard } from '../Auth/auth.guard';
import { PatientProfileComponent } from './patient-profile/patient-profile.component';
import { PatientAppoinmentsComponent } from './patient-appoinments/patient-appoinments.component';
import { SuccessPaymentComponent } from './success-payment/success-payment.component';
import { FailurePaymentComponent } from './failure-payment/failure-payment.component';


const routes: Routes = [
    { path:'', component: PatientListComponent, canActivate :[AuthGuard] },
    { path:'patient-profile', component:PatientProfileComponent, canActivate :[AuthGuard] },
    { path:'patient-appoinments', component:PatientAppoinmentsComponent, canActivate :[AuthGuard] },
    { path:'edit-patient', component:EditPatientComponent, canActivate :[AuthGuard] },
    { path:'patient-details', component:PatientDetailsComponent, canActivate :[AuthGuard] },
    { path:'doctor-list-for-appointment', component:DoctorListForAppointmentComponent, canActivate :[AuthGuard] },
    { path:'book', component:BookAppointmentComponent, canActivate :[AuthGuard] },
    { path:'success-payment', component:SuccessPaymentComponent },
    { path:'fail-payment', component:FailurePaymentComponent }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PatientRoutingModule { }