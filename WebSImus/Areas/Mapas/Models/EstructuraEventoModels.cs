using SM.LibreriaComun.DTO;
using SM.LibreriaComun.DTO.GEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Areas.Mapas.Models
{
    public class EstructuraEventoModels
    {
        public EventoModels responseData { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
    }

    public class EstructuraEventoRecienteModels
    {
        public IEnumerable<ConciertosRecientesDTO> data { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
    }

    public class EventoModels
    {
        public IEnumerable<EventosGeoDTO> eventos { get; set; }

    }
}