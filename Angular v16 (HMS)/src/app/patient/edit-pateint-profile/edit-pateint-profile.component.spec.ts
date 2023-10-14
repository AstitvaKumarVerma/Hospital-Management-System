import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPateintProfileComponent } from './edit-pateint-profile.component';

describe('EditPateintProfileComponent', () => {
  let component: EditPateintProfileComponent;
  let fixture: ComponentFixture<EditPateintProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditPateintProfileComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditPateintProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
