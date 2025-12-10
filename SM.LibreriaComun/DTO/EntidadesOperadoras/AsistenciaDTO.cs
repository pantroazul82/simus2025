using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.EntidadesOperadoras
{
    public class AsistenciaDTO
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int ParticipanteId { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int CronogramaId { get; set; }
        public bool Asistio { get; set; }
        public string DatosAsistencia { get; set; }

        public string FechaAsistencia { get; set; }
        public Nullable<int> UsuarioCreadorId { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }

        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
       public  List<AsistenciaDiasDTO> Dias { get; set; }

    }

    public class AsistenciaDiasDTO
    {
        public int Id { get; set; }
        public int ParticipanteIdAsistente { get; set; }
        public DateTime FechaAsistenciaNueva { get; set; }
        public string asistio { get; set; }
        public bool boolasistio { get; set; }

    }

    public class AgregarAsistenciaDTO
    {
        public int Id { get; set; }
        public int ParticipanteId { get; set; }
        public string NombreCompleto { get; set; }
        public int CronogramaId { get; set; }
        public List<AsistenciaDiasDTO> listadoFechas { get; set; }


    }

    public class AutoEvaluacionDTO
    {
        public int Id { get; set; }
        public int ParticipanteId { get; set; }
        public string NombreCompleto { get; set; }
        public int CronogramaId { get; set; }
        public List<PreguntaParticipanteDTO> listadoPreguntas { get; set; }


    }

    public class PreguntaParticipanteDTO
    {
        public int preguntaId { get; set; }
        public int ParticipanteIdAsistente { get; set; }
        public string Pregunta { get; set; }
        public string respondio { get; set; }
        public bool boolrespondio { get; set; }

    }
}
