using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class ProduccionModel
    {
        public decimal EscuelaId { get; set; }
        public string NombreEscuela { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadGirasNacionales { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadGirasInternacionales { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        [Required(ErrorMessage = "La cantidad de presentaciones o conciertos es obligatorio")]
        public string CantidadConciertos { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadDiscos { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadRepertorios { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
       public string CantidadMaterialDivulgativo { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadMaterialPedagogico { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadAgrupaciones { get; set; }
    }
}