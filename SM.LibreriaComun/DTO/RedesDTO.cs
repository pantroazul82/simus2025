using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
   public class RedesDTO
    {
    

       public string GaleriaFlicker { get; set; }

        public string DescripcionFlicker { get; set; }

        public string Facebook { get; set; }
       
        public string CanalYoutube { get; set; }
          
        public string Twitter { get; set; }

        public decimal EscuelaId { get; set; }

        public decimal GaleriaId { get; set; }

        public List<EscuelaVideoDTO> listVIdeo { get; set; }

    }
}
