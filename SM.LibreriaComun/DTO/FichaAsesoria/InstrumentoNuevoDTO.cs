using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.FichaAsesoria
{
    public class InstrumentoNuevoDTO
    {
        public int Id { get; set; }
        public decimal EscuelaId { get; set; }
        public int InstrumentoId { get; set; }
        public string Instrumento { get; set; }
        public int Total { get; set; }
        public int CantidadBuenos { get; set; }
        public int CantidadRegular { get; set; }
        public int CantidadMalos { get; set; }
        public int CantidadMincultura { get; set; }
        public int CantidadPerdidos { get; set; }
        public string Descripcion { get; set; }
    
    }
}
