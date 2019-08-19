import { Routes, RouterModule } from '@angular/router'
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AirplaneListarComponent } from './_airplane/listar/airplane-listar.component';
import { AirplaneCadastrarComponent } from './_airplane/cadastrar/airplane-cadastrar.component';
import { AirplaneEditarComponent } from './_airplane/editar/airplane-editar.component';

const routes: Routes = [

  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'listar', component: AirplaneListarComponent },
  { path: 'cadastrar', component: AirplaneCadastrarComponent },
  { path: 'editar/:id', component: AirplaneEditarComponent }
];

export const routing = RouterModule.forRoot(routes);
