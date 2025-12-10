using SM.LibreriaComun.DTO.GEO;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace WebSImus.Areas.Mapas.Models
{
    public class EstructuraModels
    {
        public EscuelasModels responseData { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
    }

    public class EscuelasModels
    {
        public IEnumerable<EscuelaGeoDTO> Escuelas { get; set; }
      
    }

    
}