import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { LoginService } from '../../../../app/services/login.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  constructor(private loginService: LoginService,
              public translate: TranslateService,
              private route: ActivatedRoute,
              private router:Router){}

  public logOut(): void{
    console.log("entro al metodo xd")
    this.loginService.removeLocalStorage();
    this.router.navigate(['/inicio'])
  }
  isDocente = false;
  linklogo = "/dashboard";
  ngOnInit(): void{
    if(this.loginService.getTokenDecoded().TipoUsuario == "Docente"){
      this.isDocente = true;
    }else if(this.loginService.getTokenDecoded().TipoUsuario == "Admin"){
      this.linklogo = "/dashboard/dash-admin";
    }
  }
  
  language="es";
  urlImage="../../../../assets/img/espana.png";

  changeLanguage(){

    if(this.language == "es"){
      this.urlImage="../../../../assets/img/estados-unidos.png";
      this.language="en";
      this.translate.use('en');
      console.log(this.language+"Ingles");
    }else{
      this.urlImage="../../../../assets/img/espana.png";
      this.language="es";
      this.translate.use('es');
      console.log(this.language+"Español");
    }
  }
}
