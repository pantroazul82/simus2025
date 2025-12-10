using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class UserDptoMunDTO
    {

        public int id { get; set; }
        public int idUser { get; set; }
        public string nomDpto { get; set; }
        public string codDpto { get; set; }
        public string codMun { get; set; }
        public string nomMun { get; set; }
    }
}
