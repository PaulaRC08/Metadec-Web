import { Component } from '@angular/core';
import { LoginService } from '../../../../app/services/login.service';
import { } from 'angular-highcharts';
import { ChartModule } from 'angular-highcharts';

@Component({
  selector: 'app-dash-content',
  templateUrl: './dash-content.component.html',
  styleUrls: ['./dash-content.component.scss']
})
export class DashContentComponent {

  nombreusuario?: string;
  idUsuario?: Number;

  constructor(private loginService: LoginService){}

  ngOnInit(): void{
    this.getNombreUsuario();
  }

  getNombreUsuario(): void{
    this.nombreusuario = this.loginService.getTokenDecoded().sub;
    this.idUsuario = this.loginService.getTokenDecoded().sub;
    console.log(this.loginService.getTokenDecoded().sub);
  }

}

