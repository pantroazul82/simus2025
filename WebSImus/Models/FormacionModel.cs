using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class FormacionModel
    {
        public decimal EscuelaId { get; set; }
        public string NombreEscuela { get; set; }
        [StringLength(3000, ErrorMessage = "La longitud de los procesos de formación debe ser mínimo de 4 caracteres y máximo de 3000", MinimumLength = 4)]
        [Required(ErrorMessage = "El proceso de formación es obligatorio")]
        public string ProcesosFormacion { get; set; }
        public List<PracticaMusicales> PracticaMusicalData { get; set; }
        public List<PracticaMusicales> PracticaMusicalSeleccionada { get; set; }
        public PublicadoPracticaMusical Publicado { get; set; }
       
        public int TieneTalleresIndependientes { get; set; }
        public int TieneProgramasPorEscrito { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string PoblacionInicio { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string DuracionInicio { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string HorasInicio { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string PoblacionBasico { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string DuracionBasico { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string HorasBasico { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string PoblacionMedio { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string DuracionMedio { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string HorasMedio { get; set; }

        [StringLength(2000, ErrorMessage = "La longitud de los procesos de formación debe ser mínimo de 4 caracteres y máximo de 2000", MinimumLength = 4)]
        public string ObservacionesNiveles { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string PoblacionCursos { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string DuracionCursos { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string HorasCursos { get; set; }


        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string PoblacionPedagogias { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string DuracionPedagogias { get; set; }

        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string HorasPedagogias { get; set; }

        [StringLength(2000, ErrorMessage = "La longitud de los procesos de formación debe ser mínimo de 4 caracteres y máximo de 2000", MinimumLength = 4)]
        public string ObservacionesTalleres { get; set; }
    }

    public class FormacionPadre
    {
        public FormacionModelNuevo basico { get; set; }
        public decimal EscuelaId { get; set; }

        public string practicaMusical { get; set; }
       
    }

    public class FormacionPractica
    {
      
        public decimal EscuelaId { get; set; }
    }
    public class FormacionModelNuevo
    {
        public decimal EscuelaId { get; set; }
        public string NombreEscuela { get; set; }
        [StringLength(3000, ErrorMessage = "La longitud de los procesos de formación debe ser mínimo de 4 caracteres y máximo de 3000", MinimumLength = 4)]
        [Required(ErrorMessage = "El proceso de formación es obligatorio")]
        public string ProcesosFormacion { get; set; }
     
        public int TieneTalleresIndependientes { get; set; }
        public int TieneProgramasPorEscrito { get; set; }
        
    }
}