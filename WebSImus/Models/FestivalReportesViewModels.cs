using System;
using System.Collections.Generic;

namespace WebSImus.Models
{
    // Filtros de la consulta de reportes de Festivales
    public class FestivalReporteFiltroViewModel
    {
        public bool Vigente { get; set; }
        public string Organizacion { get; set; }
        public string NombreFestival { get; set; }
        public string NombreVersion { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public int? TerritorioSonoroId { get; set; }
        public int? TipologiaId { get; set; }
        public string ModalidadParticipacion { get; set; }
        public int? ExpresionesArtisticasId { get; set; }
        public int? FuenteFinanciacionPrincipalId { get; set; }
        public int? FuenteFinanciacionSecundariaId { get; set; }
        public bool? TieneFinanciacionSecundaria { get; set; }
        public string Organizador { get; set; }
        public int? TipoOrganizadorId { get; set; }
    }

    // Resultado de cada fila de reporte
    public class FestivalReporteItemViewModel
    {
        // Identificadores internos para facilitar reportes detallados
        public int FestivalId { get; set; }
        public int VersionId { get; set; }
        // Información del Festival
        public string Organizacion { get; set; }
        public string NombreFestival { get; set; }
        public int NumeroVersiones { get; set; }
        public DateTime? FechaUltimaVersion { get; set; }
        public string DescripcionFestival { get; set; }
        public string CorreoContacto { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string PaginaWeb { get; set; }
        public string OtroEnlace { get; set; }
        public string TelefonoCelular { get; set; }
        public string Observacion { get; set; }
        
        // Información de la Versión
        public int VersionNumero { get; set; }
        public string NombreVersion { get; set; }
        public string DescripcionVersion { get; set; }
        public string PracticasMusicales { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string TerritoriosSonoros { get; set; }
        public string Tipologia { get; set; }
        public string ModalidadesParticipacion { get; set; }
        public string ExpresionesArtisticas { get; set; }
        public string FuenteFinanciacionPrincipal { get; set; }
        public string FuenteFinanciacionSecundaria { get; set; }
        public string Director { get; set; }
        public string NombreOrganizacionColectiva { get; set; }
        public string TipoOrganizador { get; set; }
        public string CorreoVersion { get; set; }
        public string InstagramVersion { get; set; }
        public string FacebookVersion { get; set; }
        public string PaginaWebVersion { get; set; }
        public string OtroEnlaceVersion { get; set; }
        public string TelefonoCelularVersion { get; set; }
        public string ObservacionesVersion { get; set; }
    }
}
