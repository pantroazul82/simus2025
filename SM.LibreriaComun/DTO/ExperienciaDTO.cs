using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class ExperienciaDTO
    {
        public int Id { get; set; }
        public int AgenteId { get; set; }
        public string Empresa { get; set; }
        public string Titulo { get; set; }
        public int MesInicio { get; set; }
        public int AnoInicio { get; set; }
        public int MesFin { get; set; }
        public int AnoFin { get; set; }
        public string Descripcion { get; set; }
        public bool TrabajoActual { get; set; }
        public int Tipo { get; set; }
    }
}
