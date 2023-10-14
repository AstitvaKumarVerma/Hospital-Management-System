import { Component, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ApiService } from 'src/app/services/api.service';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { EditPatientComponent } from '../edit-patient/edit-patient.component';
import { PatientDetailsComponent } from '../patient-details/patient-details.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css'],
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, MatTableModule, MatSortModule, MatPaginatorModule, MatIconModule],
})
export class PatientListComponent {
  displayedColumns: string[] = ['patientId', 'patientName', 'fatherName', 'patientDob', 'patientPhone', 'gender', 'Delete', 'ViewDetails'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  role: any;
  PatientId: any;

  constructor(private serviceCall: ApiService, private _Dialog: MatDialog, private snackBar: MatSnackBar, private toastr: ToastrService) {

  }

  ngOnInit() {
    this.role = localStorage.getItem('Role')
    console.log('Role: ', this.role);

    this.PatientId = localStorage.getItem('PatientId')
    console.log('this.PatientId: ', this.PatientId);

    this.GetAllPatientData();
  }

  GetAllPatientData() {
    this.serviceCall.GetAllPatientsList().subscribe((response: any) => {
      console.log('response:', response.patientsData);

      this.dataSource = new MatTableDataSource<any>(response.patientsData);

      // After initializing, set the paginator and sort
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    })
  }

  // goToEditPatient(patientData: any) {
  //   if (this.role == 'Patient') {
  //     this._Dialog.open(EditPatientComponent, { data: patientData });
  //   }
  //   else {
  //     this.toastr.error('You are not Auhorized', '', {
  //       timeOut: 1000,
  //     });
  //   }
  // }

  DeletePatient(patientId: any) {
    if (this.role == 'Admin' || this.role == 'Patient') {
      console.warn('patientId: ', patientId);
      if (confirm("Are you sure to delete ?")) {
        this.serviceCall.DeletePatientById(patientId).subscribe(response => {
          this.snackBar.open('Delete Successfully....', 'Undo', {
            duration: 1000
          });
          this.GetAllPatientData();
        });
      }
    }
    else {
      this.toastr.error('You are not Auhorized', '', {
        timeOut: 1000,
      });
    }
  }

  ViewPatientDetails(patientId: any) {
    if (this.role == 'Admin' || this.role == 'Provider' || this.PatientId == patientId) {
      this._Dialog.open(PatientDetailsComponent, {
        width: '290px',   
        height: '550px',  
        data: patientId
      })
    }
    else {
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



