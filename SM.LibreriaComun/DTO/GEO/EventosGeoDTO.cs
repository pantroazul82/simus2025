using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.GEO
{
   public  class EventosGeoDTO
    {
        public int UtilidadId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string CodMunicipio { get; set; }
        public string CodDepto { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public byte[] Imagen { get; set; }
        public string rutaFoto { get; set; }
        public int TipoActorId { get; set; }
        public string TipoActor { get; set; }
        public string Direccion { get; set; }
        public string Ubicacion { get; set; }
        public string NombreActor { get; set; }
        public int TipoEventoId { get; set; }
        public int DocumentoId { get; set; }
        public string Clasificacion { get; set; }
        public Geometry geometry { get; set; }
    }

   public class AgendaDTO
   {
       public int UtilidadId { get; set; }
       public string Titulo { get; set; }
       public string Descripcion { get; set; }
       public string CodMunicipio { get; set; }
       public string CodDepto { get; set; }
       public string Municipio { get; set; }
       public string Departamento { get; set; }
       public string Telefono { get; set; }
       public string Email { get; set; }
       public DateTime FechaInicio { get; set; }
       public DateTime FechaFin { get; set; }
      
   }
}
