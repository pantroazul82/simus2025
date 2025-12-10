using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class RolDTO
    {
        public int id { set; get; }
        public string codigo { set; get; }
        public string nombre { set; get; }
        public DateTime fecha { set; get; }

        public bool esescogido { get; set; }
        public IList<int> SelectedRols { get; set; }
       
    }

 
}
