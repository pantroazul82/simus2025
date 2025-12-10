using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class OcupacionDTO
    {
        public int AgenteId { get; set; }
        public int Id { get; set; }
        public int OficioId { get; set; }
        public string Atributo { get; set; }
        public bool EsInstrumento { get; set; }
        public bool EsGeneroMusical { get; set; }
    }
}
