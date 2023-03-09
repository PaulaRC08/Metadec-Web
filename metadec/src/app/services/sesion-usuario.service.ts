import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class SesionUsuarioService {

  myAppUrl: string;
  myApiUrl: string; 

  constructor( private http: HttpClient) { 
    this.myAppUrl = environment.endpoint;
    this.myApiUrl='/api/sesionusuario';
  }

  listSesioneUserRealizadas(idUsuario: number): Observable<any>{
    return this.http.get(this.myAppUrl+this.myApiUrl+"/sesiones/"+idUsuario);
  }

  listSesionUser(): Observable<any>{
    return this.http.get(this.myAppUrl+this.myApiUrl);
  }
  
  listPaisesUsuario(idUsuario: number): Observable<any> {
    return this.http.get(this.myAppUrl+this.myApiUrl+"/"+idUsuario);
  }
}
