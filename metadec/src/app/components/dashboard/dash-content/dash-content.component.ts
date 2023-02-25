import { Component } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-dash-content',
  templateUrl: './dash-content.component.html',
  styleUrls: ['./dash-content.component.scss']
})
export class DashContentComponent {

  nombreusuario?: string;

  constructor(private loginService: LoginService){}

  ngOnInit(): void{
    this.getNombreUsuario();
  }

  getNombreUsuario(): void{
    this.nombreusuario = this.loginService.getTokenDecoded().sub;
    console.log(this.loginService.getTokenDecoded());
  }

}
