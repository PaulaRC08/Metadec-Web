import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  firstFormGroup = this._formBuilder.group({
    rol: ['', Validators.required],
  });
  secondFormGroup = this._formBuilder.group({
    nombre: ['', Validators.required],
    apellido: ['', Validators.required],
    sexo: ['', Validators.required],
    avatar: ['', Validators.required],
    correo: ['', [Validators.required,Validators.email]],
    pais: ['', Validators.required],
  });
  thirdFormGroup = this._formBuilder.group({
    institucion: ['', Validators.required],
    programa: ['', Validators.required],
  });
  fourFormGroup = this._formBuilder.group({
    usuario: ['', Validators.required],
    password: ['', [Validators.required, Validators.minLength(8)]],
    politica: ['', Validators.requiredTrue]
  });
  
  isLinear = false;
  hide = true;

  constructor(private _formBuilder: FormBuilder) { }
  log(): void{
    console.log(this.firstFormGroup);
    console.log(this.secondFormGroup);
    console.log(this.thirdFormGroup);
    console.log(this.fourFormGroup);
  }

}
