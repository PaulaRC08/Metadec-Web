import { NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AddTokenInterceptor } from '../app/helper/add-token.interceptor'

import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { SharedmaterialModule } from './shared/sharedmaterial/sharedmaterial.module';

import { InicioComponent } from './components/inicio/inicio.component';
import { DashboardAdminComponent } from './components/dashboard-admin/dashboard-admin.component';
import { RegisterComponent } from './components/inicio/register/register.component';
import { PoliticaTratamiento } from './components/inicio/register/register.component';
import { LoginComponent } from './components/inicio/login/login.component';
import { WelcomeComponent } from './components/inicio/welcome/welcome.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NavbarComponent } from './components/dashboard/navbar/navbar.component';
import { DashContentComponent } from './components/dashboard/dash-content/dash-content.component';
import { LoadingComponent } from './shared/components/loading/loading.component';
import { CrearSesionComponent } from './components/dashboard/crear-sesion/crear-sesion.component';
import { NavbarInitComponent } from './components/inicio/navbar-init/navbar-init.component';
import { NetiquetaComponent } from './components/inicio/netiqueta/netiqueta.component';
import { AvatarComponent } from './components/inicio/avatar/avatar.component';
import { SesionComponent } from './components/dashboard/sesion/sesion.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import {ReactiveFormsModule } from '@angular/forms';
import {MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatDividerModule} from '@angular/material/divider';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule } from '@angular/material/core';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatStepperModule} from '@angular/material/stepper';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatMenuModule} from '@angular/material/menu';
import {FlexLayoutModule } from '@angular/flex-layout';
import {ClipboardModule} from '@angular/cdk/clipboard';
import {MatDialogModule} from '@angular/material/dialog';

export function HttpLoaderFactory( http: HttpClient){
  return new TranslateHttpLoader(http, './assets/i18n/', '.json')
}




@NgModule({
  declarations: [
    AppComponent,
    InicioComponent,
    DashboardAdminComponent,
    RegisterComponent,
    LoginComponent,
    WelcomeComponent,
    DashboardComponent,
    NavbarComponent,
    DashContentComponent,
    LoadingComponent,
    CrearSesionComponent,
    NavbarInitComponent,
    NetiquetaComponent,
    AvatarComponent,
    SesionComponent,
    PoliticaTratamiento
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader:{
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    MatSlideToggleModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BrowserModule,
    MatSlideToggleModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatDividerModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatExpansionModule,
    MatStepperModule,
    MatCheckboxModule,
    MatSnackBarModule,
    MatProgressBarModule,
    MatMenuModule,
    FlexLayoutModule,
    ClipboardModule,
    MatDialogModule,
    BrowserAnimationsModule,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AddTokenInterceptor, multi: true },],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
