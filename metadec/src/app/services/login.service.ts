import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Data } from '@angular/router';
import { Observable, retry } from 'rxjs';
import { environment } from '../../environments/environment';
import { UserLogin } from '../models/userlogin';
import { JwtHelperService, JwtModule } from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  myAppUrl: string;
  myApiUrl: string; 

  constructor( private http: HttpClient) { 
    this.myAppUrl = environment.endpoint;
    this.myApiUrl='/api/login';
  }

  login(usuariologin: UserLogin):Observable<any>{
    return this.http.post(this.myAppUrl+this.myApiUrl, usuariologin);
  }

  setLocalStorage(data: any): void {
    localStorage.setItem('token',data);
  }

  getToken(): string{
    return localStorage.getItem('token')!;
  }

  getTokenDecoded(): any {
    const helper = new JwtHelperService();
    const data = localStorage.getItem('token');
    if (data) {
      return helper.decodeToken(data);
    } else {
      return null;
    }
  }

  removeLocalStorage(){
    return localStorage.removeItem('token');
  }

}
