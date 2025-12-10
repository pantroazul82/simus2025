using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class UsuarioRolModel
    {

        public int id { set; get; }
        public string nombre { set; get; }
        public string correo { set; get; }
        public string tipoUsuario { set; get; }
        public int rolId { set; get; }
        public int nombreRol { set; get; }

       
    }
}