using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class RolModel
    {
        public int id { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "solo es permitido caracteres para el campo codigo")]
        public string codigo { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "solo es permitido caracteres para el campo nombre")]
        public string nombre { get; set; }
        public DateTime fechacreacion { get; set; }

        public IList<RecursoDTO> recusos { get; set; }
    }
}