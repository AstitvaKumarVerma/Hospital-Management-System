import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-doctor-details',
  templateUrl: './doctor-details.component.html',
  styleUrls: ['./doctor-details.component.css']
})
export class DoctorDetailsComponent {
  doctorId: any;
  DoctorData: any;
  currentDate!: Date;

  constructor(private serviceCall: ApiService, private snackBar: MatSnackBar, public dialogRef: MatDialogRef<DoctorDetailsComponent>, @Inject(MAT_DIALOG_DATA) public data: any) 
  {
    
  }

  ngOnInit(){
    this.currentDate = new Date();

    this.doctorId = this.data;
    console.log('this.doctorId: ',this.doctorId)

    this.GetDoctorDataById(this.doctorId);
  }

  GetDoctorDataById(Id : any){
    this.serviceCall.GetDoctorDataById(Id).subscribe((response:any) => {
      this.DoctorData = response;
      console.log('this.DoctorData: ',this.DoctorData);
    })
  }

}
