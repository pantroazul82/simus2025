using SM.LibreriaComun.DTO.WSDepartamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Areas.Mapas.Models
{
    public class WSEstructuraEntidadModels
    {
        public EntidadWSModels responseData { get; set; }
        public string responseDetails { get; set; }
        public int responseStatus { get; set; }
    }

    public class EntidadWSModels
    {
        public IEnumerable<WSEntidadDTO> Entidades { get; set; }

    }
}