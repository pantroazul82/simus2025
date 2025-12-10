using SM.LibreriaComun.DTO.GEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Areas.Mapas.Models
{
    public class EstructuraCelebraModels
    {
        public CelebraModels responseData { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
    }

    public class CelebraModels
    {
        public IEnumerable<CelebraGeoDTO> Celebra { get; set; }

    }

    public class EstructuraCelebraTematicooModels
    {
        public CelebraDataModels responseData { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
    }

    public class CelebraDataModels
    {
        public IEnumerable<CelebraPorcentajeGeoDTO> Celebra { get; set; }

    }
}