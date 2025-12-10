using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.Servicios
{
    public class ParticipacionListDTO
    {
        public int Id { get; set; }
        public string RelacionadoA { get; set; }
        public Nullable<int> AgenteId { get; set; }
        public Nullable<int> AgrupacionId { get; set; }
        public Nullable<int> EntidadId { get; set; }
        public Nullable<decimal> EscuelaId { get; set; }
        public int ConvocatoriaId { get; set; }
         public string Estado { get; set; }
         public string Convocatoria { get; set; }
    }

    public class ParticipacionDetalleDTO
    {
        public int Id { get; set; }
        public string RelacionadoA { get; set; }

        public int TipoActorId { get; set; }
        public int ActorId { get; set; }
        public int ConvocatoriaId { get; set; }
        public string Descipcion { get; set; }
        public int EstadoId { get; set; }
        public int UsuarioId { get; set; }
    }
}
