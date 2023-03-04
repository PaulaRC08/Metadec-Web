import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Sesion } from '../models/sesion';

@Injectable({
  providedIn: 'root'
})
export class SesionService {

  myAppUrl: string;
  myApiUrl: string; 

  constructor( private http: HttpClient) { 
    this.myAppUrl = environment.endpoint;
    this.myApiUrl='/api/sesion';
  }

  saveSesion(sesion: Sesion): Observable<any> {
    return this.http.post(this.myAppUrl+this.myApiUrl, sesion);
  }
  
}
