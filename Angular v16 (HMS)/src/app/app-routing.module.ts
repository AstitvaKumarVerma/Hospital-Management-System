import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SideNavComponent } from './side-nav/side-nav.component';
import { LoginComponent } from './login/login.component';
import { AddPatientComponent } from './add-patient/add-patient.component';


const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'add-patient', component: AddPatientComponent },
  {
    path: 'dash', component: SideNavComponent,
    children: [
      {
        path: 'patients',
        loadChildren: () => import('./patient/patient.module').then(s => s.PatientModule)
      },
      {
        path: 'providers',
        loadChildren: () => import('./providers/providers.module').then(s => s.ProvidersModule)
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
