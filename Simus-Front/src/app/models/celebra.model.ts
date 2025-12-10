export interface EstadisticasCelebra {
  musica: {
    municipiosParticipantes: number;
    conciertos: number;
    artistas: number;
    agrupaciones: number;
  };
  danza: {
    municipiosParticipantes: number;
    departamentosParticipantes: number;
    eventos: number;
  };
}

export interface MunicipioCelebra {
  codDepartamento: string;
  codMunicipio: string;
  nombreDepartamento: string;
  nombreMunicipio: string;
  cantidad: number;
}
