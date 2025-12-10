using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.FichaAsesoria
{
    public class RepertorioNuevoDTO
    {
        public int Id { get; set; }
        public decimal EscuelaId { get; set; }
        public string Nombre { get; set; }
        public string Compositor { get; set; }
        public string Arreglista { get; set; }
        public int Dificultad { get; set; }
    }
}
