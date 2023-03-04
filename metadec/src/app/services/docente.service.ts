import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Docente } from '../models/docente';

@Injectable({
  providedIn: 'root'
})
export class DocenteService {


  myAppUrl: string;
  myApiUrl: string; 

  constructor( private http: HttpClient) { 
    this.myAppUrl = environment.endpoint;
    this.myApiUrl='/api/docente';
  }

  saveDocente(docente: Docente): Observable<any> {
    return this.http.post(this.myAppUrl+this.myApiUrl, docente)
  }
  
}
