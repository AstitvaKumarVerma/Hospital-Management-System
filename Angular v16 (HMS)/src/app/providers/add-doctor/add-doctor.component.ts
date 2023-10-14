import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-add-doctor',
  templateUrl: './add-doctor.component.html',
  styleUrls: ['./add-doctor.component.css']
})
export class AddDoctorComponent implements OnInit {
  doctorForm!: FormGroup;
  maxDate !: Date;
  doctorData: any;

  constructor(private fb: FormBuilder, private serviceCall: ApiService, private snackBar: MatSnackBar, public dialogRef: MatDialogRef<AddDoctorComponent>, @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    // Initialize the maxDate to today's date
    this.maxDate = new Date();
    this.initForm();
  }

  initForm(): void {
    this.doctorForm = this.fb.group({
      doctorName: ['', Validators.required],
      doctorPhone: ['', Validators.required,Validators.minLength(10),Validators.maxLength(10)],
      doctorDob: ['', Validators.required],
      doctorEmail: ['', Validators.required],
      doctorPassword: ['', Validators.required],
      gender: ['', Validators.required]
    });
  }

  GetAllDoctorsData(){
    this.serviceCall.GetAllDoctorsList().subscribe((response : any) => {
      console.log('response:',response.doctorsData);
    })
  }

  onSubmit(): void {
    if (this.doctorForm.valid) {
      // Handle form submission logic here
      this.doctorData = this.doctorForm.value
      console.log('doctorForm.value: ',this.doctorData);
      this.serviceCall.AddDoctor(this.doctorData).subscribe(response => {
        this.snackBar.open('Details Add Successfully....','Undo', {
          duration:1000
        });
        console.log('response:',response);
        this.GetAllDoctorsData();
      });
    }
  }

  closeDialog(): void {
    // Implement close dialog logic 
    this.dialogRef.close();
  }
}
