import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PatientAppoinmentsComponent } from './patient-appoinments.component';

describe('PatientAppoinmentsComponent', () => {
  let component: PatientAppoinmentsComponent;
  let fixture: ComponentFixture<PatientAppoinmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PatientAppoinmentsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PatientAppoinmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
