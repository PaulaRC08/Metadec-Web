import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';
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
      this.loginService.setLocalStorage(data.token);
      this.loading = false;
      this.router.navigate(['/dashboard/dash-content'])
    }, error => {
      this.loading = false;
      this.snackBar.open(" ERROR: "+ error.error.message.toUpperCase(), '',{
        duration: 3000,
        verticalPosition: 'top',
        panelClass: ['error-snackbar']
      });
    });
    
  }

}
