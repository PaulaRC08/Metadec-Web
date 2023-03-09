import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { User } from '../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  urlUser?: string;

  myAppUrl: string;
  myApiUrl: string; 

  constructor( private http: HttpClient) { 
    this.myAppUrl = environment.endpoint;
    this.myApiUrl='/api/usuario';
  }

  saveUser(usuario: User): Observable<any> {
    return this.http.post(this.myAppUrl+this.myApiUrl, usuario);
  }

  getUser(idUsuario: number): Observable<any> {
    return this.http.get(this.myAppUrl+this.myApiUrl+"/"+idUsuario);
  }

  getReporte(idUsuario: number): Observable<any> {
    return this.http.get(this.myAppUrl+this.myApiUrl+"/reportes/"+idUsuario);
  }

  changePassword(changePassword: any): Observable<any>{
    return this.http.put(this.myAppUrl + this.myApiUrl + '/CambiarPassword', changePassword);
  }

  setLocalStorage(data: any): void {
    localStorage.setItem('userRegister',data);
  }
  getLocalStorage(): any {
    localStorage.getItem('userRegister');
  }

  removeLocalStorage(){
    return localStorage.removeItem('userRegister');
  }

}
