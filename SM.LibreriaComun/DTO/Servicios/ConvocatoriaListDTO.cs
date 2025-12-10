using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.Servicios
{
    public class ConvocatoriaListDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Estado { get; set; }
        public string RelacionadoA { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public int DocumentoId { get; set; }

    }

    public class ParticipacionListadoDTO
    {
        public int Id { get; set; }
        public int TipoActorId { get; set; }
        public int ConvocatoriaId { get; set; }
        public int ActorId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string FechaRegistro { get; set; }
        public string RelacionadoA { get; set; }
        public string Usuario { get; set; }

    }

    public class ConvocatoriaNuevoDTO
    {
        public int Id { get; set; }
        public int EstadoId { get; set; }
        public int DocumentoId { get; set; }
        public int ActorId { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public string RelacionadoA { get; set; }
        public int TipoActorId { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }

    }

    public class DotacionListDTO
    {
        public int Id { get; set; }
        public string Cargo { get; set; }
        public string Nombre { get; set; }
        public string NombreEntidad { get; set; }
        public int EntidadId { get; set; }
        public decimal EscuelaId { get; set; }
        public string NombreEscuela { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
       
    }

  
}
