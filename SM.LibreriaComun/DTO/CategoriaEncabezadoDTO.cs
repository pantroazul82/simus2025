using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class CategoriaEncabezadoDTO
    {
        public decimal EscuelaId { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> Porcentaje { get; set; }
        public string Categoria { get; set; }
    }
}
