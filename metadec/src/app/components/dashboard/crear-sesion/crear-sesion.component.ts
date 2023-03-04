import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray, Form, FormControl } from '@angular/forms';
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MAT_MOMENT_DATE_FORMATS, MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE} from '@angular/material/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import * as moment from 'moment';
import { Hipervinculo } from '../../../../app/models/hipervinculo';
import { Sesion } from '../../../../app/models/sesion';
import { SesionService } from '../../../../app/services/sesion.service';


@Component({
  selector: 'app-crear-sesion',
  templateUrl: './crear-sesion.component.html',
  styleUrls: ['./crear-sesion.component.scss']
})
export class CrearSesionComponent {


  myFilter = (d: Date | null): boolean => {
    const day = (d || new Date()).getDay();
    // Prevent Saturday and Sunday from being selected.
    return day !== 0 && day !== 6;
  };

  mindate = new Date(Date.now());
  loading = false;
  sesionForm: FormGroup;

  constructor(private fb: FormBuilder,
              private sesionService: SesionService,
              private snackBar: MatSnackBar,
              private route: ActivatedRoute,
              private router:Router){

    this.sesionForm = this.fb.group({
      clase: ['', Validators.required],
      fecha: ['', Validators.required],
      hipervinculos: this.fb.array([])
    });
  }

  ngOnInit(): void{
    this.agegarHip();
    console.log("DD:"+this.mindate);
  }

  //Devolver Hipervinculos
  get getHipervinculos(): FormArray{
    return this.sesionForm.controls["hipervinculos"] as FormArray;
  }

  //Agregar Hipervinculos 
  agegarHip(): void{
    if (this.getHipervinculos.length<15){
      this.getHipervinculos.push(this.fb.group({
        nombreHipervinculo: ['', Validators.required],
        urlHipervinculo: ['', Validators.required],
        tipoHipervinculo: ['', Validators.required]
      }))
    }else{
      this.snackBar.open("Maximo 15 Hipervinculos por sesion", '',{
        duration: 2000,
        verticalPosition: 'top',
        panelClass: ['error-snackbar']
      });
    }
  }

  //Eliminar Hipervinculo
  eliminarHipervinculo(index: number): void{
    if (this.getHipervinculos.length === 1){
      this.snackBar.open("Minimo 1 Hipervinculo por sesion", '',{
        duration: 2000,
        verticalPosition: 'top',
        panelClass: ['error-snackbar']
      });
    }else{
      this.getHipervinculos.removeAt(index);
    }
  }

  guardarSesion():void{

    this.loading=true;
    let arrayHipervinculos: FormArray = this.sesionForm.get('hipervinculos') as FormArray;
    console.log(arrayHipervinculos.controls);
    const arrayHip: Hipervinculo[] = [];

    for (let formGroup of arrayHipervinculos.controls) {

      const hip:Hipervinculo = new Hipervinculo(
        formGroup.get('nombreHipervinculo')?.value,
        formGroup.get('urlHipervinculo')?.value,
        formGroup.get('tipoHipervinculo')?.value
      )
      arrayHip.push(hip);
    }
    console.log(arrayHip);

    const sesion: Sesion = {
      Clase: this.sesionForm.value.clase,
      FechaSesion: moment(this.sesionForm.value.fecha).format("YYYY/MM/DD"),
      Password: "",
      CodigoSesion: "",
      mdHipervinculos: arrayHip,
      MdSesionUsuarios:[{
        ClientMaster: true
      }]
    }
    console.log("MODEL SESION");
    console.log(sesion);

    this.sesionService.saveSesion(sesion).subscribe(data =>{
      this.snackBar.open(data.message, '',{
        duration: 2000,
        verticalPosition: 'top',
        panelClass: ['success-snackbar']
      });
      this.loading=false;
      this.router.navigate(['/dashboard/sesion'])
    }, error => {
      this.loading = false;
      console.log(error);
      this.snackBar.open(("ERROR: El"+error.error.message).toUpperCase(), '',{
        duration: 5000,
        verticalPosition: 'top',
        panelClass: ['error-snackbar']
      });
      this.router.navigate(['/dashboard/crear-sesion'])
    });

  }

}
