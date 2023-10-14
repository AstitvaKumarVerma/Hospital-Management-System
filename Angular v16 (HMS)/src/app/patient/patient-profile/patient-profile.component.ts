import { Component } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { EditPateintProfileComponent } from '../edit-pateint-profile/edit-pateint-profile.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-patient-profile',
  templateUrl: './patient-profile.component.html',
  styleUrls: ['./patient-profile.component.css']
})
export class PatientProfileComponent {
  PatientId: any;
  PatientData: any;

  constructor(private serviceCall:ApiService, private _Dialog: MatDialog){

  }

  ngOnInit(){
    this.PatientId = localStorage.getItem('PatientId')
    console.log('this.PatientId: ', this.PatientId);
    this.GetPatientProfileDataById(this.PatientId);
  }

  editProfile(){
    this._Dialog.open(EditPateintProfileComponent, { data: this.PatientId })
  }

  GetPatientProfileDataById(Id: any){
    this.serviceCall.GetPatientProfileDataById(Id).subscribe((res:any) => {
      this.PatientData = res;
    })
  }
}
