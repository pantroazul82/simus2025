using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.Servicios
{
    public class ActividadListadoDTO
    {

        public string Entidad { get; set; }
        public string Actividad { get; set; }
        public int Cantidad { get; set; }
    }

    public class ParticipanteXMunicipioListadoDTO
    {

        public string CodigoDane { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public int Cantidad { get; set; }
    }

    public class ParticipanteListadoDTO
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
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Actividad { get; set; }
        public string TipoActividad { get; set; }
        public string Convenio { get; set; }
        public string Entidad { get; set; }
        public int Periodo { get; set; }

    }

   

    public class DotacionEscuelaListadoDTO
    {

        public string CodigoDane { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Cronograma { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Actividad { get; set; }
        public string Operatividad { get; set; }
        public string Convenio { get; set; }
        public string Entidad { get; set; }
        public string Escuela { get; set; }
        public int OperatividadId { get; set; }

    }

    public class DotacionListadoDTO
    {
        public int Id { get; set; }
        public string CodigoDane { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Cronograma { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
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
