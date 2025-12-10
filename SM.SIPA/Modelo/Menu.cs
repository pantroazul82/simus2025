using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.SIPA
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public string Nombre { get; set; }
        public string Estilo { get; set; }
    }
}
