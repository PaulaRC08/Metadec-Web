import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InstitucionService {

  myAppUrl: string;
  myApiUrl: string; 

  constructor( private http: HttpClient) { 
    this.myAppUrl = environment.endpoint;
    this.myApiUrl='/api/institucion';
  }
  
  
  listInstituciones(): Observable<any> {
    return this.http.get(this.myAppUrl+this.myApiUrl+"/GetListInsti");
  }

}
