import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorsListComponent } from './doctors-list/doctors-list.component';
import { DoctorDetailsComponent } from './doctor-details/doctor-details.component';
import { AddAvailabilityComponent } from './add-availability/add-availability.component';
import { DoctorProfileComponent } from './doctor-profile/doctor-profile.component';
import { AuthGuard } from '../Auth/auth.guard';
import { DoctorEventsComponent } from './doctor-events/doctor-events.component';


const routes: Routes = [
    { path: '', component: DoctorsListComponent, canActivate :[AuthGuard] },
    { path:'doctor-profile', component:DoctorProfileComponent, canActivate :[AuthGuard] },
    { path:'doctor-details', component:DoctorDetailsComponent, canActivate :[AuthGuard]},
    { path:'doctor-events', component:DoctorEventsComponent, canActivate :[AuthGuard]},
    { path:'doctor-Availability', component:AddAvailabilityComponent, canActivate :[AuthGuard]}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProvidersRoutingModule { }