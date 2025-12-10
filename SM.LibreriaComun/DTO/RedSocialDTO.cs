using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class RedSocialDTO
    {
        public int RedSocialId { get; set; }
        public string Nombre { get; set; }
        public string valor { get; set; }
        public string Estilo { get; set; }
        public string Etiqueta { get; set; }
    }
}
