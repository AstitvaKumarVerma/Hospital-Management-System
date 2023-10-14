import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule, provideAnimations } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SideNavComponent } from './side-nav/side-nav.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatDialogModule } from '@angular/material/dialog';

import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { DatePipe } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { InterceptorServiceService } from './services/interceptor-service.service';
import { ToastrModule } from 'ngx-toastr';
import { PatientProfileComponent } from './patient/patient-profile/patient-profile.component';

@NgModule({
  declarations: [
    AppComponent,
    SideNavComponent,
    LoginComponent,
    PatientProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    FormsModule,
    ReactiveFormsModule,
    MatListModule,
    MatIconModule,
    MatToolbarModule,
    MatButtonModule,
    MatSlideToggleModule,
    HttpClientModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatSelectModule,
    MatDialogModule,
    ToastrModule.forRoot(), // ToastrModule added
  ],
  providers: [DatePipe, HttpClientModule, {
    provide: HTTP_INTERCEPTORS,
    useClass: InterceptorServiceService, 
    multi: true
  },
  provideAnimations(), // required animations providers
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
