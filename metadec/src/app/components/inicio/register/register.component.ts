import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  thirdFormGroup: FormGroup;
  fourFormGroup: FormGroup;

  loading = false;
  isLinear = true;
  hide = true;

  constructor(private _formBuilder: FormBuilder,
               private usuarioService: UsuarioService,
               private snackBar: MatSnackBar,
               private route: ActivatedRoute,
               private router:Router) { 
    this.firstFormGroup = this._formBuilder.group({
      rol: ['', Validators.required],
    });
    this.secondFormGroup = this._formBuilder.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      sexo: ['', Validators.required],
      avatar: ['', Validators.required],
      correo: ['', [Validators.required,Validators.email]],
      pais: ['', Validators.required],
    });
    this.thirdFormGroup = this._formBuilder.group({
      institucion: ['', Validators.required],
      programa: [''],
    });
    this.fourFormGroup = this._formBuilder.group({
      usuario: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(8)]],
      politica: ['', Validators.requiredTrue]
    });
  }

  registrarUsuario(): void{
      
    console.log(this.fourFormGroup);

      const usuario: User = {
        Usuario: this.fourFormGroup.value.usuario,
        TipoUsuario: this.firstFormGroup.value.rol,
        Password: this.fourFormGroup.value.password,
        AvatarUrl: this.secondFormGroup.value.avatar,
        Nombres: this.secondFormGroup.value.nombre,
        Apellidos: this.secondFormGroup.value.apellido,
        Sexo: this.secondFormGroup.value.sexo,
        Correo: this.secondFormGroup.value.correo,
        TratamientoDatos: true,
        PaisId: this.secondFormGroup.value.pais
      }
      console.log(usuario);
      this.loading = true;

      this.usuarioService.saveUser(usuario).subscribe(data =>{
        console.log(data);
        this.snackBar.open(" Usuario "+usuario.Usuario+" Correctamente", '',{
          duration: 2000,
          verticalPosition: 'top',
          panelClass: ['success-snackbar']
        });
        this.router.navigate(['/inicio/login'])
      }, error => {
        this.loading = false;
        this.snackBar.open(("ERROR: El"+error.error.message).toUpperCase(), '',{
          duration: 5000,
          verticalPosition: 'top',
          panelClass: ['error-snackbar']
        });
        this.fourFormGroup.reset();
      });
  }

}
