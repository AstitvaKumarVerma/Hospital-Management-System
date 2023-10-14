import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ApiService } from '../services/api.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  // ,private snackBar: MatSnackBar
  LoginForm!: FormGroup
  loginDetails: any;
  Token: any;
  Role: any;

  hide: boolean = true;

  constructor(private serviceCall:ApiService, private router: Router, private toastr: ToastrService) {
    this.LoginForm = new FormGroup({
      email: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    });
  }

  ngOnInIt() {

  }

  Login(data: any) {
    if (this.LoginForm.valid) {
      // Handle form submission logic here
      this.loginDetails = this.LoginForm.value
      console.log('LoginForm.value: ', this.loginDetails);
      console.warn('email: ', data.email);
      console.warn('password: ', data.password);

      this.serviceCall.loginApi(data).subscribe(response => {
        console.log("Token: ", response.token);
        this.Token = response.token;

        if (this.Token != null) {

          let jwtData = this.Token.split('.')[1]
          let decodedJwtjsonData = window.atob(jwtData);
          decodedJwtjsonData = decodedJwtjsonData.replace('http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress', 'emailaddress');
          decodedJwtjsonData = decodedJwtjsonData.replace('http://schemas.microsoft.com/ws/2008/06/identity/claims/role', 'role');
          decodedJwtjsonData = decodedJwtjsonData.replace('http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid', 'sid');

          let decodedJwtData = JSON.parse(decodedJwtjsonData)
          localStorage.setItem('Token', this.Token)
          this.Role = decodedJwtData.role;

          localStorage.setItem('Role', this.Role)
          console.log('Role After Login: ', this.Role);
          if (this.Role == 'Patient') {
            localStorage.setItem('PatientId', decodedJwtData.PatientId)
          }
          else if (this.Role == 'Provider') {
            localStorage.setItem('DoctorId', decodedJwtData.DoctorId)
          }
          else if (this.Role == 'Admin') {

            localStorage.setItem('AdminId', decodedJwtData.AdminId)
          }


          if (response.statusCode == 200) {
            this.toastr.success("Successfully Logged In", this.Role, {
              timeOut: 1000,
            })
            this.router.navigate(['dash'])
          }
        }
        else {
          console.error("Please enter valid EmailId & Password");

          this.toastr.error('Try Again', 'Login Failed', {
            timeOut: 2000,
          });
        }
      })
    }
  };

  openRegisterForm(){
    this.router.navigate(['/add-patient']);
  }
}

