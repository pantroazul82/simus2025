using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
    public class HomeEstandarResultado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Version { get; set; }
        public string CodDepto { get; set; }
        public string Departamento { get; set; }
        public string CodMunicipio { get; set; }
        public string Municipio { get; set; }
        public int ClasificacionId { get; set; }
        public string Clasificacion { get; set; }
    }
}
