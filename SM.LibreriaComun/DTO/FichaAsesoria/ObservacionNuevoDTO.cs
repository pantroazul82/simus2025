using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.FichaAsesoria
{
    public class ObservacionNuevoDTO
    {
        public int Id { get; set; }
        public decimal EscuelaId { get; set; }
        public string Tipo { get; set; }
        public string Observaciones { get; set; }
        public string Recomendaciones { get; set; }
    }
}
