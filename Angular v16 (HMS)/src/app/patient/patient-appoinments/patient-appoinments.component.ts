import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PagingConfig } from 'src/app/models/Paging-Config.model';
import { ApiService } from 'src/app/services/api.service';


@Component({
  selector: 'app-patient-appoinments',
  templateUrl: './patient-appoinments.component.html',
  styleUrls: ['./patient-appoinments.component.css']
})
export class PatientAppoinmentsComponent implements PagingConfig {
  PatientId: any;
  PateintAppoinments: any;

  currentPage:number  = 1;
  itemsPerPage: number = 5;
  totalItems: number = 0;

  pagingConfig: PagingConfig = {} as PagingConfig;

  constructor(private serviceCall: ApiService, private router: Router){

  }

  ngOnInit(){
    this.PatientId = localStorage.getItem('PatientId')
    console.log('this.PatientId: ', this.PatientId);
    this.GetAllPatientAppoinmentsById(this.PatientId);

    this.pagingConfig = {
      itemsPerPage: this.itemsPerPage,
      currentPage: this.currentPage,
      totalItems: this.totalItems
    }
  }

  GetAllPatientAppoinmentsById(Id : any){
    this.serviceCall.GetAllAppoinmentsByPatientId(Id).subscribe((res:any) => {
      console.warn('Patient Appoinments: ',res)
      this.PateintAppoinments = res.patientAppoinments;

      this.pagingConfig.totalItems = res.patientAppoinments.length;
    })
  }

  onTableDataChange(event:any){
    this.pagingConfig.currentPage  = event;
    this.GetAllPatientAppoinmentsById(this.PatientId);
  }

  onTableSizeChange(event:any): void {
    this.pagingConfig.itemsPerPage = event.target.value;
    this.pagingConfig.currentPage = 1;
    this.GetAllPatientAppoinmentsById(this.PatientId);
  }

}
