using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class MenuDTO
    {
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public string Nombre { get; set; }
        public string Estilo { get; set; }
    }
}
