using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
    public class ParticipantesResultadoDTO
    {
        public int AsistenciaId { get; set; }
        public int AgenteId { get; set; }
        public int CronogramaId { get; set; }
        public int ActividadId { get; set; }
        public string Cronograma { get; set; }
        public string Nombres { get; set; } 
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }

    public class AsistenteResultadoDTO
    {
        public int AsistenciaId { get; set; }
        public int AgenteId { get; set; }
        public int CronogramaId { get; set; }
        public DateTime FechaAsistencia { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        
    }
}
