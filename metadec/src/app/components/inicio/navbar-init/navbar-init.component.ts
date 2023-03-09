import { Component, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-navbar-init',
  templateUrl: './navbar-init.component.html',
  styleUrls: ['./navbar-init.component.scss']
})
export class NavbarInitComponent {

  language="es";
  urlImage="../../../../assets/img/espana.png";

  constructor(public translate: TranslateService){
    this.translate.addLangs(['es','en']);
    this.translate.setDefaultLang('es');
    this.translate.use('es');
  }

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
