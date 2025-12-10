using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
    public class SolicitudResultadoDTO
    {

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public decimal EscuelaId { get; set; }
        public string NombreEscuela { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Estado { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int EstadoId { get; set; }
        public string CorreoUsuario { get; set; }
       

    }

    public class SolicitudCelebraResultadoDTO
    {

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public int EventoId { get; set; }
        public string EntidadOrganizadora { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Estado { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int EstadoId { get; set; }
        public string CorreoUsuario { get; set; }


    }
}
