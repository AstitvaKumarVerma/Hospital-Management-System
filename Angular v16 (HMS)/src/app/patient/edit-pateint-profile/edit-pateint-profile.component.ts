import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-edit-pateint-profile',
  templateUrl: './edit-pateint-profile.component.html',
  styleUrls: ['./edit-pateint-profile.component.css']
})
export class EditPateintProfileComponent {
  patientForm!: FormGroup;
  maxDate: Date;
  patienData: any;
  PatientId: any;

  constructor(private serviceCall: ApiService, private snackBar: MatSnackBar, private formBuilder: FormBuilder, public dialogRef: MatDialogRef<EditPateintProfileComponent>, @Inject(MAT_DIALOG_DATA) public data: any) {
    // Initialize the maxDate for the date picker (e.g., restrict future dates)
    this.maxDate = new Date();
  }

  ngOnInit(): void {
    this.PatientId = this.data
    //this.PatientId = localStorage.getItem('PatientId')

    // Initialize the patientForm with form controls and validation
    this.patientForm = this.formBuilder.group({
      patientId:[this.PatientId],
      patientName: ['', Validators.required],
      fatherName: ['', Validators.required],
      patientPhone: ['', Validators.required],
      patientDob: ['', Validators.required],
      patientEmail: ['', Validators.required],
      patientPassword: ['', Validators.required],
      gender: ['', Validators.required],
      maritalStatus: ['', Validators.required],
      bloodGroup: ['', Validators.required],
      symptoms: [''],
      diagnosis: ['']
    });

    this.GetPatientProfileDataById(this.PatientId);
  }

  GetPatientProfileDataById(Id: any){
    this.serviceCall.GetPatientProfileDataById(Id).subscribe((res:any) => {
      this.patienData = res;

      this.patientForm.patchValue({
        patientName: this.patienData.patientName,
        fatherName: this.patienData.fatherName,
        patientPhone: this.patienData.patientPhone,
        patientDob: this.patienData.patientDob,
        patientEmail: this.patienData.patientEmail,
        patientPassword: this.patienData.patientPassword,
        gender: this.patienData.gender,
        maritalStatus: this.patienData.maritalStatus,
        bloodGroup: this.patienData.bloodGroup,
        symptoms: this.patienData.symptoms,
        diagnosis: this.patienData.diagnosis,
      });
    })
  }

  onSubmit(): void {
    // Handle form submission here, you can access form values using this.patientForm.value
    if (this.patientForm.valid) {
      // Implement your update logic here
      console.log('doctorForm.value:', this.patientForm.value);

      if (confirm("Are you sure to Update ?")) {
        this.serviceCall.UpdatePatient(this.patientForm.value).subscribe((res: any) => {
          this.snackBar.open('Update Successfully....', 'Undo', {
            duration: 1000
          });
          console.warn(res);
        });
      }
    } else {
      // Handle form validation errors
      console.error('Patient form is invalid.');
    }
  }

  valid(val: any) {
    if (val.key == '.' || val.key == '+' || val.key == '-' || val.key>= 'A' && val.key<= 'Z' || val.key>= 'a' && val.key<= 'z') {
      val.preventDefault();
    }
  }

  closeDialog(): void {
    // Implement the logic to close the dialog here
    this.dialogRef.close();
  }

}
