import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { EstadisticasCelebra, MunicipioCelebra } from '../models/celebra.model';

@Injectable({
  providedIn: 'root'
})
export class CelebraService {

  private apiUrl = `${environment.apiUrl}/celebra`;

  constructor(private http: HttpClient) { }

  /**
   * Obtiene todas las estadísticas de Celebra la Música
   */
  getEstadisticas(): Observable<EstadisticasCelebra> {
    return this.http.get<EstadisticasCelebra>(`${this.apiUrl}/estadisticas`);
  }

  /**
   * Obtiene estadísticas de música
   */
  getEstadisticasMusica(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/musica/estadisticas`);
  }

  /**
   * Obtiene estadísticas de danza
   */
  getEstadisticasDanza(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/danza/estadisticas`);
  }

  /**
   * Obtiene cantidad de municipios participantes en música
   */
  getMunicipiosMusica(): Observable<{ cantidad: number }> {
    return this.http.get<{ cantidad: number }>(`${this.apiUrl}/musica/municipios`);
  }

  /**
   * Obtiene el detalle de municipios participantes en música
   */
  getMunicipiosMusicaDetalle(): Observable<MunicipioCelebra[]> {
    return this.http.get<MunicipioCelebra[]>(`${this.apiUrl}/musica/municipios/detalle`);
  }

  /**
   * Obtiene cantidad de conciertos
   */
  getCantidadConciertos(): Observable<{ cantidad: number }> {
    return this.http.get<{ cantidad: number }>(`${this.apiUrl}/musica/conciertos`);
  }

  /**
   * Obtiene cantidad de artistas
   */
  getCantidadArtistas(): Observable<{ cantidad: number }> {
    return this.http.get<{ cantidad: number }>(`${this.apiUrl}/musica/artistas`);
  }

  /**
   * Obtiene cantidad de agrupaciones
   */
  getCantidadAgrupaciones(): Observable<{ cantidad: number }> {
    return this.http.get<{ cantidad: number }>(`${this.apiUrl}/musica/agrupaciones`);
  }

  /**
   * Obtiene cantidad de municipios participantes en danza
   */
  getMunicipiosDanza(): Observable<{ cantidad: number }> {
    return this.http.get<{ cantidad: number }>(`${this.apiUrl}/danza/municipios`);
  }

  /**
   * Obtiene cantidad de departamentos participantes en danza
   */
  getDepartamentosDanza(): Observable<{ cantidad: number }> {
    return this.http.get<{ cantidad: number }>(`${this.apiUrl}/danza/departamentos`);
  }

  /**
   * Obtiene cantidad de eventos de danza
   */
  getEventosDanza(): Observable<{ cantidad: number }> {
    return this.http.get<{ cantidad: number }>(`${this.apiUrl}/danza/eventos`);
  }
}
