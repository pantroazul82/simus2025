using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class GrupoPublicoModels
    {
        public int GrupoId { get; set; }
        public string Nombre { get; set; }
        public string Enlace { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public int CantidadMiembros { get; set; }
    }
}