using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO.Servicios
{
    public class ActividadReporteDTO
    {

  
        public string Entidad { get; set; }
        public string Actividad { get; set; }
        public int Cantidad { get; set; }
    }

    public class ParticipanteXMunicipioReporteDTO
    {

        public string CodigoDane { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public int Cantidad { get; set; }
    }

    public class ParticipanteReporteDTO
    {

        public string CodigoDane { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Participante { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string DepartamentoResidencia { get; set; }
        public string MunicipioResidencia { get; set; }
        public string Cronograma { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Actividad { get; set; }
        public string TipoActividad { get; set; }
        public string Convenio { get; set; }
        public string Entidad { get; set; }
        public int Periodo { get; set; }

    }

    public class DotacionEscuelaReporteDTO
    {

        public string CodigoDane { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Participante { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string DeparamentoResidencia { get; set; }
        public string MunicipioResidencia { get; set; }
        public string Cronograma { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Actividad { get; set; }
        public string Operatividad { get; set; }
        public string Convenio { get; set; }
        public string Entidad { get; set; }
        public string Escuela { get; set; }
        public int OperatividadId { get; set; }

    }
}
