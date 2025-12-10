import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AgrupacionService {

  private apiUrl = `${environment.apiUrl}/agrupaciondata`;

  constructor(private http: HttpClient) { }

  getAgrupaciones(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
