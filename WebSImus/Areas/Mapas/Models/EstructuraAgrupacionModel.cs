using SM.LibreriaComun.DTO.GEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Areas.Mapas.Models
{
    public class EstructuraAgrupacionModel
    {
        public AgrupacionModels responseData { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
    }

    public class AgrupacionModels
    {
        public IEnumerable<EntidadesGeoDTO> Agrupaciones { get; set; }

    }
}