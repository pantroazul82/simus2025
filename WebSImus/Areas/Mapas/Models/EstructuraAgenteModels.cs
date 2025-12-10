using SM.LibreriaComun.DTO.GEO;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace WebSImus.Areas.Mapas.Models
{
    public class EstructuraAgenteModels
    {
        public AgenteModels responseData { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
    }

    public class AgenteModels
    {
        public IEnumerable<AgentesDptoDTO> Agentes { get; set; }

    }
}