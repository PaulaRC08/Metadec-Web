import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { SharedmaterialModule } from './shared/sharedmaterial/sharedmaterial.module';

import { InicioComponent } from './components/inicio/inicio.component';
import { DashboardAdminComponent } from './components/dashboard-admin/dashboard-admin.component';
import { RegisterComponent } from './components/inicio/register/register.component';
import { LoginComponent } from './components/inicio/login/login.component';
import { WelcomeComponent } from './components/inicio/welcome/welcome.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NavbarComponent } from './components/dashboard/navbar/navbar.component';
import { DashContentComponent } from './components/dashboard/dash-content/dash-content.component';
import { LoadingComponent } from './shared/components/loading/loading.component';




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
    LoadingComponent
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
    SharedmaterialModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
