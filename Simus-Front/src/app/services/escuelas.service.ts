import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Escuela, PracticaMusical, Institucionalidad, Formacion } from '../models/escuela.model';

@Injectable({
  providedIn: 'root'
})
export class EscuelasService {

  private apiUrl = `${environment.apiUrl}/escuelas`;

  constructor(private http: HttpClient) { }

  /**
   * Obtiene información sobre los endpoints disponibles
   */
  getInfo(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }

  /**
   * Obtiene una escuela específica por ID
   */
  getEscuela(id: number): Observable<Escuela> {
    return this.http.get<Escuela>(`${this.apiUrl}/${id}`);
  }

  /**
   * Obtiene las prácticas musicales de una escuela
   */
  getPracticas(id: number): Observable<PracticaMusical[]> {
    return this.http.get<PracticaMusical[]>(`${this.apiUrl}/${id}/practicas`);
  }

  /**
   * Obtiene datos de institucionalidad de una escuela
   */
  getInstitucionalidad(id: number): Observable<Institucionalidad> {
    return this.http.get<Institucionalidad>(`${this.apiUrl}/${id}/institucionalidad`);
  }

  /**
   * Obtiene datos de formación de una escuela
   */
  getFormacion(id: number): Observable<Formacion> {
    return this.http.get<Formacion>(`${this.apiUrl}/${id}/formacion`);
  }
}
