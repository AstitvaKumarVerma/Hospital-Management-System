import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { DoctorsListComponent } from './doctors-list/doctors-list.component';
import { AddAvailabilityComponent } from './add-availability/add-availability.component';
import { ProvidersRoutingModule } from './providers-routing.module';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { AddDoctorComponent } from './add-doctor/add-doctor.component';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { EditDoctorComponent } from './edit-doctor/edit-doctor.component';
import { DoctorDetailsComponent } from './doctor-details/doctor-details.component';
import { DoctorProfileComponent } from './doctor-profile/doctor-profile.component';
import { DoctorEventsComponent } from './doctor-events/doctor-events.component';
import { FullCalendarModule } from '@fullcalendar/angular';
import { CalendarOptions } from '@fullcalendar/core';
import { DoctorEventsInDialogComponent } from './doctor-events-in-dialog/doctor-events-in-dialog.component';
import { EditDoctorProfileComponent } from './edit-doctor-profile/edit-doctor-profile.component';

@NgModule({
  declarations: [
    DoctorsListComponent,
    AddAvailabilityComponent,
    AddDoctorComponent,
    EditDoctorComponent,
    DoctorDetailsComponent,
    DoctorProfileComponent,
    DoctorEventsComponent,
    DoctorEventsInDialogComponent,
    EditDoctorProfileComponent
  ],
  imports: [
    CommonModule,
    ProvidersRoutingModule,
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
    MatButtonModule,
    MatSelectModule,
    MatCardModule,
    FullCalendarModule
  ]
})
export class ProvidersModule { }
