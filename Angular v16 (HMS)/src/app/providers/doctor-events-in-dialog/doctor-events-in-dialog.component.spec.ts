import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorEventsInDialogComponent } from './doctor-events-in-dialog.component';

describe('DoctorEventsInDialogComponent', () => {
  let component: DoctorEventsInDialogComponent;
  let fixture: ComponentFixture<DoctorEventsInDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DoctorEventsInDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DoctorEventsInDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
