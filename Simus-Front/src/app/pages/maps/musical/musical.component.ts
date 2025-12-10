import { Component, OnInit, AfterViewInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {
  ServinfGoogleMapsLoader,
  ComponentMapModules,
  ComponentMaps,
  ComponentMapsPoint
} from 'mincultura-servinf-googlemaps';

@Component({
  selector: 'app-musical',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './musical.component.html',
  styleUrls: ['./musical.component.css']
})
export class MusicalComponent implements OnInit, AfterViewInit {
  
  // Propiedades para los filtros
  selectedRegion: string = '';
  selectedGenre: string = '';
  selectedExpression: string = '';
  
  // Información de la región seleccionada
  selectedRegionInfo: any = null;
  
  // Géneros destacados
  featuredGenres = [
    { name: 'Cumbia', region: 'Región Caribe' },
    { name: 'Vallenato', region: 'Región Caribe' },
    { name: 'Bambuco', region: 'Región Andina' },
    { name: 'Currulao', region: 'Región Pacífica' },
    { name: 'Joropo', region: 'Región Orinoquía' }
  ];
  
  // Estadísticas
  stats = {
    genres: 150,
    departments: 32,
    municipalities: 1100,
    regions: 5
  };

  // Instancia del componente de mapa
  private mapComponent?: ComponentMaps;
  private dialogMap?: ComponentMapsPoint;

  // API Key para Google Maps 
  private readonly API_KEY = 'AIzaSyD1S_KatBI9RiyeU_VunIYDS6tWRr5QfsY';

  constructor() { }

  ngOnInit(): void {
    console.log('Componente Musical inicializado');
    console.log('API Key presente:', !!this.API_KEY);
    
    try {
      this.dialogMap = new ComponentMapsPoint();
      console.log('ComponentMapsPoint inicializado correctamente');
    } catch (error) {
      console.error('Error inicializando ComponentMapsPoint:', error);
    }
  }

  ngAfterViewInit(): void {
    console.log('Iniciando carga del mapa...');
    // Aumentar el delay para asegurar que el DOM esté completamente renderizado
    setTimeout(() => {
      this.loadMapExact();
    }, 1000);
  }

  private async loadMapExact(): Promise<void> {
    try {
      const options = {
        apiKey: this.API_KEY,
      };

      console.log('Cargando Google Maps API...');
      await ServinfGoogleMapsLoader.load(options);
      console.log('Google Maps API cargada exitosamente');
      
      const appElement = document.getElementById("googleMap");
      console.log('Elemento contenedor encontrado:', !!appElement);
      
      if (appElement) {
        console.log('Creando componente de mapa...');
        
        // Limpiar el contenedor antes de crear el mapa
        appElement.innerHTML = "";
        
        const component = new ComponentMaps(appElement as HTMLElement, ComponentMapModules.VIEWER_DATA_MODULE, {
          user_position: false,
          streetview_panel: undefined,
          map_options: false,
          search_bar: false,
          initialPoint: {
            name: "Casa Museo Casa de Nariño",
            routing: true,
            streetview: false,
            lat: 4.599872,
            lng: -74.072898,
            templateString: `
              <div id="inforwin">
                  <h2>Información General</h2>
                  <li>
                      <strong>Fundación</strong>
                      <span>20 de julio de 1908</span>
                  </li>
              </div>
          `,
            icon: "https://maps.gstatic.com/intl/en_ALL/mapfiles/dd-end.png",
          },
          layers: []
        });
        
        console.log('Mapa creado exitosamente usando el patrón del ejemplo');
        
        // Verificar el contenido después de un momento
        setTimeout(() => {
          console.log('Verificando contenido del contenedor:', appElement.innerHTML.length > 0 ? 'Tiene contenido' : 'Vacío');
          console.log('Elementos hijos:', appElement.children.length);
          if (appElement.children.length > 0) {
            console.log('Primer elemento hijo:', appElement.children[0].tagName);
          }
        }, 2000);
      } else {
        console.error('No se encontró el elemento contenedor googleMap');
        this.showMapPlaceholder();
      }
    } catch (error) {
      console.error('Error cargando el mapa:', error);
      this.showMapPlaceholder();
    }
  }

  private showMapPlaceholder(): void {
    const appElement = document.getElementById("googleMap");
    if (appElement) {
      appElement.innerHTML = `
        <div style="display: flex; align-items: center; justify-content: center; height: 100%; min-height: 400px; background-color: #f3f4f6; color: #6b7280; border-radius: 8px; border: 2px dashed #d1d5db;">
          <div style="text-align: center; padding: 20px;">
            <div style="font-size: 48px; margin-bottom: 16px;">🗺️</div>
            <h3 style="margin: 0 0 10px 0; color: #374151;">Mapa no disponible</h3>
            <p style="margin: 0 0 10px 0;">Verifica la consola del navegador para más detalles</p>
            <p style="margin: 0; font-size: 14px; color: #9ca3af;">API Key: ${this.API_KEY ? 'Configurada ✅' : 'No configurada ❌'}</p>
            <button onclick="location.reload()" style="margin-top: 15px; padding: 8px 16px; background-color: #6B46C1; color: white; border: none; border-radius: 4px; cursor: pointer;">
              Reintentar
            </button>
          </div>
        </div>
      `;
    }
  }

  // Métodos para los filtros
  onFilterChange(): void {
    console.log('Filtros cambiados:', {
      region: this.selectedRegion,
      genre: this.selectedGenre,
      expression: this.selectedExpression
    });
    // Aquí puedes implementar la lógica para filtrar los puntos del mapa
  }

  applyFilters(): void {
    console.log('Aplicando filtros:', {
      region: this.selectedRegion,
      genre: this.selectedGenre,
      expression: this.selectedExpression
    });
    
    // Nota: Los filtros se implementarán cuando se agreguen capas al mapa
    if (this.mapComponent) {
      console.log('Componente de mapa disponible para aplicar filtros');
    }
  }

  clearFilters(): void {
    this.selectedRegion = '';
    this.selectedGenre = '';
    this.selectedExpression = '';
    this.selectedRegionInfo = null;
    
    console.log('Filtros limpiados');
    
    // Restaurar todos los puntos en el mapa
    if (this.mapComponent) {

    }
  }

  showPointSelector(): void {
    if (this.dialogMap) {
      this.dialogMap.show({
        size: {
          width: 800,
          height: 600,
        },
        initial: {
          coordSeparator: ",",
          'address': "#address",
          'municipality': "#municipality", 
          'department': "#department",
          'latitude': "#latitude",
          'longitude': "#longitude"
        },
        closeToAccept: false,
        onAccept: (address: any, latLng: any) => {
          console.log('Punto seleccionado:', address, latLng);

        }
      });
    }
  }

  // Método para actualizar la información de la región seleccionada
  updateRegionInfo(regionData: any): void {
    this.selectedRegionInfo = regionData;
  }
}
