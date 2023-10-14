import { Component,Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-doctor-events-in-dialog',
  templateUrl: './doctor-events-in-dialog.component.html',
  styleUrls: ['./doctor-events-in-dialog.component.css']
})
export class DoctorEventsInDialogComponent {

  sid:any;
  checkbBookEvents:any=[];
  DoctorId: any;

  constructor(private serviceCall: ApiService, private route: Router, private _dialog:MatDialog, @Inject(MAT_DIALOG_DATA) public data: any){

  }

  ngOnInit() {
    this.DoctorId = localStorage.getItem('DoctorId')
    console.warn('this.DoctorId=> ', this.DoctorId);

    console.log('sdfasdfs=> ', this.data);
    
    this.checkEventsAvailability()

  }

  checkEventsAvailability()
  {
    this.serviceCall.GetAllAppointmentsByDoctorIdAndDate(this.DoctorId,this.data).subscribe((res:any)=>{
      console.warn('res.doctorBookedSlots=> ',res.doctorBookedSlots);    
      this.checkbBookEvents=res.doctorBookedSlots;
    })
  }

  onCancel() {
    // Implement your delete logic here
    this._dialog.closeAll();
    console.log('Cancel button clicked');
  }

}
