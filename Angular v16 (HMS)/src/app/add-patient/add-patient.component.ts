import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog'
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { CommonModule, Location } from '@angular/common';
import { ApiService } from 'src/app/services/api.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.css'],
  standalone:true,
  imports: [ MatFormFieldModule, MatInputModule, MatButtonModule, MatDatepickerModule, MatSelectModule, MatIconModule, FormsModule, ReactiveFormsModule]
})
export class AddPatientComponent {
  patientForm !: FormGroup;
  patientData: any;
  maxDate !: Date;

  constructor(private fb: FormBuilder, private serviceCall: ApiService, private router: Router, private location: Location) {
    this.patientForm = this.fb.group({
      patientName: ['', Validators.required],
      patientDob: ['', Validators.required],
      patientPhone: ['', Validators.required],
      patientEmail: ['', Validators.required],
      patientPassword: ['', Validators.required],
      gender: ['', Validators.required],
      fatherName: ['', Validators.required],
      maritalStatus: ['', Validators.required],
      bloodGroup: ['', Validators.required],
      symptoms: [''],
      diagnosis: ['']
    });
   }

  ngOnInit(): void {
    // Initialize the maxDate to today's date
    this.maxDate = new Date();
  }

  // Add a method to submit the form
  onSubmit() {
    if (this.patientForm.valid) {
      // Handle form submission logic here
      this.patientData = this.patientForm.value
      console.log('patientForm.value: ',this.patientData);
      this.serviceCall.AddPatient(this.patientData).subscribe(response => {
        alert('Details Add Successfully....');
        // this.snackBar.open('Details Add Successfully....','Undo', {
        //   duration:1000
        // });
        console.log('response:',response);
        this.router.navigate(['']);
      });
    }
  }

  closeDialog() {
    // this.dialogRef.close();
    this.location.back();
  }

}
