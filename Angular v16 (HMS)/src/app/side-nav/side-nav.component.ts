import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AddDoctorComponent } from '../providers/add-doctor/add-doctor.component';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent {

  constructor(private router: Router,
    private toastr: ToastrService) { }
  role: any
  isShow: boolean = true;
  isDisplay: boolean = true;
  ngOnInit() {
    this.isShow = true;
    this.role = localStorage.getItem('Role')
    console.log('Role: ', this.role);
  }

  @ViewChild('sidenav') sidenav!: MatSidenav;
  isSidenavOpen = true;

  toggleSidenav(): void {
    this.isSidenavOpen = !this.isSidenavOpen;
  }

  hideSidenav(): void {
    if (this.isSidenavOpen == true) {
      this.sidenav.close();
      this.isSidenavOpen = false
    }
    else {
      this.sidenav.open();
      this.isSidenavOpen = true;
    }
  }

  dashboardImage() {
    this.isShow = true;
    this.isDisplay = false;
  }

  showRoute() {
    this.isShow = false;
    this.isDisplay = true;
  }

  logout() {
    Swal.fire({
      title: 'Are you sure You want to logout?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes'
    }).then((result) => {
      if (result.isConfirmed) {
        localStorage.clear();
        this.router.navigate([''])
        this.toastr.success("log out")
      }
    })
  }
}
