using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class FormacionDTO
    {
        public decimal ENT_ID { get; set; }
        public string ENT_PROCESOS_FORMACION { get; set; }
        public bool ENT_PRACTICAS_MUSICALES_ORIENTADAS_MUSICO { get; set; }
        public bool ENT_TALLERES_INDEPENDIENTES { get; set; }
        public bool ENT_PROGRAMAS_FORMULADOS_ESCRITO { get; set; }
        public int INICIACION_DURACION_PROMEDIO_MESES { get; set; }
        public int TOTALPOBLACIONINICACION { get; set; }
        public int INICIACION_INTENSIDAD_HORAS_SEMANAL { get; set; }
        public string INICIACION_OBSERVACIONES { get; set; }
        public int BASICO_DURACION_PROMEDIO_MESES { get; set; }
        public int TOTALPOBLACIONBASICO { get; set; }
        public int BASICO_INTENSIDAD_HORAS_SEMANAL { get; set; }
        public string BASICO_OBSERVACIONES { get; set; }
        public int MEDIO_DURACION_PROMEDIO_MESES { get; set; }
        public int TOTALPOBLACIONMEDIO { get; set; }
        public int MEDIO_INTENSIDAD_HORAS_SEMANAL { get; set; }
        public string MEDIO_OBSERVACIONES { get; set; }
        public int CURSO_DURACION_PROCURSO_SEMANA { get; set; }
        public int TOTALPOBLACIONCURSO { get; set; }
        public int CURSO_INTENSIDAD_HORAS_SEMANAL { get; set; }
        public string CURSO_OBSERVACIONES { get; set; }
        public int PEDAGOGIAS_DURACION_PROPEDAGOGIAS_SEMANA { get; set; }
        public int TOTALPOBLACIONPEDAGOGIAS { get; set; }
        public int PEDAGOGIAS_INTENSIDAD_HORAS_SEMANAL { get; set; }
        public string PEDAGOGIAS_OBSERVACIONES { get; set; }
    }

    public class FormacionDatosDTO
    {
        public decimal ENT_ID { get; set; }
        public string ENT_PROCESOS_FORMACION { get; set; }
        public bool ENT_PRACTICAS_MUSICALES_ORIENTADAS_MUSICO { get; set; }
        public bool ENT_TALLERES_INDEPENDIENTES { get; set; }
        public bool ENT_PROGRAMAS_FORMULADOS_ESCRITO { get; set; }
        
      
    }
}
