export interface Agente {
  agenteId: number;
  nombreCompleto: string;
  estado: string;
  nombres: string;
  apellidos: string;
  tipoDocumentoDescripcion?: string;
  pais?: string;
  departamento?: string;
  municipio?: string;
  artMusicaUsuarioId?: number;
  tipoDocumento?: string;
  numeroDocumento?: string;
  primerNombre?: string;
  segundoNombre?: string;
  primerApellido?: string;
  segundoApellido?: string;
  fechaNacimiento?: string;
  direccion?: string;
  correoElectronico?: string;
  sexo?: string;
  codigoPais?: string;
  codigoDepartamento?: string;
  codigoMunicipio?: string;
  telefono?: string;
  linkPortafolio?: string;
  descripcion?: string;
  facebook?: string;
  twitter?: string;
  youtube?: string;
  soundcloud?: string;
  imagen?: any;
}

export interface Ocupacion {
  id: string;
  nombre: string;
  descripcion?: string;
}

export interface Servicio {
  id: string;
  nombre: string;
  descripcion?: string;
}
