import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AgentesService } from '../../../services/agentes.service';
import { Agente } from '../../../models/agente.model';

@Component({
  selector: 'app-agentes',
  templateUrl: './agentes.component.html',
  styleUrls: ['./agentes.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule]
})
export class AgentesComponent implements OnInit {

  agentes: Agente[] = [];
  loading: boolean = false;
  error: string = '';
  searchTerm: string = '';

  constructor(private agentesService: AgentesService) { }

  ngOnInit(): void {
    this.cargarAgentes();
  }

  /**
   * Carga todos los agentes publicados
   */
  cargarAgentes(): void {
    this.loading = true;
    this.error = '';

    this.agentesService.getAgentes().subscribe({
      next: (data) => {
        this.agentes = data;
        this.loading = false;
        console.log('Agentes cargados:', data);
      },
      error: (err) => {
        console.error('Error al cargar agentes:', err);
        this.error = 'Error al cargar los agentes. Por favor intenta de nuevo.';
        this.loading = false;
      }
    });
  }

  /**
   * Busca agentes por nombre
   */
  buscar(): void {
    if (!this.searchTerm.trim()) {
      this.cargarAgentes();
      return;
    }

    this.loading = true;
    this.error = '';

    this.agentesService.buscarAgentes(this.searchTerm).subscribe({
      next: (data) => {
        this.agentes = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error al buscar agentes:', err);
        this.error = 'Error al buscar agentes. Por favor intenta de nuevo.';
        this.loading = false;
      }
    });
  }

  /**
   * Limpia la búsqueda y recarga todos los agentes
   */
  limpiarBusqueda(): void {
    this.searchTerm = '';
    this.cargarAgentes();
  }
}
