using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class EntidadDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Nit { get; set; }
        public int DigitoVerificacion { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoDepartamento { get; set; }
        public int CodigoPais { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public byte[] Imagen { get; set; }
        public string CorreoElectronico { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string LinkPortafolio { get; set; }
        public int ArtMusicaUsuarioId { get; set; }
        public int EstadoId { get; set; }
        public decimal ArdId { get; set; }
        public System.DateTime FechaActualizacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }
        public string Naturaleza { get; set; }
    }
}
