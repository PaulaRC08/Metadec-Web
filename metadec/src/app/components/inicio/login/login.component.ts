import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { UserLogin } from '../../../models/userlogin';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  login: FormGroup;
  loading = false;

  constructor(private fb: FormBuilder,
              private snackBar: MatSnackBar,
              private route: ActivatedRoute,
              private router:Router){
    this.login = this.fb.group({
      usuario: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  loginClick(): void{

    const userlogin: UserLogin ={
      usuario: this.login.value.usuario,
      password: this.login.value.password,
    };

    this.loading = true;
    
    setTimeout(()=>{
      if(userlogin.usuario === "Paula" && userlogin.password === "123"){
        this.router.navigate(['/dashboard'])
      }else{
        this.snackBar.open(" ERROR: Datos Incorrectos", '',{
          duration: 3000,
          verticalPosition: 'top',
          panelClass: ['blue-snackbar']
        });
      }
      this.login.reset();
    }
    ,3000);

    
  }

}
