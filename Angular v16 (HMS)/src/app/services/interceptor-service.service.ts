import { HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InterceptorServiceService {

  constructor(private inject: Injector) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let token = localStorage.getItem('Token');
    // let authservice=this.inject.get(UserService)
    let jwtToken = req.clone({
      setHeaders: {
        Authorization: 'bearer ' +token
      }
    });
    return next.handle(jwtToken);
  }
}
