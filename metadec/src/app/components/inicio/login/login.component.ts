import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { LoginService } from '../../../services/login.service';
import { UserLogin } from '../../../models/userlogin';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  login: FormGroup;
  loading = false;
  hide = true;

  constructor(private fb: FormBuilder,
              private snackBar: MatSnackBar,
              private route: ActivatedRoute,
              private router:Router,
              private loginService: LoginService){
    this.login = this.fb.group({
      usuario: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(8)]],
    });
  }

  loginClick(): void{

    const userlogin: UserLogin ={
      usuario: this.login.value.usuario,
      password: this.login.value.password,
    };

    this.loading = true;
    
    this.loginService.login(userlogin).subscribe(data => {
      //console.log(data.usuario.nombres);
      if(data.message=="Datos incorrectos"){
        this.loading = false;
        this.login.reset();
        this.snackBar.open(" Datos Incorrectos", '',{
          duration: 3000,
          verticalPosition: 'top',
          panelClass: ['error-snackbar']
        });
      }else{
        this.loginService.setLocalStorage(data.message.token);
        this.loading = false;
        localStorage.removeItem('urlAvatar');
        localStorage.removeItem('userRegister');
        if(this.loginService.getTokenDecoded().TipoUsuario=="Admin"){
          this.router.navigate(['/dashboard/dash-admin'])
        }else{
          this.router.navigate(['/dashboard'])
        }
      }

    }, error => {
      this.loading = false;
      console.log(error);
      this.snackBar.open(" ERROR: "+ (error.error.message), '',{
        duration: 3000,
        verticalPosition: 'top',
        panelClass: ['error-snackbar']
      });
    });
    
  }
}