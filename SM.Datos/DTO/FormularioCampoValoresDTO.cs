using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
    public class FormularioCampoValoresDTO
    {
        public decimal FOR_ID { get; set; }
        public decimal FCO_ID { get; set; }
        public string FCO_NOMBRE { get; set; }
        public string FCO_DESCRIPCION { get; set; }
        public string FCO_TIPO_DATO { get; set; }
        public byte[] archivo { get; set; }
        public string NombreArchivo { get; set; }
        public string TipoArchivo { get; set; }
    }
}
