using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.WSDepartamento
{
   public class AgenteWSDTO
    {
        public int AgenteId { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Descripcion { get; set; }
        public string CorreoElectronico { get; set; }
        public string LinkPortafolio { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoDepartamento { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string NombreArtistico { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Identificacion { get; set; }

        public string CodigoTipoDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public byte[] Imagen { get; set; }
        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }
    }
}
