using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.FichaAsesoria
{
    public class ClasificacionNuevoDTO
    {
        public int Id { get; set; }
        public decimal EscuelaId { get; set; }
        public string Tipo { get; set; }
        public Nullable<int> ClasificacionId { get; set; }
        public string Clasificacion { get; set; }
        public string Bueno { get; set; }
        public string REGULAR { get; set; }
        public string DEFICIENTE { get; set; }
        public string NOSEREALIZA { get; set; }
    }
}
