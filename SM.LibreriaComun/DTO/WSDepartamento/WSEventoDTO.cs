using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.WSDepartamento
{
   public  class WSEventoDTO
    {
        public int EventoId { get; set; }

        public string EntidadOrganizadora { get; set; }
        public string Contacto { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime?  FechaInicio { get; set; }

        public DateTime? FechaFinal { get; set; }
        public string Clasificacion { get; set; }
        public string CodigoMunicipio { get; set; }

        public string CodigoDepartamento { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }

        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public string TipoActor { get; set; }

        public string PaginaWeb { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
