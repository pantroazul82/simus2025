using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO.Servicios
{
    public class DotacionReporteDTO
    {
        public int Id { get; set; }
        public string CodigoDane { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Cronograma { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Actividad { get; set; }
        public int TipoActividadId { get; set; }
        public string TipoActividad { get; set; }
        public string Convenio { get; set; }
        public string Entidad { get; set; }
        public int Periodo { get; set; }
        public string Fuente { get; set; }
        public string Elemento { get; set; }
        public string Tipo { get; set; }
        public string Formato { get; set; }
        public decimal Valor { get; set; }
        public int Cantidad { get; set; }
    }
}
