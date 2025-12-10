using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO.Servicios
{
    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. trae datos de la herramienta
    /// </summary>
    public class HerramientaResultadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TipoId { get; set; }
        public string Tipo { get; set; }
    }

    public class HerramientaResultadoDetalleDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TipoId { get; set; }
        public string Tipo { get; set; }
        public int? DocumentoId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UrlArchivo { get; set; }
        public string UrlVideo { get; set; }
        public string autores { get; set; }
    }

    public class HerramientaConsultaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoHerramienta { get; set; }
        public int TipoId { get; set; }
        public string Estado { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
