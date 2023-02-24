import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashContentComponent } from './components/dashboard/dash-content/dash-content.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NavbarComponent } from './components/dashboard/navbar/navbar.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { LoginComponent } from './components/inicio/login/login.component';
import { RegisterComponent } from './components/inicio/register/register.component';
import { WelcomeComponent } from './components/inicio/welcome/welcome.component';

const routes: Routes = [
  { path: '', redirectTo: '/inicio', pathMatch: "full"},
  { path: 'inicio', component: InicioComponent, children:[
    { path: '', component: WelcomeComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
  ]},
  { path: 'dashboard', component: DashboardComponent, children:[
    { path: 'dash-content', component: DashContentComponent },
  ]},
  { path: '**', redirectTo: '/inicio', pathMatch: "full"},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
