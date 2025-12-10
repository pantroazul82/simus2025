using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class FormularioCamposDTO
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
        public List<BasicaDTO> listadoBasico { get; set; }
    }
}
