using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public partial class ParticipacionModel
    {
        public decimal EscuelaId { get; set; }
        public string NombreEscuela { get; set; }
        [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
        [Required(ErrorMessage = "La cantidad de cupos es obligatorio")]
        public string CantidadCupos { get; set; }

        [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
        public string CantidadPrimeraInfancia { get; set; }

        [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
        public string CantidaEntre6y11 { get; set; }

        [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
        public string CantidaEntre12y18 { get; set; }
        [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
        public string CantidaEntre19y26 { get; set; }

        [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
        public string CantidaEntre27y60 { get; set; }

        [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
        public string CantidadMayores60 { get; set; }

        [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
        public string CantidadIndigenas { get; set; }

        [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
        public string CantidadAfrocolombiana{ get; set; }

        [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
        public string CantidadRom { get; set; }
         [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
        public string CantidadRaizales { get; set; }

         [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
         public string CantidadEtniaOtros { get; set; }

         [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
         public string CantidadHombres { get; set; }

         [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
         public string CantidadMujeres { get; set; }
         [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
         public string CantidadRural { get; set; }

         [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
         public string CantidadUrbana { get; set; }

         [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
         public string CantidadDicapacitados { get; set; }
         [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
         public string CantidadRedUnidos { get; set; }
         [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
         public string CantidadDesplazados { get; set; }
         public int TieneOrganizacionComunitaria { get; set; }
         public string OrganizacionComunitaria { get; set; }
         public string TipoOrganizacionComunitaria { get; set; }
        
        [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
        public string NumeroIntegrantes { get; set; }

        public string NombrePresidente { get; set; }
        [StringLength(100, ErrorMessage = "La longitud del teléfono celular del presidente debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        public string TelefonoCelular { get; set; }

        [StringLength(100, ErrorMessage = "La longitud del teléfono fijo del presidente debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        public string TelefonoFijo { get; set; }

        [StringLength(100, ErrorMessage = "La longitud del correo electrónico del presidente debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = "Correo electrónico del presidente invalido.")]
        public string CorreoElectronicoParticipacion { get; set; }
        public int TieneProyectosMusica { get; set; }

        //Tipos fuentes dotación
        public List<EstandarDTO> ProyectosData { get; set; }
        public List<EstandarDTO> ProyectosSeleccionada { get; set; }
        public string[] ProyectosPublicado { get; set; }
        public int TotalAlumnosEtnia { get; set; }
        public int TotalAlumnosEspeciales { get; set; }
        public int TotalAlumnosArea { get; set; }
        public int TotalAlumnosEdad { get; set; }
        public int TotalAlumnosSexo { get; set; }
    }
}