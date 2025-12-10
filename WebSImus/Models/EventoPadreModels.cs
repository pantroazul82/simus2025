using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class EventoPadreModels
    {
        public EventoModels DatosBasicos { get; set; }
        public List<GrupoPublicoModels> listGrupos { get; set; }

        public string msg { get; set; }
        public List<ArtistaPublicoModels> listArtista { get; set; }
    }
}