import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ApiService } from 'src/app/services/api.service';
import { EditDoctorProfileComponent } from '../edit-doctor-profile/edit-doctor-profile.component';

@Component({
  selector: 'app-doctor-profile',
  templateUrl: './doctor-profile.component.html',
  styleUrls: ['./doctor-profile.component.css']
})
export class DoctorProfileComponent {
  DoctorId: any;
  DoctorData: any;

  constructor(private serviceCall:ApiService, private _Dialog: MatDialog){

  }

  ngOnInit(){
    this.DoctorId = localStorage.getItem('DoctorId')
    console.log('this.DoctorId: ', this.DoctorId);
    this.GetDoctorDataById(this.DoctorId);
  }
  
  editProfile(){
    this._Dialog.open(EditDoctorProfileComponent, { data: this.DoctorId })
  }

  GetDoctorDataById(Id: any){
    this.serviceCall.GetDoctorDataById(Id).subscribe((res:any) => {
      this.DoctorData = res;
    })
  }
}
