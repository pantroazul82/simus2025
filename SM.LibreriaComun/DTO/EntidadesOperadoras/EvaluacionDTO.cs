using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.EntidadesOperadoras
{
   public class EvaluacionDTO
    {
        public int Id { get; set; }
        public int CronogramaId { get; set; }
        public int ParticipanteId { get; set; }
        public int UsuarioId { get; set; }
        public string Evaluacion { get; set; }
        public string Descripcion { get; set; }
        public string NombreCompleto { get; set; }
    }

   public class RespuestaDTO
   {
       public int Id { get; set; }
       public int CronogramaId { get; set; }
       public int ParticipanteId { get; set; }
       public int PreguntaId { get; set; }
       public int UsuarioId { get; set; }
       public bool respuesta { get; set; }
    
   }
}
