import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ApiService } from 'src/app/services/api.service';
import { AddDoctorComponent } from '../add-doctor/add-doctor.component';
import { EditDoctorComponent } from '../edit-doctor/edit-doctor.component';
import { DoctorDetailsComponent } from '../doctor-details/doctor-details.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-doctors-list',
  templateUrl: './doctors-list.component.html',
  styleUrls: ['./doctors-list.component.css']
})
export class DoctorsListComponent {
  displayedColumns: string[] = ['doctorId', 'doctorName', 'gender', 'doctorEmail', 'doctorPhone', 'Edit', 'Delete', 'ViewDetails'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  role: any;
  DoctorId: any;

  constructor(private serviceCall: ApiService, private _Dialog: MatDialog, private snackBar: MatSnackBar, private toastr: ToastrService) {

  }

  ngOnInit() {
    this.role = localStorage.getItem('Role')
    console.log('Role: ', this.role);

    this.DoctorId = localStorage.getItem('DoctorId')
    this.GetAllDoctorsData();
  }

  GoToAddDoctor() {
    if (this.role == 'Admin') {
      this._Dialog.open(AddDoctorComponent)
    }
    else{
      this.toastr.error('You are not Auhorized', '', {
        timeOut: 1000,
      });
    }
    
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

  goToEditDoctor(doctorData: any) {
    if (this.role == 'Admin' || this.DoctorId == doctorData.doctorId) {
      this._Dialog.open(EditDoctorComponent, { data: doctorData })
    }
    else {
      this.toastr.error('You are not Auhorized', '', {
        timeOut: 1000,
      });
    }
  }

  DeleteDoctor(doctorId: any) {
    if (this.role == 'Admin' || this.DoctorId == doctorId) {
      console.warn('doctorId: ', doctorId);
      if (confirm("Are you sure to delete ?")) {
        this.serviceCall.DeleteDoctorById(doctorId).subscribe(response => {
          this.snackBar.open('Delete Successfully....', 'Undo', {
            duration: 1000
          });
          this.GetAllDoctorsData();
        });
      }
    }
    else {
      this.toastr.error('You are not Auhorized', '', {
        timeOut: 1000,
      });
    }

  }

  ViewDoctorDetails(doctorId: any) {
    if (this.role == 'Admin' || this.DoctorId ==doctorId) {
      this._Dialog.open(DoctorDetailsComponent, { data: doctorId })
    }
    else{
      this.toastr.error('You are not Auhorized', '', {
        timeOut: 1000,
      });
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}