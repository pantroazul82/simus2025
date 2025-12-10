using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class EmailModel
    {
        [Display(Name = "* Correo electrónico")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo electrónico  no es valido")]
        [StringLength(40, ErrorMessage = "Máximo número de caracteres sobrepasado")]
        [EmailAddress(ErrorMessage = "el Correo electrónico  no es valido")]
        [Required(ErrorMessage = "El campo Correo electrónico es obligatorio")]
        public string usuario { get; set; }
    }
}