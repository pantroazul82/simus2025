import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { MusicalComponent } from './pages/maps/musical/musical.component';
import { EscuelasComponent } from './pages/maps/escuelas/escuelas.component';
import { CelebraComponent } from './pages/maps/celebra/celebra.component';
import { AgrupacionesComponent } from './pages/maps/agrupaciones/agrupaciones.component';
import { EntidadesComponent } from './pages/maps/entidades/entidades.component';
import { EventosComponent } from './pages/maps/eventos/eventos.component';
import { IngresarComponent } from './pages/cuenta/ingresar/ingresar.component';
import { ActoresAgrupacionesComponent } from './pages/actores/agrupaciones/agrupaciones.component';
import { AgentesComponent } from './pages/actores/agentes/agentes.component';
import { RegistroComponent } from './pages/cuenta/registro/registro.component';
import { NotFoundComponent } from './pages/errores/not-found/not-found.component';
import { ServerErrorComponent } from './pages/errores/server-error/server-error.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'cuenta',
    children: [
      { path: 'ingresar', component: IngresarComponent },
      { path: 'registro', component: RegistroComponent },
      { path: '', redirectTo: 'ingresar', pathMatch: 'full' }
    ]
  },
  {
    path: 'mapas',
    children: [
      { path: 'musical', component: MusicalComponent },
      { path: 'escuelas', component: EscuelasComponent },
      { path: 'celebra', component: CelebraComponent },
      { path: 'agrupaciones', component: AgrupacionesComponent },
      { path: 'entidades', component: EntidadesComponent },
      { path: 'eventos', component: EventosComponent },
    ]
  },
  {
    path: 'actores',
    children: [
      { path: 'agrupaciones', component: ActoresAgrupacionesComponent },
      { path: 'agentes', component: AgentesComponent },
    ]
  },
  { path: '404', component: NotFoundComponent },
  { path: '500', component: ServerErrorComponent },
  { path: '**', redirectTo: '/404', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
