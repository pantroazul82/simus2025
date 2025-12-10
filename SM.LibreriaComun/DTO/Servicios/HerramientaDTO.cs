using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.Servicios
{
    public class HerramientaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TipoId { get; set; }
        public string Tipo { get; set; }
    }
    public class HerramientaDetalleDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Autores { get; set; }
        public int TipoId { get; set; }
        public int EstadoId { get; set; }
        public string Tipo { get; set; }
        public int DocumentoId { get; set; }
        public string FechaRegistro { get; set; }
        public string UrlArchivo { get; set; }
        public string UrlVideo { get; set; }

        public string UrlVideoEmbebido { get; set; }
        public bool EsVideo { get; set; }
        public int UsuarioId { get; set; }
    }

    public class HerramientaDataDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoHerramienta { get; set; }
        public int TipoId { get; set; }
        public int EstadoId { get; set; }
        public int DocumentoId { get; set; }
        public string Estado { get; set; }
        public string UrlArchivo { get; set; }
        public string UrlYoutube { get; set; }
        public string Descripcion { get; set; }
        public string Autores { get; set; }
        public string FechaActualizacion { get; set; }
    }
}
