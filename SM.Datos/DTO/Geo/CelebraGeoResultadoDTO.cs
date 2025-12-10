using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO.Geo
{

    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos.  Tabla eventos celebra la música
    /// </summary>
    public class CelebraGeoResultadoDTO
    {
        public string CodDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public string CodMunicipio { get; set; }
        public string NombreMunicipio { get; set; }
        public int cantidad { get; set; }
        public Nullable<double> ZON_LATITUD { get; set; }
        public Nullable<double> ZON_LONGITUD { get; set; }
    }

    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos.  Trae datos detalle de los conciertos
    /// </summary>
    public class ConciertoResultadoDetalleDTO
    {
        public int ConciertoId { get; set; }
        public string CodMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Lugar { get; set; }
        public string EntidadOrganizadora { get; set; }
        public DateTime FechaEvento { get; set; }


    }

    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. Datos resultado de celebra la música
    /// /// </summary>
    public class CelebraResultadoDptoDTO
    {
        public string CodDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public int cantidad { get; set; }
      
    }

    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos.  reporte de celebra la música por municipio
    /// </summary>
    public class CelebraResultadoMunDTO
    {
        public string CodDepartamento { get; set; }
        public string CodMunicipio { get; set; }
        public string NombreMunicipio { get; set; }
        public int cantidad { get; set; }

    }


    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos.  trae la cantidad de municipios por departamento
    /// </summary>
    public class CantidadMunicipiosPorDeptoDTO
    {
        public string ZON_ID { get; set; }
        public string ZON_NOMBRE { get; set; }
        public int cantidad { get; set; }

    }
}
