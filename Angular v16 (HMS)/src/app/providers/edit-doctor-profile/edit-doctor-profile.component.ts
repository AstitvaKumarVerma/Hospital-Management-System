import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-edit-doctor-profile',
  templateUrl: './edit-doctor-profile.component.html',
  styleUrls: ['./edit-doctor-profile.component.css']
})
export class EditDoctorProfileComponent {
  doctorProfileForm !: FormGroup;
  maxDate: Date;
  DoctorId: any;
  DoctorData: any;

  constructor(private serviceCall: ApiService, private snackBar: MatSnackBar, private fb: FormBuilder, public dialogRef: MatDialogRef<EditDoctorProfileComponent>, @Inject(MAT_DIALOG_DATA) public data: any) {
    // Initialize maxDate to today's date
    this.maxDate = new Date();
  }

  ngOnInit(): void {
    this.DoctorId = this.data;

    // Initialize the form with validation rules
    this.doctorProfileForm = this.fb.group({
      doctorId:[this.DoctorId],
      doctorName: ['', Validators.required],
      doctorPhone: ['', Validators.required],
      doctorDob: ['', Validators.required],
      doctorEmail: ['', Validators.required],
      doctorPassword: ['', Validators.required],
      gender: ['', Validators.required]
    });

    this.GetDoctorDataById(this.DoctorId);
  }

  GetDoctorDataById(Id: any){
    this.serviceCall.GetDoctorDataById(Id).subscribe((res:any) => {
      this.DoctorData = res;

      this.doctorProfileForm.patchValue({
        doctorName: this.DoctorData.doctorName,
        doctorPhone: this.DoctorData.doctorPhone,
        doctorDob: this.DoctorData.doctorDob,
        doctorEmail: this.DoctorData.doctorEmail,
        doctorPassword: this.DoctorData.doctorPassword,
        gender: this.DoctorData.gender
      });
    })
  }

  onSubmit() {
    if (this.doctorProfileForm.valid) {
      // Implement your update logic here
      console.log('doctorForm.value:', this.doctorProfileForm.value);

      if (confirm("Are you really want to edit your Profile ?")) {

        this.serviceCall.UpdateDoctor(this.doctorProfileForm.value).subscribe((res: any) => {
          this.snackBar.open('Update Successfully....', 'Undo', {
            duration: 1000
          });
          console.warn(res);
        });
      }
    } else {
      // Handle form validation errors
      console.error('doctor Profile form is invalid.');
    }
  }

  onCancel() {
    // Implement your delete logic here
    this.dialogRef.close();
    console.log('Cancel button clicked');
  }
}
