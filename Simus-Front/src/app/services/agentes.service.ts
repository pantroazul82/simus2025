import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Agente, Ocupacion, Servicio } from '../models/agente.model';

@Injectable({
  providedIn: 'root'
})
export class AgentesService {

  private apiUrl = `${environment.apiUrl}/agentes`;

  constructor(private http: HttpClient) { }

  /**
   * Obtiene todos los agentes publicados
   */
  getAgentes(): Observable<Agente[]> {
    return this.http.get<Agente[]>(this.apiUrl);
  }

  /**
   * Obtiene un agente específico por ID
   */
  getAgente(id: number): Observable<Agente> {
    return this.http.get<Agente>(`${this.apiUrl}/${id}`);
  }

  /**
   * Obtiene las ocupaciones de un agente
   */
  getOcupaciones(id: number): Observable<Ocupacion[]> {
    return this.http.get<Ocupacion[]>(`${this.apiUrl}/${id}/ocupaciones`);
  }

  /**
   * Obtiene los servicios ofrecidos por un agente
   */
  getServicios(id: number): Observable<Servicio[]> {
    return this.http.get<Servicio[]>(`${this.apiUrl}/${id}/servicios`);
  }

  /**
   * Busca agentes por nombre
   */
  buscarAgentes(termino: string): Observable<Agente[]> {
    return this.http.get<Agente[]>(`${this.apiUrl}/buscar?q=${termino}`);
  }
}
