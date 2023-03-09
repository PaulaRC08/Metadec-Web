import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EncuestaService } from 'app/services/encuesta.service';
import { LoginService } from '../../../../app/services/login.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-dashboard-admin',
  templateUrl: './dashboard-admin.component.html',
  styleUrls: ['./dashboard-admin.component.scss']
})
export class DashboardAdminComponent {
  view: any[] = [700, 400];
  // options
  gradient: boolean = true;
  showLegend: boolean = true;
  showLabels: boolean = true;
  isDoughnut: boolean = false;
  legendPosition: string = 'right';

  single1: any = [];
  single2: any = [];
  single3: any = [];
  single4: any = [];
  single5: any = [];

  constructor(private encuestaService :EncuestaService,
              private loginService :LoginService,
              private route: ActivatedRoute,
              private router:Router,
              private snackBar: MatSnackBar){}

  ngOnInit(): void{
    this.traerInfo();
    if(this.loginService.getTokenDecoded().TipoUsuario != "Admin"){
      this.router.navigate(['/dash-admin'])
    }
  }

  traerInfo(): void{
    this.encuestaService.getEncuestas().subscribe(data => {

      this.single1=data.pregunta1;
      this.single2=data.pregunta2;
      this.single3=data.pregunta3;
      this.single4=data.pregunta4;
      this.single5=data.pregunta5;

    }, error => {
      this.snackBar.open(" ERROR: "+ (error.error.message).toUpperCase(), '',{
        duration: 3000,
        verticalPosition: 'top',
        panelClass: ['error-snackbar']
      });
    });
  }

  colorScheme = {
    domain: ['#333333', '#8b8b8b', '#515151', '#131313', '#d1d1d1']
  };

  colorSchemeblue = {
    domain: ['#45c7f5', '#8bdeff', '#2899be', '#1c85a5', '#006377']
  };

  onSelect(data: any): void {
    console.log('Item clicked', JSON.parse(JSON.stringify(data)));
  }

  onActivate(data: any): void {
    console.log('Activate', JSON.parse(JSON.stringify(data)));
  }

  onDeactivate(data: any): void {
    console.log('Deactivate', JSON.parse(JSON.stringify(data)));
  }

  onResize(event: any) {
    this.view = [event.target.innerWidth / 1.35, 400];
    this.showLegend= !this.showLegend;
  }

}
