import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms'

import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AirplaneListarComponent } from './_airplane/listar/airplane-listar.component';
import { AirplaneCadastrarComponent } from './_airplane/cadastrar/airplane-cadastrar.component';
import { AirplaneEditarComponent } from './_airplane/editar/airplane-editar.component';
import { AirplaneService } from './services/airplane.service';
import { routing } from './app.routing';
import { HttpModule } from '@angular/http';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AirplaneListarComponent,
    AirplaneCadastrarComponent,
    AirplaneEditarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    routing,
    HttpModule
  ],
  providers: [
    AirplaneService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
