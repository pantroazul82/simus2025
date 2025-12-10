import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Entidad, TipoEntidad } from '../models/entidad.model';

@Injectable({
  providedIn: 'root'
})
export class EntidadesService {

  private apiUrl = `${environment.apiUrl}/entidades`;

  constructor(private http: HttpClient) { }

  /**
   * Obtiene todas las entidades publicadas
   */
  getEntidades(): Observable<Entidad[]> {
    return this.http.get<Entidad[]>(this.apiUrl);
  }

  /**
   * Obtiene una entidad específica por ID
   */
  getEntidad(id: number): Observable<Entidad> {
    return this.http.get<Entidad>(`${this.apiUrl}/${id}`);
  }

  /**
   * Obtiene los tipos de entidad
   */
  getTiposEntidad(id: number): Observable<TipoEntidad[]> {
    return this.http.get<TipoEntidad[]>(`${this.apiUrl}/${id}/tipos`);
  }

  /**
   * Busca entidades por nombre o NIT
   */
  buscarEntidades(termino: string): Observable<Entidad[]> {
    return this.http.get<Entidad[]>(`${this.apiUrl}/buscar?q=${termino}`);
  }

  /**
   * Obtiene entidades por departamento
   */
  getEntidadesPorDepartamento(departamento: string): Observable<Entidad[]> {
    return this.http.get<Entidad[]>(`${this.apiUrl}/departamento/${departamento}`);
  }

  /**
   * Obtiene entidades por naturaleza (Pública/Privada)
   */
  getEntidadesPorNaturaleza(naturaleza: string): Observable<Entidad[]> {
    return this.http.get<Entidad[]>(`${this.apiUrl}/naturaleza/${naturaleza}`);
  }
}
