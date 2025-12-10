export interface Entidad {
  id: number;
  nombre: string;
  nit?: number;
  digitoVerificacion?: number;
  departamento?: string;
  municipio?: string;
  codigoDepartamento?: string;
  codigoMunicipio?: string;
  codigoPais?: string;
  correoElectronico?: string;
  direccion?: string;
  telefono?: string;
  linkPortafolio?: string;
  imagen?: any;
  naturaleza?: string;
  estado?: string;
  fechaCreacion?: string;
  fechaActualizacion?: string;
  descripcion?: string;
}

export interface TipoEntidad {
  id: string;
  nombre: string;
}
