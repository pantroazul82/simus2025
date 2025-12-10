using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.WSDatos.WSDTO
{
    public class AgenteDTO
    {
        public int AgenteId { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }

        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        public string Genero { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string CodigoMunicipio { get; set; }

        public string CodigoDepartamento { get; set; }
        public string Latitud { get; set; }

        public string Longitud { get; set; }

        public string CorreoElectronico { get; set; }

        public byte[] Imagen { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }

    }
}
