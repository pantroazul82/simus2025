using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.GEO
{
   public class EjeDTO
    {
        public int EjeId { get; set; }
        public string Eje { get; set; }
        public string Resena { get; set; }
        public string RutaGaleria1 { get; set; }
        public string RutaGaleria2 { get; set; }
        public string RutaGaleria3 { get; set; }
        public string RutaGaleria4 { get; set; }
        public string RutaMarcador { get; set; }
        public string RutaFoto { get; set; }
       public  List<GenerosGeoDTO> listadoGeneros { get; set; }
    }
}
