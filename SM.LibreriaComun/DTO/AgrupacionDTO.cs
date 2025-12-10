using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class AgrupacionDTO
    {
        public int AgrupacionId { get; set; }
        public int AgenteId { get; set; }
        public int TipoAgrupacionId { get; set; }
        public int NaturalezaId { get; set; }
        public int EstadoId { get; set; }
        public int DocumentoId { get; set; }
        public int ArtMusicaUsuarioId { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public string CodigoPais { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Telefono { get; set; }
        public string linkPortafolio { get; set; }
        public byte[] imagen { get; set; }
        public string Descripcion { get; set; }
        public decimal ArdId { get; set; }
        public System.DateTime FechaActualizacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int AreaId { get; set; }
    }
}
