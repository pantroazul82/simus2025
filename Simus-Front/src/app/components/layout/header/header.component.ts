import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  isMenuOpen = false;
  openDropdown: string | null = null;

  menuItems = [
    {
      name: 'Actores',
      children: [
        { name: 'Agentes', path: '/actores/agentes' },
        { name: 'Agrupaciones', path: '/actores/agrupaciones' },
        { name: 'Entidades', path: '/actores/entidades' },
        { name: 'Escuelas', path: '/actores/escuelas' }
      ]
    },
    {
      name: 'Mapas',
      children: [
        { name: 'Musical', path: '/mapas/musical' },
        { name: 'Escuelas', path: '/mapas/escuelas' },
        { name: 'Celebra', path: '/mapas/celebra' },
        { name: 'Agrupaciones', path: '/mapas/agrupaciones' },
        { name: 'Entidades', path: '/mapas/entidades' },
        { name: 'Eventos', path: '/mapas/eventos' }
      ]
    },
    {
      name: 'Circulación',
      children: [
        { name: 'Escenarios', path: '/circulacion/escenarios' },
        { name: 'Eventos periódicos', path: '/circulacion/eventos-periodicos' },
        { name: 'Portafolio musical de Colombia', path: '/circulacion/portafolio' },
        { name: 'Festivales de música', path: '/circulacion/festivales' }
      ]
    },
    {
      name: 'Caja de Herramientas',
      children: [
        { name: 'Convocatorias estímulos', path: '/caja-herramientas/convocatorias' },
        { name: 'Listado de convocatorias', path: '/caja-herramientas/listado-convocatorias' },
        { name: 'Estadísticas de Escuelas', path: '/caja-herramientas/estadisticas-escuelas' }
      ]
    },
    {
      name: 'Utilidades',
      children: [
        { name: 'Agenda musical', path: '/utilidades/agenda' },
        { name: 'Clasificados', path: '/utilidades/clasificados' },
        { name: 'Noticias', path: '/utilidades/noticias' },
        { name: 'Documentos', path: '/utilidades/documentos' },
        { name: 'Encuestas de percepción', path: '/utilidades/encuestas' }
      ]
    },
    {
      name: 'Territorios Sonoros',
      path: '/territorios-sonoros'
    },
    {
      name: 'Ayuda',
      children: [
        { name: 'Acerca de SIMUS', path: '/ayuda/acerca' },
        { name: 'Tutorial Escuelas de música', path: '/ayuda/tutorial-escuelas' },
        { name: 'Tutorial Agrupaciones', path: '/ayuda/tutorial-agrupaciones' },
        { name: 'Tutorial Entidades', path: '/ayuda/tutorial-entidades' },
        { name: 'Tutorial Utilidades', path: '/ayuda/tutorial-utilidades' }
      ]
    }
  ];

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }

  toggleDropdown(itemName: string) {
    if (this.openDropdown === itemName) {
      this.openDropdown = null;
    } else {
      this.openDropdown = itemName;
    }
  }
}
