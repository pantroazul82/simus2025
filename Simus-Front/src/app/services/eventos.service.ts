import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Evento, EventoDetalle, Artista, Grupo } from '../models/evento.model';

@Injectable({
  providedIn: 'root'
})
export class EventosService {

  private apiUrl = `${environment.apiUrl}/eventos`;

  constructor(private http: HttpClient) { }

  /**
   * Obtiene todos los eventos
   */
  getEventos(tipo: string = 'Música', ano?: number): Observable<Evento[]> {
    let params = new HttpParams().set('tipo', tipo);
    if (ano) {
      params = params.set('ano', ano.toString());
    }
    return this.http.get<Evento[]>(this.apiUrl, { params });
  }

  /**
   * Obtiene un evento específico por ID
   */
  getEvento(id: number): Observable<EventoDetalle> {
    return this.http.get<EventoDetalle>(`${this.apiUrl}/${id}`);
  }

  /**
   * Obtiene la programación de conciertos
   */
  getConciertos(ano: number, municipio?: string): Observable<any[]> {
    let params = new HttpParams().set('ano', ano.toString());
    if (municipio) {
      params = params.set('municipio', municipio);
    }
    return this.http.get<any[]>(`${this.apiUrl}/conciertos`, { params });
  }

  /**
   * Obtiene los artistas de un evento
   */
  getArtistas(id: number): Observable<Artista[]> {
    return this.http.get<Artista[]>(`${this.apiUrl}/${id}/artistas`);
  }

  /**
   * Obtiene los grupos de un evento
   */
  getGrupos(id: number): Observable<Grupo[]> {
    return this.http.get<Grupo[]>(`${this.apiUrl}/${id}/grupos`);
  }

  /**
   * Obtiene eventos por departamento
   */
  getEventosPorDepartamento(departamento: string, tipo: string = 'Música', ano?: number): Observable<Evento[]> {
    let params = new HttpParams().set('tipo', tipo);
    if (ano) {
      params = params.set('ano', ano.toString());
    }
    return this.http.get<Evento[]>(`${this.apiUrl}/departamento/${departamento}`, { params });
  }

  /**
   * Obtiene eventos por municipio
   */
  getEventosPorMunicipio(municipio: string, tipo: string = 'Música', ano?: number): Observable<Evento[]> {
    let params = new HttpParams().set('tipo', tipo);
    if (ano) {
      params = params.set('ano', ano.toString());
    }
    return this.http.get<Evento[]>(`${this.apiUrl}/municipio/${municipio}`, { params });
  }

  /**
   * Obtiene eventos destacados
   */
  getEventosDestacados(tipo: string = 'Música', ano?: number): Observable<Evento[]> {
    let params = new HttpParams().set('tipo', tipo);
    if (ano) {
      params = params.set('ano', ano.toString());
    }
    return this.http.get<Evento[]>(`${this.apiUrl}/destacados`, { params });
  }

  /**
   * Busca eventos por nombre
   */
  buscarEventos(termino: string, tipo: string = 'Música', ano?: number): Observable<Evento[]> {
    let params = new HttpParams()
      .set('q', termino)
      .set('tipo', tipo);
    if (ano) {
      params = params.set('ano', ano.toString());
    }
    return this.http.get<Evento[]>(`${this.apiUrl}/buscar`, { params });
  }
}
