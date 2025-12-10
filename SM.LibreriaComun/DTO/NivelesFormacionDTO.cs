using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class NivelesFormacionDTO
    {
        public decimal EscuelaId { get; set; }
        public int Id { get; set; }
        public int FormacionPracticaNuevoId { get; set; }
        public string NombreNiveles { get; set; }
        public string Cantidadgrupos { get; set; }
        public string CantidadIntegrantes { get; set; }
        public string HoraSemanal { get; set; }
    }


    public enum Niveles
    {
        Inicial,
        Basico,
        Medio
    }

}
