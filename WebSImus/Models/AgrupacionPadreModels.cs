using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class AgrupacionPadreModels
    {
        public AgrupacionModels DatosBasicos { get; set; }
        public List<AgentePublicoModels> listAgentes { get; set; }
       
    }
}