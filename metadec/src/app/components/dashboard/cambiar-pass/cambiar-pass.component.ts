import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { PasswordStrengthValidator } from 'app/components/inicio/register/password-strength.validators';
import { UsuarioService } from 'app/services/usuario.service';

@Component({
  selector: 'app-cambiar-pass',
  templateUrl: './cambiar-pass.component.html',
  styleUrls: ['./cambiar-pass.component.scss']
})
export class CambiarPassComponent {
  
  hide1 = true;
  hide2 = true;
  hide3 = true;
  loading = false;
  cambiarForm: FormGroup;

  constructor(private _formBuilder: FormBuilder,
              private usuarioService: UsuarioService,
              private snackBar: MatSnackBar,
              private route: ActivatedRoute,
              private router:Router) {
    this.cambiarForm = this._formBuilder.group({
    password: ['', [Validators.required, Validators.minLength(8), PasswordStrengthValidator]],
    newPassword: ['', [Validators.required, Validators.minLength(8), PasswordStrengthValidator]],
    confirmPassword: ['', [Validators.required, Validators.minLength(8)]]
    }, { validator: this.checkPassword })
  }

  checkPassword(group: FormGroup): boolean {
    
    const pass = group.get('newPassword')?.value;
    const confirmPass = group.get('confirmPassword')?.value;
    if(pass==confirmPass){
      return true;
    }else{
      return false;
    }
    
  }

  cambiarPassword(): void {

    if(this.checkPassword(this.cambiarForm)){
      const changePassword: any = {
        passwordAnterior: this.cambiarForm.value.password,
        passwordNueva: this.cambiarForm.value.newPassword
      };
      console.log(changePassword);
      this.loading = true;
      this.usuarioService.changePassword(changePassword).subscribe(data => {
        console.log(data.message);
        if(data.message=="La password es incrorrecta"){
          this.loading = false;
          this.snackBar.open("Contraseña Incorrecta", '',{
            duration: 2000,
            verticalPosition: 'top',
            panelClass: ['error-snackbar']
          });
        }else{
          this.snackBar.open("Se cambio la contraseña", '',{
            duration: 2000,
            verticalPosition: 'top',
            panelClass: ['success-snackbar']
          });
          this.router.navigate(['/dashboard']);
        }

      }, error => {
        this.loading = false;
        console.log(error);
        this.cambiarForm.reset();
        this.snackBar.open(" Error al cambiar contraseña", '',{
          duration: 2000,
          verticalPosition: 'top',
          panelClass: ['error-snackbar']
        });
      });
    }else{
      this.cambiarForm.reset();
      this.loading = false;
      this.snackBar.open(" Contraseñas Diferentes", '',{
        duration: 2000,
        verticalPosition: 'top',
        panelClass: ['error-snackbar']
      });
    }
  }

}
