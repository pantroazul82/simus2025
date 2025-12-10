using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.Circulacion
{
    public class EspacioDataDTO
    {
        public int Id { get; set; }

        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Nombre { get; set; }
        public string NombreActor { get; set; }
        public string RelacionadoA { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
