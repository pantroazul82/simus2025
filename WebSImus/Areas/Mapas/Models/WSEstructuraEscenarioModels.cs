using SM.LibreriaComun.DTO.WSDepartamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Areas.Mapas.Models
{
    public class WSEstructuraEscenarioModels
    {
        public EscenarioWSModels responseData { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
    }

    public class EscenarioWSModels
    {
        public IEnumerable<AgrupacionWSDTO> Escenarios { get; set; }

    }
}