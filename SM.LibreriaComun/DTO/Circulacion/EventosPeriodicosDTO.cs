using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.Circulacion
{
    public class EventosPeriodicosDTO
    {
        public int Id { get; set; }

        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Nombre { get; set; }
        public string Clasificacion { get; set; }
        public string NombreEntidad { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
