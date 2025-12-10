using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SM.LibreriaComun.DTO;
using System.Web.Mvc;

namespace WebSImus.Models
{
    public class FormularioCamposModels
    {
        public decimal FCO_ID { get; set; }
        public string FCO_NOMBRE { get; set; }
        public string FCO_DESCRIPCION { get; set; }
        public string FCO_TIPODATO { get; set; }
        public string FCO_ESOBLIGATORIA { get; set; }
        public Nullable<decimal> FLI_ID { get; set; }
        public decimal FOR_ID { get; set; }
        public Nullable<int> FCO_ORDEN { get; set; }
        public Nullable<decimal> FSC_ID { get; set; }
        public string FSC_NOMBRE { get; set; }
        public Nullable<int> FSC_DUPLICACIONES { get; set; }
        public IEnumerable<SelectListItem> ColeccionDatos { get; set; }
        public List<EstandarDTO> listadoData { get; set; }
   
    }
}