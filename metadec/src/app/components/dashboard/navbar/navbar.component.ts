import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from '../../../../app/services/login.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  constructor(private loginService: LoginService,
              private route: ActivatedRoute,
              private router:Router,){}

  public logOut(): void{
    console.log("entro al metodo xd")
    this.loginService.removeLocalStorage();
    this.router.navigate(['/inicio'])
  }

}
