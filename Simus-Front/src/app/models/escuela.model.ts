export interface Escuela {
  escuelaId: number;
  nombreEscuela: string;
  departamento: string;
  municipio: string;
  codigoDepartamento?: string;
  codigoMunicipio?: string;
  estado: string;
  naturaleza?: string;
  fechaCreacion?: string;
  fechaActualizacion?: string;
  direccion?: string;
  telefono?: string;
  correoElectronico?: string;
  sitioWeb?: string;
  latitud?: string;
  longitud?: string;
}

export interface PracticaMusical {
  id: string;
  nombre: string;
  escuelaId?: string;
}

export interface Institucionalidad {
  nombreDirector?: string;
  telefonoCelularDirector?: string;
  correoElectronicoDirector?: string;
  actividadMusical?: number;
  creadaLegalmente?: number;
}

export interface Formacion {
  escuelaId: number;
  nombreEscuela?: string;
  procesosFormacion?: string;
  tieneTalleresIndependientes?: number;
  tieneProgramasPorEscrito?: number;
}
