import { Component, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BrowserModule } from '@angular/platform-browser';
import { TranslateService } from '@ngx-translate/core';
import { Pais } from 'app/models/paisGraph';
import { SesionUsuarioService } from 'app/services/sesion-usuario.service';
import { UsuarioService } from 'app/services/usuario.service';
import { LoginService } from '../../../../app/services/login.service';
import { single, Subject } from 'rxjs';
import { Reporte } from 'app/models/reporte';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-dash-content',
  templateUrl: './dash-content.component.html',
  styleUrls: ['./dash-content.component.scss']
})
export class DashContentComponent {

  idUsuario: number = 0;

  reporteActivo=false;
  reporte?: Reporte;
  fechaFin?: string;
  single: any = [];
  sesionesUsuario: any = [];

  avatarUrl?:string;
  nombre?:string;
  correo?:string;
  paisUser?:string;
  sexo?:string;
  haveSession=false;

  constructor(private loginService :LoginService,
              public translate: TranslateService,
              public sesionUsuarioService: SesionUsuarioService,
              private snackBar: MatSnackBar,
              private route: ActivatedRoute,
              private router:Router,
              private usuarioService : UsuarioService ){}

  reporteR1=false;
  reporteR2=true;
  reporteR3=false;
  reporteR4=false;
  
  ngOnInit(): void{
    if(this.loginService.getTokenDecoded().TipoUsuario == "Admin"){
      this.router.navigate(['/dash-admin'])
    }
    this.idUsuario = this.loginService.getTokenDecoded().IdUsuario;
    this.infoUsuario();
    this.infoGraph();
    this.infoSesiones();
    this.reporteUsuario();
  }

  reporteUsuario():void{
    this.usuarioService.getReporte(this.idUsuario).subscribe(data => {
      if(data != false){
        this.reporte = data;        
        this.reporteActivo=true;
      }else{
        this.reporteActivo=false;
      }
    }, error => {
      this.snackBar.open(" ERROR: "+ (error.error.message).toUpperCase(), '',{
        duration: 3000,
        verticalPosition: 'top',
        panelClass: ['error-snackbar']
      });
    });
  }

  infoSesiones():void{
    this.sesionUsuarioService.listSesioneUserRealizadas(this.idUsuario).subscribe(data => {
      if(data.length==0){
        this.haveSession=false;
      }else{
        this.haveSession=true;
      }
      console.log(this.haveSession);
      this.sesionesUsuario = data;
      //console.log(this.sesionesUsuario[0].clase);

    }, error => {
      this.snackBar.open(" ERROR: "+ (error.error.message), '',{
        duration: 3000,
        verticalPosition: 'top',
        panelClass: ['error-snackbar']
      });
    });
  }

  infoGraph():void{
    this.sesionUsuarioService.listPaisesUsuario(this.idUsuario).subscribe(data => {
      var paisGraph;
      data.forEach((item: any) => {
        var paisLan = item.pais.split(",", 2); 
        if(this.translate.currentLang=='es'){
          paisGraph = paisLan[0];
        }else{
          paisGraph = paisLan[1];
        }
          this.single.push({name:(paisGraph), value: (item.total) });
      });
      this.single = [...this.single];
    }, error => {
      this.snackBar.open(" ERROR: "+ (error.error.message).toUpperCase(), '',{
        duration: 3000,
        verticalPosition: 'top',
        panelClass: ['error-snackbar']
      });
    });
  }

  infoUsuario():void{
    this.usuarioService.getUser(this.loginService.getTokenDecoded().IdUsuario).subscribe(data => {
      this.avatarUrl = data.avatarUrl.substring(0,data.avatarUrl.length-4)+".png?scene=fullbody-portrait-v1";
      this.nombre = data.nombreCompleto;
      this.sexo = data.sexo;
      this.correo = data.correo;
      var paisLan = data.pais.split(",", 2); 
      if(this.translate.currentLang=='es'){
        this.paisUser = paisLan[0];
      }else{
        this.paisUser = paisLan[1];
      }

    }, error => {
      this.snackBar.open(" ERROR: "+ (error.error.message).toUpperCase(), '',{
        duration: 3000,
        verticalPosition: 'top',
        panelClass: ['error-snackbar']
      });
    });
  }


  view: any[] = [700, 400];
  // options
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = true;
  xAxisLabel = 'Country';
  showYAxisLabel = true;
  yAxisLabel = 'Population';


  getColor(i: number) {
    if (i % 2 == 0) {
      return "#333333";
    } else{
      return "#006377";
    }
  }


  onSelect(event: any) {
    console.log(event);
  }

  onResize(event: any) {
    this.view = [event.target.innerWidth - 900, 280 ];
  }
}
