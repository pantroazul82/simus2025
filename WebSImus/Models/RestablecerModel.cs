using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebSImus.Models
{
    public class RestablecerModel
    {
        [Required(ErrorMessage = "El campo nueva contraseña es obligatorio")]
        [StringLength(20, ErrorMessage = "La longitud de la contraseña debe ser mínimo de 4 caracteres y máximo de 20", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string contrasena { get; set; }


        [Required(ErrorMessage = "El campo confirmar nueva contraseña es obligatorio")]
        [StringLength(20, ErrorMessage = "La longitud de la contraseña debe ser mínimo de 4 caracteres y máximo de 20", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Compare("contrasena", ErrorMessage = "El campo contraseña y confirmar contraseña no son iguales")]
      
        public string confcontrasena { get; set; }
        //[Required(ErrorMessage = "El campo contraseña actual es obligatorio")]
        [StringLength(20, ErrorMessage = "La longitud de la actual contraseña debe ser mínimo de 4 caracteres y máximo de 20", MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string actualcontrasena { get; set; }


        public string correo { get; set; }
        

        public int idUserSimus { get; set; }
       
    }
}