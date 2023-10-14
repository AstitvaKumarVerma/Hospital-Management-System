import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-edit-doctor',
  templateUrl: './edit-doctor.component.html',
  styleUrls: ['./edit-doctor.component.css']
})
export class EditDoctorComponent implements OnInit {
  doctorForm !: FormGroup;
  maxDate: Date;
  doctorData: any;
  role: any;
  DoctorId: any;

  constructor(private serviceCall: ApiService, private snackBar: MatSnackBar, private fb: FormBuilder, public dialogRef: MatDialogRef<EditDoctorComponent>, @Inject(MAT_DIALOG_DATA) public data: any) {
    // Initialize maxDate to today's date
    this.maxDate = new Date();
  }

  ngOnInit(): void {
    this.doctorData = this.data;

    this.role = localStorage.getItem('Role')
    console.log('Role: ', this.role);

    this.DoctorId = localStorage.getItem('DoctorId')

    // Initialize the form with validation rules
    this.doctorForm = this.fb.group({
      doctorId:[this.DoctorId],
      doctorName: ['', Validators.required],
      doctorPhone: ['', Validators.required],
      doctorDob: ['', Validators.required],
      doctorEmail: ['', Validators.required],
      doctorPassword: ['', Validators.required],
      gender: ['', Validators.required]
    });

    this.doctorForm.patchValue(this.doctorData);
  }

  onSubmit() {
    if (this.doctorForm.valid) {
      // Implement your update logic here
      console.log('doctorForm.value:', this.doctorForm.value);

      if (this.role == 'Admin' || this.DoctorId == this.doctorForm.controls['doctorId'].value)
      {
        if (confirm("Are you sure to Update ?")) {

          this.serviceCall.UpdateDoctor(this.doctorForm.value).subscribe((res: any) => {
            this.snackBar.open('Update Successfully....', 'Undo', {
              duration: 1000
            });
            console.warn(res);
          });
        }
      } else {
        // Handle form validation errors
        console.error('Doctor form is invalid.');
      }
      }
      
  }

  onCancel() {
    // Implement your delete logic here
    this.dialogRef.close();
    console.log('Cancel button clicked');
  }

  // closeCancel() {
  //   // Implement dialog close logic here
  //   console.log('Close button clicked');
  // }
}
