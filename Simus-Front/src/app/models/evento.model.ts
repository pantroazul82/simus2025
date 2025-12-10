export interface Evento {
  eventoId: number;
  nombre: string;
  codDepartamento?: string;
  codMunicipio?: string;
  entidadOrganizadora?: string;
  estado?: string;
  fechaEvento?: string;
  fechaCreacion?: string;
  fechaModificacion?: string;
  lugarEvento?: string;
  nombreDepartamento?: string;
  nombreMunicipio?: string;
  tipo?: string;
  anoEvento?: number;
  telefono?: string;
  email?: string;
}

export interface EventoDetalle {
  id: number;
  nombre: string;
  descripcion?: string;
  entidadOrganizadora?: string;
  fechaEvento?: string;
  horaEvento?: string;
  lugarEvento?: string;
  departamento?: string;
  municipio?: string;
  tipo?: string;
  telefono?: string;
  email?: string;
  imagen?: any;
  esDestacado?: boolean;
}

export interface Artista {
  artistaId: number;
  nombre: string;
  ocupacion?: string;
  descripcion?: string;
}

export interface Grupo {
  grupoId: number;
  nombre: string;
  cantidadMiembros?: number;
  contacto?: string;
  telefono?: string;
  enlace?: string;
}
