using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class RecursoModel
    {
        public int id { get; set; }
        public int idPadre { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
       
        public string titulo { get; set; }
        public string estilo { get; set; }
        public string nombrepadre { get; set; }
        public bool activo { get; set; }
        public DateTime fechacreacion { get; set; }
        public string url { get; set; }

        public string urlaction { get; set; }
        public int idPagina { get; set; }
        public List<RecursoDTO> lstPagina { get; set; }

    }
}