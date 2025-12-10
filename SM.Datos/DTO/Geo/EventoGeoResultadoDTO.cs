using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO.Geo
{
    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. trae datos de los eventos
    /// </summary>
    public class EventoGeoResultadoDTO
    {
        public int UtilidadId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string CodMunicipio { get; set; }
        public string CodDepto { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public byte[] Imagen { get; set; }
        public int TipoActorId { get; set; }
        public string TipoActor { get; set; }
        public string NombreActor { get; set; }
        public int TipoEventoId { get; set; }
        public string Clasificacion { get; set; }
        public System.Data.Entity.Spatial.DbGeography Coordenadas { get; set; }
        public Nullable<double> LatitudMunicipio { get; set; }
        public Nullable<double> LongitudMunicipio { get; set; }
        public int? DocumentoId { get; set; }
    }
}
