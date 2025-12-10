using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class AgenteDTO
    {
        public int AgenteId { get; set; }

        public int EstadoId { get; set; }
        public int ArtMusicaUsuarioId { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreArtistico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public string Sexo { get; set; }
        public string CodigoPais { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoArea { get; set; }
        public string Telefono { get; set; }
        public string linkPortafolio { get; set; }
        public string Descripcion { get; set; }
        public byte[] imagen { get; set; }
    }
}
