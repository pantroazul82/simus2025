using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO.Servicios
{
    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. trae datos de la dotación
    /// </summary>
    public class DotacionResultadoDTO
    {
        public int Id { get; set; }
        public string Cargo { get; set; }
        public string Nombre { get; set; }
        public string NombreEntidad { get; set; }
        public int EntidadId { get; set; }
        public decimal EscuelaId { get; set; }
        public string NombreEscuela { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
    }
}
