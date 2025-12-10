using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class EventoDanzaPadreModels
    {
        public EventoDanzaModels DatosBasicos { get; set; }
        public List<GrupoPublicoModels> listGrupos { get; set; }
    }
}