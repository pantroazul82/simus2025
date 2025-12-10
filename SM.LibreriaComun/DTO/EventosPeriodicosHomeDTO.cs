using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
   public class EventosPeriodicosHomeDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Version { get; set; }
        public string Descripcion { get; set; }
        public string CodDepto { get; set; }
        public string Departamento { get; set; }
        public string CodMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Lugar { get; set; }
        public int ClasificacionId { get; set; }
        public string Claasificacion { get; set; }
        public int EntidadId { get; set; }
        public string NombreEntidad { get; set; }
        public string PaginaWeb { get; set; }
        public string UrlVideoYoutube { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string youtube { get; set; }
        public string soundcloud { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public List<ImagenesBanner> banner { get; set; }
        public List<EventoAosciados> eventosAsociados { get; set; }
    }

   public class EventoAosciados
   {
       public int EventoId { get; set; }
       public string Nombre { get; set; }
   }
}
