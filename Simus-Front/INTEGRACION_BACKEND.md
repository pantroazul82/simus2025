# Guía de Integración Angular + Backend WebSimus

Esta guía explica cómo usar los servicios creados para consumir las APIs REST del backend WebSimus.

## 📁 Estructura Creada

```
Simus-Front/src/app/
├── models/                      # Interfaces TypeScript
│   ├── agente.model.ts
│   ├── escuela.model.ts
│   ├── entidad.model.ts
│   ├── evento.model.ts
│   └── celebra.model.ts
├── services/                    # Servicios Angular
│   ├── agentes.service.ts
│   ├── escuelas.service.ts
│   ├── entidades.service.ts
│   ├── eventos.service.ts
│   ├── celebra.service.ts
│   └── agrupacion.service.ts   # Ya existía
└── pages/actores/agentes/       # Componente de ejemplo
    ├── agentes.component.ts
    ├── agentes.component.html
    └── agentes.component.css
```

## ⚙️ Configuración Inicial

### 1. Verificar el Environment

El archivo `src/environments/environment.ts` ya está configurado:

```typescript
export const environment = {
  production: false,
  apiUrl: 'http://localhost:28950/api'
};
```

### 2. Asegurar que HttpClientModule esté importado

En tu archivo `app.module.ts` o `app.config.ts` (dependiendo de tu configuración), asegúrate de importar:

```typescript
import { HttpClientModule } from '@angular/common/http';

// En imports:
imports: [
  HttpClientModule,
  // ... otros módulos
]
```

### 3. Asegurar que FormsModule esté importado (para ngModel)

```typescript
import { FormsModule } from '@angular/forms';

imports: [
  FormsModule,
  // ... otros módulos
]
```

## 🚀 Uso de los Servicios

### Ejemplo 1: Listar Agentes

```typescript
import { Component, OnInit } from '@angular/core';
import { AgentesService } from '../services/agentes.service';
import { Agente } from '../models/agente.model';

@Component({
  selector: 'app-mi-componente',
  templateUrl: './mi-componente.component.html'
})
export class MiComponente implements OnInit {
  agentes: Agente[] = [];

  constructor(private agentesService: AgentesService) { }

  ngOnInit(): void {
    this.agentesService.getAgentes().subscribe({
      next: (data) => {
        this.agentes = data;
        console.log('Agentes:', data);
      },
      error: (error) => {
        console.error('Error:', error);
      }
    });
  }
}
```

### Ejemplo 2: Buscar Agentes

```typescript
buscarAgente(termino: string): void {
  this.agentesService.buscarAgentes(termino).subscribe({
    next: (data) => {
      this.agentes = data;
    },
    error: (error) => {
      console.error('Error:', error);
    }
  });
}
```

### Ejemplo 3: Obtener Detalle de un Agente

```typescript
verDetalleAgente(id: number): void {
  this.agentesService.getAgente(id).subscribe({
    next: (agente) => {
      console.log('Agente:', agente);

      // Obtener ocupaciones
      this.agentesService.getOcupaciones(id).subscribe({
        next: (ocupaciones) => {
          console.log('Ocupaciones:', ocupaciones);
        }
      });

      // Obtener servicios
      this.agentesService.getServicios(id).subscribe({
        next: (servicios) => {
          console.log('Servicios:', servicios);
        }
      });
    },
    error: (error) => {
      console.error('Error:', error);
    }
  });
}
```

### Ejemplo 4: Listar Entidades

```typescript
import { EntidadesService } from '../services/entidades.service';
import { Entidad } from '../models/entidad.model';

export class EntidadesComponent implements OnInit {
  entidades: Entidad[] = [];

  constructor(private entidadesService: EntidadesService) { }

  ngOnInit(): void {
    this.entidadesService.getEntidades().subscribe({
      next: (data) => {
        this.entidades = data;
      },
      error: (error) => {
        console.error('Error:', error);
      }
    });
  }
}
```

### Ejemplo 5: Obtener Eventos por Año

```typescript
import { EventosService } from '../services/eventos.service';
import { Evento } from '../models/evento.model';

export class EventosComponent implements OnInit {
  eventos: Evento[] = [];
  anoActual = new Date().getFullYear();

  constructor(private eventosService: EventosService) { }

  ngOnInit(): void {
    this.eventosService.getEventos('Música', this.anoActual).subscribe({
      next: (data) => {
        this.eventos = data;
      },
      error: (error) => {
        console.error('Error:', error);
      }
    });
  }
}
```

### Ejemplo 6: Estadísticas de Celebra

```typescript
import { CelebraService } from '../services/celebra.service';
import { EstadisticasCelebra } from '../models/celebra.model';

export class DashboardComponent implements OnInit {
  estadisticas: EstadisticasCelebra | null = null;

  constructor(private celebraService: CelebraService) { }

  ngOnInit(): void {
    this.celebraService.getEstadisticas().subscribe({
      next: (data) => {
        this.estadisticas = data;
        console.log('Estadísticas Celebra:', data);
      },
      error: (error) => {
        console.error('Error:', error);
      }
    });
  }
}
```

## 🎨 Ejemplo de Template HTML

```html
<!-- Listado de Agentes -->
<div *ngFor="let agente of agentes" class="agente-card">
  <h3>{{ agente.nombreCompleto }}</h3>
  <p>{{ agente.departamento }}, {{ agente.municipio }}</p>
  <span class="badge">{{ agente.estado }}</span>
</div>

<!-- Loading -->
<div *ngIf="loading" class="spinner">Cargando...</div>

<!-- Error -->
<div *ngIf="error" class="alert">{{ error }}</div>
```

## 📋 Métodos Disponibles por Servicio

### AgentesService
- `getAgentes()` - Obtiene todos los agentes
- `getAgente(id)` - Obtiene un agente específico
- `getOcupaciones(id)` - Obtiene ocupaciones de un agente
- `getServicios(id)` - Obtiene servicios de un agente
- `buscarAgentes(termino)` - Busca agentes por nombre

### EscuelasService
- `getInfo()` - Información de endpoints disponibles
- `getEscuela(id)` - Obtiene una escuela específica
- `getPracticas(id)` - Obtiene prácticas musicales
- `getInstitucionalidad(id)` - Obtiene datos institucionales
- `getFormacion(id)` - Obtiene datos de formación

### EntidadesService
- `getEntidades()` - Obtiene todas las entidades
- `getEntidad(id)` - Obtiene una entidad específica
- `getTiposEntidad(id)` - Obtiene tipos de entidad
- `buscarEntidades(termino)` - Busca entidades
- `getEntidadesPorDepartamento(departamento)` - Filtra por departamento
- `getEntidadesPorNaturaleza(naturaleza)` - Filtra por naturaleza

### EventosService
- `getEventos(tipo, ano)` - Obtiene todos los eventos
- `getEvento(id)` - Obtiene un evento específico
- `getConciertos(ano, municipio)` - Obtiene conciertos
- `getArtistas(id)` - Obtiene artistas de un evento
- `getGrupos(id)` - Obtiene grupos de un evento
- `getEventosPorDepartamento(departamento, tipo, ano)` - Filtra por departamento
- `getEventosPorMunicipio(municipio, tipo, ano)` - Filtra por municipio
- `getEventosDestacados(tipo, ano)` - Obtiene eventos destacados
- `buscarEventos(termino, tipo, ano)` - Busca eventos

### CelebraService
- `getEstadisticas()` - Todas las estadísticas
- `getEstadisticasMusica()` - Estadísticas de música
- `getEstadisticasDanza()` - Estadísticas de danza
- `getMunicipiosMusica()` - Cantidad de municipios (música)
- `getMunicipiosMusicaDetalle()` - Detalle de municipios
- `getCantidadConciertos()` - Cantidad de conciertos
- `getCantidadArtistas()` - Cantidad de artistas
- `getCantidadAgrupaciones()` - Cantidad de agrupaciones
- `getMunicipiosDanza()` - Cantidad de municipios (danza)
- `getDepartamentosDanza()` - Cantidad de departamentos (danza)
- `getEventosDanza()` - Cantidad de eventos de danza

## 🔧 Manejo de Errores

### Ejemplo con manejo completo de errores:

```typescript
cargarDatos(): void {
  this.loading = true;
  this.error = null;

  this.agentesService.getAgentes().subscribe({
    next: (data) => {
      this.agentes = data;
      this.loading = false;
    },
    error: (err) => {
      console.error('Error completo:', err);

      if (err.status === 404) {
        this.error = 'No se encontraron agentes';
      } else if (err.status === 500) {
        this.error = 'Error en el servidor';
      } else if (err.status === 0) {
        this.error = 'No se puede conectar con el servidor. Verifica que WebSimus esté ejecutándose.';
      } else {
        this.error = 'Error al cargar los datos';
      }

      this.loading = false;
    },
    complete: () => {
      console.log('Carga completada');
    }
  });
}
```

## 🌐 Configuración de CORS

El backend ya tiene CORS habilitado. Si experimentas problemas:

1. Verifica que WebSimus esté ejecutándose en `http://localhost:28950`
2. Abre las herramientas de desarrollo del navegador (F12)
3. Revisa la consola para ver errores de CORS
4. Asegúrate de que el `apiUrl` en environment.ts sea correcto

## 🚦 Paso a Producción

Cuando vayas a producción, actualiza el environment:

```typescript
// src/environments/environment.prod.ts
export const environment = {
  production: true,
  apiUrl: 'https://tu-dominio.com/api'
};
```

## ✅ Checklist de Integración

- [ ] HttpClientModule importado en el módulo
- [ ] FormsModule importado (si usas ngModel)
- [ ] environment.ts configurado con la URL correcta
- [ ] WebSimus ejecutándose en el puerto correcto
- [ ] Servicios inyectados en los componentes
- [ ] Manejo de errores implementado
- [ ] Loading states implementados
- [ ] Componentes declarados en el módulo correspondiente

## 🎯 Próximos Pasos

1. Crear componentes para Entidades, Eventos, Escuelas
2. Implementar rutas en `app-routing.module.ts`
3. Agregar autenticación si es necesario
4. Implementar paginación para grandes volúmenes de datos
5. Agregar filtros avanzados
6. Implementar caché para mejorar performance

## 📞 Troubleshooting

### Error: "No se puede conectar con el servidor"
- Verifica que WebSimus esté ejecutándose (F5 en Visual Studio)
- Verifica el puerto en environment.ts

### Error: "CORS policy blocked"
- Verifica que CORS esté habilitado en WebApiConfig.cs
- Limpia caché del navegador

### Error: "Cannot find module"
- Ejecuta `npm install` en la carpeta Simus-Front
- Verifica que las importaciones sean correctas

### Los datos no se muestran
- Abre F12 → Console para ver errores JavaScript
- Abre F12 → Network para ver las peticiones HTTP
- Verifica que el componente esté declarado en el módulo

## 📚 Recursos Adicionales

- [Documentación Angular HttpClient](https://angular.io/guide/http)
- [RxJS Observables](https://rxjs.dev/guide/overview)
- [Documentación completa de las APIs](../WebSImus/API_DOCUMENTATION.md)

---

**Fecha:** 2025
**Versión:** 1.0
