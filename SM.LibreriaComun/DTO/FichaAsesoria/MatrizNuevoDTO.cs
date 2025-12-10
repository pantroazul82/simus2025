using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.FichaAsesoria
{
    public class MatrizNuevoDTO
    {
        public int Id { get; set; }
        public decimal EscuelaId { get; set; }
        public string TipoM { get; set; }
        public Nullable<int> ClasificacionId { get; set; }
        public string Clasificacion { get; set; }
        public string Fortaleza { get; set; }
        public string Dificultades { get; set; }
    }
}
