using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class FormularioValoresDTO
    {
        public decimal FVA_ID { get; set; }
        public string FVA_VALOR { get; set; }
        public decimal FCO_ID { get; set; }
        public decimal FRE_ID { get; set; }
        public decimal FOR_ID { get; set; }
        public Nullable<int> FVA_DUPLICACION { get; set; }
        public string FCO_NOMBRE { get; set; }
    }
}
