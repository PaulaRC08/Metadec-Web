import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SesionUsuarioService } from '../../../../app/services/sesion-usuario.service';

@Component({
  selector: 'app-sesion',
  templateUrl: './sesion.component.html',
  styleUrls: ['./sesion.component.scss']
})
export class SesionComponent {

  constructor(private sesionUserService: SesionUsuarioService,
              private snackBar: MatSnackBar){}
  Sesiones: any = [];
  
  ngOnInit(): void{

    this.sesionUserService.listSesionUser().subscribe(data =>{
      this.Sesiones = data;
      console.log(data);
      }), (error: { error: { message: any; }; }) => {
        console.log(error.error.message);
      }
    
  }

  crearClipboard(codigoSesion: string, passSesion: string): string{
    var copy="<METADEC COMPARTE>\nCONECTATE EN ESTA SESION AULA ESPEJO\n💻INGRESA A METADEC Y REGISTRA:\n\n" +
              "--CODIGO SESION:    "+codigoSesion+"\n--CONTRASEÑA SESION:    "+passSesion+
              "\n\n🌎 INGRESA AL ESPACIO VIRTUAL METADEC E INTERACTUA CON TUS COMPAÑEROS EN UNA SESION SINCRONA";
    return copy;
  }

  snackBarCLip(): void{
    this.snackBar.open("✓ Info Copiada", '',{
      duration: 2000,
      verticalPosition: 'top',
      panelClass: ['info-snackbar']
    });
  }

  getColor(i: number) {
    if (i % 2 == 0) {
      return "#333333";
    } else{
      return "#006377";
    }
  }
  getColorBtn(i: number) {
    if (i % 2 == 0) {
      return "#1c85a5";
    } else{
      return "#333333";
    }
  }
}
