using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class FormularioDTO
    {
        public decimal ForID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string EsActiva { get; set; }
        public string Perfiles { get; set; }
        public string EsVisible { get; set; }
        public string EsEditable { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
