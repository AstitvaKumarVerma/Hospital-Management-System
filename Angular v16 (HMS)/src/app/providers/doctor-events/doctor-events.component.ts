import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { FullCalendarModule } from '@fullcalendar/angular';
import { CalendarOptions } from '@fullcalendar/core'; // useful for typechecking
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';
import { ApiService } from 'src/app/services/api.service';
import { DoctorEventsInDialogComponent } from '../doctor-events-in-dialog/doctor-events-in-dialog.component';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-doctor-events',
  templateUrl: './doctor-events.component.html',
  styleUrls: ['./doctor-events.component.css']
})
export class DoctorEventsComponent {
  DoctorId: any;
  role: any;
  SlotsData: any = [];
  // @ViewChild('calendar') calendarComponent!: FullCalendarModule;
  constructor(private datePipe: DatePipe, private serviceCall: ApiService, private route: Router, private _dialog: MatDialog) {

  }

  ngOnInit() {
    this.role = localStorage.getItem('Role')
    console.log('Role: ', this.role);
    this.DoctorId = localStorage.getItem('DoctorId')
    console.log('this.DoctorId: ', this.DoctorId);

    this.checkEventsAvailability()
  }

  handleDateClick(val: any) {
    if (this.role == 'Provider') {
      this._dialog.open(DoctorEventsInDialogComponent, { width: "60%", height: "60%", data: val.dateStr })
    }
    else {
      alert('Not Authorize')
    }
  }

  checkEventsAvailability() {
    if (this.role == 'Provider') {
      this.serviceCall.GetAllAppointmentsByDoctorId(this.DoctorId).subscribe((res: any) => {
        this.SlotsData = (res.doctorBookedSlots);
        console.warn('res.doctorBookedSlots => ', res.doctorBookedSlots);
       
        const adaptedEvents = this.SlotsData.map((eventdata: any) => ({
          
          title: eventdata.title + ' ' + eventdata.start,
          date: eventdata.date,
          color: 'green',
        }));
        this.calendarOptions.events = adaptedEvents;
        console.log('events check hai! =>', this.SlotsData)
      })
    }
    else {
      this.onChangeEvents()
    }
  }

  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
    plugins: [interactionPlugin, dayGridPlugin],
    dateClick: this.handleDateClick.bind(this),
    events: []
  };

  onChangeEvents(){
    localStorage.setItem('val',this.DoctorId)
    this.checkEventsAvailability();
  }
}
