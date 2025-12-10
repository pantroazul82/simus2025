using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO.Servicios
{
    public class CronogramaReporteDTO
    {
        public int ID { get; set; }
        public string Cronograma { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal? EscuelaId { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Escuela { get; set; }
        public string Actividad { get; set; }
        public string Agente { get; set; }
        public string Convenio { get; set; }
        public int ConvenioId { get; set; }
        public int ActividadId { get; set; }
        public int CronogramaAgenteId { get; set; }
    }
    public class CronogramaEntidadDTO
    {
        public int CronogramaId { get; set; }
        public string Cronograma { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal? EscuelaId { get; set; }
        public string Escuela { get; set; }
        public string Actividad { get; set; }
        public string Agente { get; set; }
        public string Convenio { get; set; }
        public int EntidadId { get; set; }
        public string Entidad { get; set; }
    }

    public class CronogramaConvenioDTO
    {
        public int CronogramaId { get; set; }
        public string Cronograma { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Convenio { get; set; }
        public string Actividad { get; set; }
        public int ActividadId { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public int EntidadId { get; set; }
        public string Entidad { get; set; }
    }
}
