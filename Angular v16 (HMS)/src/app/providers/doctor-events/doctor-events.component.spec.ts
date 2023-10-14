import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorEventsComponent } from './doctor-events.component';

describe('DoctorEventsComponent', () => {
  let component: DoctorEventsComponent;
  let fixture: ComponentFixture<DoctorEventsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoctorEventsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DoctorEventsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
