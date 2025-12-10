using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class ReporteComplexDTO
    {
        public string Id { get; set; }

        public string departamento { get; set; }
        public string criterio6 { get; set; }
        public string criterio7 { get; set; }
        public string criterio12 { get; set; }
        public string criterio19 { get; set; }
        public string criterio26 { get; set; }
    }

    public class ReporteDescargarDTO
    {
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string codMunicipio { get; set; }
        public string Nombre { get; set; }
        public string Naturaleza { get; set; }
        public string criterio6 { get; set; }
        public string criterio7 { get; set; }
        public string criterio12 { get; set; }
        public string criterio19 { get; set; }
        public string criterio26 { get; set; }
        public string criterio27 { get; set; }
        public string criterio28 { get; set; }
        public string criterio29 { get; set; }
    }
}
