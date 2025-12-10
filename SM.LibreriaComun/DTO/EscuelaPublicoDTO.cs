using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class EscuelaPublicoDTO
    {
        public decimal EscuelaId { get; set; }
        public string NombreEscuela { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Municipio { get; set; }
        public string CodigoDepartamento { get; set; }
        public string Departamento { get; set; }
        public string Naturaleza { get; set; }
        public string Tipo { get; set; }
    }

    public class EscuelaSolicitudDTO
    {

        public decimal EscuelaId { get; set; }
        public string NombreEscuela { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public decimal UsuarioActualId { get; set; }
        public decimal UsuarioEscuelaId { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }

    }
}
