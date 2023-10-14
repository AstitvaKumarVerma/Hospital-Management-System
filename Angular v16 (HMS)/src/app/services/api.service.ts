import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http:HttpClient) { }

  /*-----------------------------------------Login Api------------------------------------------*/

  loginApi(userData:any){
    return this.http.post<any>('https://localhost:7173/api/Authentication/AuthLogin',userData);
  }
  

  /*-----------------------------------------Patients Api------------------------------------------*/ 

  GetAllPatientsList(){
    return this.http.get<any>('https://localhost:7173/api/Patient/GetAllPatientsData');
  }

  GetPatientDataById(patientId : number){
    return this.http.get<any>('https://localhost:7173/api/Patient/GetPatientDataById?patientId='+patientId);
  }

  GetAllAppoinmentsByPatientId(patientId : any){
    return this.http.get<any>('https://localhost:7173/api/Patient/GetAllAppoinmentsByPatientId?patientId='+patientId);
  }

  GetPatientProfileDataById(patientId : any){
    return this.http.get<any>('https://localhost:7173/api/Patient/GetPatientProfileDataById?patientId='+patientId)
  }

  AddPatient(patientData: any){
    return this.http.post<any>('https://localhost:7173/api/Patient/AddPatient',patientData);
  }

  UpdatePatient(patientData: any){
    return this.http.put<any>('https://localhost:7173/api/Patient/UpdatePatient',patientData);
  }

  DeletePatientById(patientId : any){
    return this.http.delete('https://localhost:7173/api/Patient/DeletePatient?patientId='+patientId);
  }

  GetAvailableSlotByDoctorId(doctorId: any,choosedDate : any){
    return this.http.get<any>('https://localhost:7173/api/Patient/GetAvailableSlot?doctorId='+doctorId+'&date='+choosedDate)
  }

  SlotBooking(data : any){
    return this.http.put<any>('https://localhost:7173/api/Patient/SlotBooking',data);
  }

  MakePaymentApi(amount: string) {
    return this.http.post<any>('https://localhost:7173/api/Stripe/charge', { Amount: amount });
  }

  SendSMS(data:any){
    return this.http.post<any>('https://localhost:7173/api/Patient/SendSmsForAppointmentByPatientId',data);
  }

  /*-----------------------------------------Doctors Api------------------------------------------*/

  GetAllDoctorsList(){
    return this.http.get<any>('https://localhost:7173/api/Doctor/GetAllDoctorsData');
  }
  GetDoctorDataById(doctorId: any){
    return this.http.get<any>('https://localhost:7173/api/Doctor/GetDoctorDataById?doctorId='+doctorId);
  }

  GetAllAppointmentsByDoctorId(doctorId: any){
    return this.http.get<any>('https://localhost:7173/api/Doctor/GetAllAppointmentsByDoctorId?doctorId='+doctorId);
  }

  GetAllAppointmentsByDoctorIdAndDate(doctorId: any, date: any){
    return this.http.get<any>('https://localhost:7173/api/Doctor/GetAllAppointmentsByDoctorIdAndDate?doctorId='+doctorId+'&selectedDate='+date);
  }

  AddDoctor(doctorData : any){
    return this.http.post<any>('https://localhost:7173/api/Doctor/AddDoctor',doctorData);
  }

  UpdateDoctor(doctorData : any){
    return this.http.put<any>('https://localhost:7173/api/Doctor/UpdateDoctor',doctorData);
  }
  DeleteDoctorById(doctorId: any){
    return this.http.delete('https://localhost:7173/api/Doctor/DeleteDoctor?doctorId='+doctorId);
  }
  PopulateDoctorAvailability(doctorData : any){
    return this.http.post<any>('https://localhost:7173/api/Doctor/PopulateDoctorAvailability',doctorData);
  }
}
