using SM.LibreriaComun.DTO.WSDepartamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Areas.Mapas.Models
{
    public class WSEstructuraAgrupacionesModels
    {
        public AgrupacionWSModels responseData { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
    }

    public class AgrupacionWSModels
    {
        public IEnumerable<AgrupacionWSDTO> Agrupaciones { get; set; }

    }
}