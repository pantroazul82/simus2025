using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.WSDepartamento
{
    public class WSEntidadDTO
    {
        public int EntidadId { get; set; }
        public string Nombre { get; set; }
        public int Nit { get; set; }

        public int DigitoVerificacion { get; set; }

        public string LinkPortafolio { get; set; }
        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string CodigoMunicipio { get; set; }

        public string CodigoDepartamento { get; set; }
      
        public string CorreoElectronico { get; set; }

        public string Descripcion { get; set; }

        public string TipoEntidad { get; set; }
        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }
    }
}
