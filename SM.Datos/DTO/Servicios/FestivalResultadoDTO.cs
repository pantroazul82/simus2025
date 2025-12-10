using System;

namespace SM.Datos.DTO.Servicios
{
    /// <summary>
    /// DTO para listado de festivales en grilla
    /// </summary>
    public class FestivalListadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaSolicitudAclaraciones { get; set; }
        public DateTime? FechaReciboAclaraciones { get; set; }
        public string Estado { get; set; }
    }

    /// <summary>
    /// DTO para detalle completo de un festival
    /// </summary>
    public class FestivalDetalleDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? VersionesRealizadas { get; set; }
        public DateTime? FechaUltimaVersion { get; set; }
        public string Descripcion { get; set; }
        public string CorreoContacto { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string PaginaWeb { get; set; }
        public string OtroEnlace { get; set; }
        public string Celular { get; set; }
        public string ObservacionesContacto { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public string Estado { get; set; }
    }

    /// <summary>
    /// DTO para creación de un nuevo festival
    /// </summary>
    public class FestivalCrearDTO
    {
        public string Nombre { get; set; }
        public int? NumeroVersiones { get; set; }
        public DateTime? FechaUltimaVersion { get; set; }
        public string Descripcion { get; set; }
        public string CorreoContacto { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string PaginaWeb { get; set; }
        public string OtroEnlace { get; set; }
        public string TelefonoCelular { get; set; }
        public string Observaciones { get; set; }
        public int IdEstado { get; set; }
    }

    /// <summary>
    /// DTO para actualización de un festival existente
    /// </summary>
    public class FestivalActualizarDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? NumeroVersiones { get; set; }
        public DateTime? FechaUltimaVersion { get; set; }
        public string Descripcion { get; set; }
        public string CorreoContacto { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string PaginaWeb { get; set; }
        public string OtroEnlace { get; set; }
        public string TelefonoCelular { get; set; }
        public string Observaciones { get; set; }
        public int IdEstado { get; set; }
    }
}
