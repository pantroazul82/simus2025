using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class AgenteExperienciaModels
    {
        public int ExperienciaId { get; set; }
        public int AgenteId { get; set; }
        public int Tipo { get; set; }
         [Required(ErrorMessage = "El campo es obligatorio")]
        public string Empresa { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public int MesInicio { get; set; }
         [Required(ErrorMessage = "El campo es obligatorio")]
        public int AnoInicio { get; set; }
        public int MesFin { get; set; }
        public int AnoFin { get; set; }
        public string Descripcion { get; set; }

        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public bool TrabajoActual { get; set; }
    }
}