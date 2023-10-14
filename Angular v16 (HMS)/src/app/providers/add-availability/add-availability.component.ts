import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-availability',
  templateUrl: './add-availability.component.html',
  styleUrls: ['./add-availability.component.css']
})
export class AddAvailabilityComponent {
  availabilityForm!: FormGroup;
  minDate!: Date;
  role: any;
  DoctorId: any;

  constructor(private fb: FormBuilder, private serviceCall: ApiService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.role = localStorage.getItem('Role')
    console.log('Role: ', this.role);

    this.DoctorId = localStorage.getItem('DoctorId')
    console.log('this.DoctorId: ', this.DoctorId);

    this.minDate = new Date()

    this.availabilityForm = this.fb.group({
      providerId: [this.DoctorId],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      startTime: ['', Validators.required],
      endTime: ['', Validators.required],
      intervalMinutes: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.availabilityForm.valid) {
      if (this.role == 'Provider') {
        // Get the form values and handle submission logic here
        let formData = this.availabilityForm.value;
        let startDate = new Date(formData.startDate);
        let endDate=new Date(formData.endDate);
        
        endDate.setDate(endDate.getDate()+1)
        startDate.setDate(startDate.getDate() + 1);
        formData.startDate = startDate
        formData.endDate=endDate
        // Now startDate contains the increased date by 1 day

        console.log('Form Data:', formData);

        this.serviceCall.PopulateDoctorAvailability(formData).subscribe((res: any) => {
          this.toastr.success('Availability has been Added Succesfully', '', {
            timeOut: 2000,
          });

          // this.router.navigate(['']);
        })
      }
      else {
        this.toastr.error('You are not Auhorized', '', {
          timeOut: 1000,
        });
      }
    }
    else {
      this.toastr.error('!!!! Invalid Form !!!!', '', {
        timeOut: 2000,
      });
    }
  }
}
