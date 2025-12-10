using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class CategorizacionResumenDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int PadreId { get; set; }
        public decimal Porcentaje { get; set; }
        public int Valor { get; set; }
        public string ValorPorcentaje { get; set; }
        public string Estilo { get; set; }
        public int barra { get; set; }
    }
}
