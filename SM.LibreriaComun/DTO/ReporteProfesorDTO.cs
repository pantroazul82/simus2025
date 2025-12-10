using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
   public class ReporteProfesorDTO
    {
        public string Id { get; set; }
        public string departamento { get; set; }
        public string primaria { get; set; }
        public string secundaria { get; set; }
        public string tecnico { get; set; }
        public string universiatrio { get; set; }
        public string pregradomusica { get; set; }

        public string pregradootra { get; set; }
        public string total { get; set; }
    }
}
