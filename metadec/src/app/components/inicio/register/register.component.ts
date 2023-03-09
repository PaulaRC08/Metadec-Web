import { Component, ViewChild} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatCheckbox } from '@angular/material/checkbox';
import { MatDialog} from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Docente } from '../../../../app/models/docente';
import { Estudiante } from '../../../../app/models/estudiante';
import { User } from '../../../../app/models/usuario';
import { DocenteService } from '../../../../app/services/docente.service';
import { EstudianteService } from '../../../../app/services/estudiante.service';
import { InstitucionService } from '../../../../app/services/institucion.service';
import { InstitucionprogramaService } from '../../../../app/services/institucionprograma.service';
import { PaisService } from '../../../../app/services/pais.service';
import { UsuarioService } from '../../../../app/services/usuario.service';
import { PasswordStrengthValidator } from "./password-strength.validators";


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  Paises: any = [];
  Instituciones: any = [];
  InstitucionesProgramas: any = [];
  usuarioRegistrado: any;

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  thirdFormGroup: FormGroup;
  fourFormGroup: FormGroup;

  loading = false;
  valueTratamiento = false;
  loadingProgram = false;
  institucionList = true;
  isLinear = false;
  hide = true;

  constructor(private _formBuilder: FormBuilder,
                public translate: TranslateService,
               private usuarioService: UsuarioService,
               private docenteService: DocenteService,
               private estudianteService: EstudianteService,
               private institucionService: InstitucionService,
               private institucionProgramaService: InstitucionprogramaService,
               private paisService: PaisService,
               private snackBar: MatSnackBar,
               public dialog: MatDialog,
               private route: ActivatedRoute,
               private router:Router) { 
    this.firstFormGroup = this._formBuilder.group({
      rol: ['', Validators.required],
    });
    this.secondFormGroup = this._formBuilder.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      sexo: ['', Validators.required],
      correo: ['', [Validators.required,Validators.email]],
      pais: ['', Validators.required],
    });
    this.thirdFormGroup = this._formBuilder.group({
      institucion: ['', Validators.required],
      programa: [''],
    });
    this.fourFormGroup = this._formBuilder.group({
      usuario: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(8), PasswordStrengthValidator]],
      politica: ['', Validators.requiredTrue, ]
    });
  }

  ngOnInit(): void{
    /*if(this.usuarioService.urlUser==null){
      this.router.navigate(['/inicio'])
    }*/
    console.log("dasdas:"+this.valueTratamiento);
    this.paisesList();
    this.institucionesList();
    console.log(this.institucionList);
    this.thirdFormGroup.get("programa")?.disable();
    console.log("avatar: "+localStorage.getItem("urlAvatar"));
  }

  languagePais(pais: string): string{
    var paisLan = pais.split(",", 2); 
    if(this.translate.currentLang=='es'){
      return paisLan[0];
    }else{
      return paisLan[1];
    }

  }

  programaList():void{
    this.loadingProgram = true;
    this.institucionProgramaService.programasInstitucion(this.thirdFormGroup.value.institucion).subscribe(data =>{
      this.InstitucionesProgramas = data;
      this.institucionList = false;
      this.loadingProgram = false;
      this.thirdFormGroup.get("programa")?.enable();
    }), (error: { error: { message: any; }; }) => {
      console.log(error.error.message);
    }
  }

  institucionesList(): void{
    this.institucionService.listInstituciones().subscribe(data =>{
    this.Instituciones = data;
    }), (error: { error: { message: any; }; }) => {
      console.log(error.error.message);
    }
  }

  paisesList(): void{
    this.paisService.listPais().subscribe(data =>{
      this.Paises = data;
    }), (error: { error: { message: any; }; }) => {
      console.log(error.error.message);
    }
  }

  registrarUsuario(): void{
      
    console.log(this.fourFormGroup);
      
      const usuario: User = {
        Usuario: this.fourFormGroup.value.usuario,
        TipoUsuario: this.firstFormGroup.value.rol,
        Pasword: this.fourFormGroup.value.password,
        AvatarUrl:  this.usuarioService.urlUser,
        Nombres: this.secondFormGroup.value.nombre,
        Apellidos: this.secondFormGroup.value.apellido,
        Sexo: this.secondFormGroup.value.sexo,
        Correo: this.secondFormGroup.value.correo,
        TratamientoDatos: true,
        IdPais: this.secondFormGroup.value.pais
      }
      console.log(usuario);
      this.loading = true;

      if(this.firstFormGroup.value.rol=="Docente"){
          
        const docente: Docente = {
          IdInstitucion: this.thirdFormGroup.value.institucion,
          IdUsuarioNavigation: usuario
        }
        console.log(docente);
        this.docenteService.saveDocente(docente).subscribe(data =>{
          console.log(data);
          if(data.message!="Usuario ya existe"){
            this.snackBar.open(this.translate.instant('REGISTER.USER')+usuario.Usuario+this.translate.instant('REGISTER.BARRCORRECT'), '',{
              duration: 2000,
              verticalPosition: 'top',
              panelClass: ['success-snackbar']
            });
            this.snackBar.open(this.translate.instant('REGISTER.BARNETIQUETA'), '',{
              duration: 2000,
              verticalPosition: 'top',
              panelClass: ['info-snackbar']
            });
            this.loading=false;
            this.router.navigate(['/inicio/login'])
          }else{
            this.loading = false;
            this.fourFormGroup.reset();
            this.snackBar.open(this.translate.instant('REGISTER.USER')+" "+usuario.Usuario+" "+this.translate.instant('REGISTER.BAREXISTING'), '',{
              duration: 2000,
              verticalPosition: 'top',
              panelClass: ['error-snackbar']
            });
          }

        }, error => {
          this.loading = false;
          console.log(error);
          this.snackBar.open(("ERROR: El"+error.error.message), '',{
            duration: 5000,
            verticalPosition: 'top',
            panelClass: ['error-snackbar']
          });
          this.fourFormGroup.reset();
        });
      }

      if(this.firstFormGroup.value.rol=="Estudiante"){
          
        const estudiante: Estudiante = {
          IdInstitucionPrograma: this.thirdFormGroup.value.programa,
          IdUsuarioNavigation: usuario
        }

        this.estudianteService.saveEstudiante(estudiante).subscribe(data =>{
          console.log(data);
          if(data.message!="Usuario ya existe"){
            this.snackBar.open(this.translate.instant('REGISTER.USER')+usuario.Usuario+this.translate.instant('REGISTER.BARRCORRECT'), '',{
              duration: 2000,
              verticalPosition: 'top',
              panelClass: ['success-snackbar']
            });
            this.snackBar.open(this.translate.instant('REGISTER.BARNETIQUETA'), '',{
              duration: 2000,
              verticalPosition: 'top',
              panelClass: ['info-snackbar']
            });
            this.loading=false;
            this.router.navigate(['/inicio/login'])
          }else{
            this.loading = false;
            this.fourFormGroup.reset();
            this.snackBar.open(this.translate.instant('REGISTER.USER')+" "+usuario.Usuario+" "+this.translate.instant('REGISTER.BAREXISTING'), '',{
              duration: 2000,
              verticalPosition: 'top',
              panelClass: ['error-snackbar']
            });
          }

        }, error => {
          this.loading = false;
          console.log(error);
          this.snackBar.open(("ERROR: El"+error.error.message).toUpperCase(), '',{
            duration: 5000,
            verticalPosition: 'top',
            panelClass: ['error-snackbar']
          });
          this.fourFormGroup.reset();
        });
      }
  }

  openDialog(): boolean {

    const dialogRef = this.dialog.open(PoliticaTratamiento,{
      autoFocus: false,
      maxHeight: '80vh'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
      if(result){
        this.valueTratamiento = true; 
        return result;
      }else{
        this.valueTratamiento = false; 
        return false;
      }
      
    });
    this.valueTratamiento = false; 
    return false;
  }
}

@Component({
selector: 'PoliticaTratamiento',
templateUrl: 'PoliticaTratamiento.html',
})
export class PoliticaTratamiento {

}