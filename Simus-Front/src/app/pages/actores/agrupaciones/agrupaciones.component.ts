import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AgrupacionService } from '../../../services/agrupacion.service';

@Component({
  selector: 'app-actores-agrupaciones',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './agrupaciones.component.html',
  styleUrls: ['./agrupaciones.component.css']
})
export class ActoresAgrupacionesComponent implements OnInit {

  agrupaciones: any[] = [];
  filteredAgrupaciones: any[] = [];

  // Filtros
  departamentos: string[] = [];
  municipios: string[] = [];
  selectedDepartamento: string = '';
  selectedMunicipio: string = '';

  constructor(private agrupacionService: AgrupacionService) { }

  ngOnInit(): void {
    this.agrupacionService.getAgrupaciones().subscribe((data: any) => {
      this.agrupaciones = data;
      this.filteredAgrupaciones = data;
      this.extractFiltros(data);
    });
  }

  extractFiltros(data: any[]): void {
    const departamentosSet = new Set<string>();
    const municipiosSet = new Set<string>();
    data.forEach(item => {
      if (item.departamento) {
        departamentosSet.add(item.departamento);
      }
      if (item.municipio) {
        municipiosSet.add(item.municipio);
      }
    });
    this.departamentos = [...departamentosSet].sort();
    this.municipios = [...municipiosSet].sort();
  }

  applyFilters(): void {
    this.filteredAgrupaciones = this.agrupaciones.filter(item => {
      const depMatch = !this.selectedDepartamento || item.departamento === this.selectedDepartamento;
      const munMatch = !this.selectedMunicipio || item.municipio === this.selectedMunicipio;
      return depMatch && munMatch;
    });
  }

  clearFilters(): void {
    this.selectedDepartamento = '';
    this.selectedMunicipio = '';
    this.filteredAgrupaciones = this.agrupaciones;
  }
}