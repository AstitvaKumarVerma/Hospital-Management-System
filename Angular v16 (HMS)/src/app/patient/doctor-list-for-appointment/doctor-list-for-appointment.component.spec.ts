import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorListForAppointmentComponent } from './doctor-list-for-appointment.component';

describe('DoctorListForAppointmentComponent', () => {
  let component: DoctorListForAppointmentComponent;
  let fixture: ComponentFixture<DoctorListForAppointmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoctorListForAppointmentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DoctorListForAppointmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
