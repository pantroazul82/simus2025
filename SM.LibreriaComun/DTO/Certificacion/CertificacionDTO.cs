using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.Certificacion
{
    public class CertificacionDTO
    {
        public string Id { get; set; }

        public int estadoId { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string TipoEscuelas { get; set; }


        public string Estado { get; set; }

        public string Modulo { get; set; }

        public DateTime datFechaRegistro { get; set; }

        public DateTime datFechaActualizacion { get; set; }

        public string FechaRegistro { get; set; }
        public string FechaActualizacion { get; set; }

        public string Dia { get; set; }

        public string Mes { get; set; }

        public string Year { get; set; }
    }
}
