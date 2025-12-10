using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class ExperienciaModels
    {
        public int ExperienciaId { get; set; }
        public int AgenteId { get; set; }
        public int Tipo { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string EmpresaExp { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string TituloExp { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int MesInicioExp { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int AnoInicioExp { get; set; }
        public int MesFinExp { get; set; }
        public int AnoFinExp { get; set; }
        public string DescripcionExp { get; set; }

        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public bool TrabajoActual { get; set; }
    }
}