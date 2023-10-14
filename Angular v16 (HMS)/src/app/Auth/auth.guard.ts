import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private route: Router) {

  }

  canActivate(): boolean {
    if (localStorage.getItem("Token") != null) {
      return true;   //User will be authenticated, & will allow access to the route
    }
    else {
      this.route.navigate(['']);
      return false;  //User will not be authenticated, & will redirect to Login Page
    }
  }
}
