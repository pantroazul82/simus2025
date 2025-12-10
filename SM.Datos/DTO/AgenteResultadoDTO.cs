using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. trae datos de los agentes
    /// </summary>
    public class AgenteResultadoDTO
    {
        public int AgenteId { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodMunicipio { get; set; }
        public string CodPais { get; set; }
        public string Telefono { get; set; }
        public int CodTipoDocumento { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public System.DateTime FechaActualizacion { get; set; }
        public string Identificacion { get; set; }
        public byte[] Imagen { get; set; }
        public string Sexo { get; set; }
        public string LinkPortafolio { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string TipoDocumentoDescripcion { get; set; }
    }
}
