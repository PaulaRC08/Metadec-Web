import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CrearSesionComponent } from './components/dashboard/crear-sesion/crear-sesion.component';
import { DashContentComponent } from './components/dashboard/dash-content/dash-content.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NavbarComponent } from './components/dashboard/navbar/navbar.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { LoginComponent } from './components/inicio/login/login.component';
import { NavbarInitComponent } from './components/inicio/navbar-init/navbar-init.component';
import { NetiquetaComponent } from './components/inicio/netiqueta/netiqueta.component';
import { AvatarComponent } from './components/inicio/avatar/avatar.component';
import { RegisterComponent } from './components/inicio/register/register.component';
import { WelcomeComponent } from './components/inicio/welcome/welcome.component';

import { SesionComponent } from './components/dashboard/sesion/sesion.component';
import { CommonModule } from '@angular/common';
import { CambiarPassComponent } from './components/dashboard/cambiar-pass/cambiar-pass.component';
import { DashboardAdminComponent } from './components/dashboard/dashboard-admin/dashboard-admin.component';
import { AuthGuard } from './helper/auth.guard';


const routes: Routes = [
  { path: '', redirectTo: '/inicio', pathMatch: "full"},
  { path: 'inicio', component: NavbarInitComponent, children:[
    { path: '', component: WelcomeComponent },
    { path: 'netiqueta', component: NetiquetaComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent},
    { path: 'avatar', component: AvatarComponent },
  ]},
  { path: 'dashboard', component: NavbarComponent, canActivate:[AuthGuard], children:[
    { path: '', component: DashContentComponent },
    { path: 'dash-admin', component: DashboardAdminComponent },
    { path: 'sesion', component: SesionComponent },
    { path: 'cambiarPass', component: CambiarPassComponent },
    { path: 'crear-sesion', component: CrearSesionComponent },
  ]},
  { path: '**', redirectTo: '/inicio', pathMatch: "full"},
];

@NgModule({
  imports: [RouterModule.forRoot(routes), CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
