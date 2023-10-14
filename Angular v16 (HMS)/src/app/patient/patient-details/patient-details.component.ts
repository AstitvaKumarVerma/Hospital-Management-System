import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-patient-details',
  templateUrl: './patient-details.component.html',
  styleUrls: ['./patient-details.component.css']
})
export class PatientDetailsComponent {
  patietId: any;
  PatientData: any;
  currentDate!: Date;

  constructor(private serviceCall: ApiService, private snackBar: MatSnackBar, public dialogRef: MatDialogRef<PatientDetailsComponent>, @Inject(MAT_DIALOG_DATA) public data: any) 
  {
    
  }

  ngOnInit(){
    this.currentDate = new Date();

    this.patietId = this.data;

    this.GetPatientDataById(this.patietId);
  }

  GetPatientDataById(Id : any){
    this.serviceCall.GetPatientDataById(Id).subscribe((response:any) => {
      this.PatientData = response;
      console.log('this.PatientData: ',this.PatientData);
    })
  }

}
