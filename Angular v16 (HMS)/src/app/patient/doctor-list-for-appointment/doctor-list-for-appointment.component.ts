import { Component, Inject, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BookAppointmentComponent } from '../book-appointment/book-appointment.component';

@Component({
  selector: 'app-doctor-list-for-appointment',
  templateUrl: './doctor-list-for-appointment.component.html',
  styleUrls: ['./doctor-list-for-appointment.component.css']
})
export class DoctorListForAppointmentComponent {
  displayedColumns: string[] = ['doctorName', 'gender', 'doctorPhone', 'BookAppointment'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private router: Router, private serviceCall: ApiService, private _Dialog: MatDialog, private snackBar: MatSnackBar) {

  }

  ngOnInit() {
    this.GetAllDoctorsData();
  }

  GetAllDoctorsData() {
    this.serviceCall.GetAllDoctorsList().subscribe((response: any) => {
      console.log('response:', response.doctorsData);

      this.dataSource = new MatTableDataSource<any>(response.doctorsData);

      // After initializing, set the paginator and sort
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    })
  }

  openBookAppointmentDialog(doctorId: any, doctorName: string) {
    const dialogRef = this._Dialog.open(BookAppointmentComponent, {
      width: '400px', // Adjust the width as needed
      data: { doctorId: doctorId, doctorName: doctorName },
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
