using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web.Mvc;
using System.EnterpriseServices;

namespace WebSImus.Models
{   //Clase que representa la entidad Escuelas
    public partial  class Escuelas
    {
        public decimal EscuelaId { get; set; }
        public decimal UsuarioId { get; set; }

        public int Estado { get; set; }
        [Required(ErrorMessage = "El nombre de la escuela es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El nombre de la escuela debe ser tipo texto")]
        [StringLength(100,  ErrorMessage = "La longitud del nombre de la escuela debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        public string NombreEscuela { get; set; }

        [StringLength(1000, ErrorMessage = "La longitud del motivo  debe ser mínimo de 4 caracteres y máximo de 1000", MinimumLength = 4)]
        public string Motivo { get; set; }
        //[Required(AllowEmptyStrings= false)]
        [RegularExpression(@"^\d+$", ErrorMessage = "El NIT debe ser numérico")]

        [StringLength(10, ErrorMessage = "La longitud del NIT debe ser mínimo de 9 caracteres y máximo de 10", MinimumLength = 9)]
        public string Nit { get; set; }
         [Required(ErrorMessage = "La reseña de la escuela es obligatorio")]
         [StringLength(2000, ErrorMessage = "La longitud del reseña de la escuela debe ser mínimo de 4 caracteres y máximo de 2000", MinimumLength = 4)]
        public string Resena { get; set; }
         [Required(ErrorMessage = "El nombre del contacto es obligatorio")]
         [StringLength(100, ErrorMessage = "La longitud del nombre del contacto debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        public string NombreContacto { get; set; }
        [Required(ErrorMessage = "El cargo del contacto es obligatorio")]
        [StringLength(100, ErrorMessage = "La longitud del cargo del contacto debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "El teléfono del contacto es obligatorio")]
        [StringLength(100, ErrorMessage = "La longitud del teléfono del contacto debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El correo electrónico del contacto es obligatorio")]
        [StringLength(100, ErrorMessage = "La longitud del correo electrónico del contacto debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = "Correo electrónico del contacto invalido.")]
        public string CorreoElectronico { get; set; }

         [Range(typeof(int), "4", "5", ErrorMessage = "Ingrese un número de 0  a 9999")]
         [Required(ErrorMessage = "El área es obligatoria")]
        public int Area { get; set; }
        [Required(ErrorMessage = "El teléfono de la escuela es obligatorio")]
        [StringLength(100, ErrorMessage = "La longitud del teléfono de la  escuela debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        public string TelefonoEscuela { get; set; }
        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(100, ErrorMessage = "La longitud de la dirección de la  escuela debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        public string Direccion { get; set; }

          [StringLength(100, ErrorMessage = "La longitud del fax debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        public string Fax { get; set; }

        [Required(ErrorMessage = "El correo electrónico de la escuela es obligatorio")]
        [StringLength(100, ErrorMessage = "La longitud del correo electrónico de la escuela debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = "Correo electrónico de la escuela invalido.")]
        public string CorreoElectronicoEscuela { get; set; }

          [StringLength(100, ErrorMessage = "La longitud del sitio web de la escuela debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
          [Url(ErrorMessage = "Sitio web invalido.")]
        public string SitioWeb { get; set; }

        [Required(ErrorMessage = "El año de constitución de la escuela es obligatorio")]
          public string AnoValue { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string DepartamentoSelector { get; set; }

        [Required(ErrorMessage = "El municipio es obligatorio")]
        public string MunicipioSelector { get; set; }

        [Required(ErrorMessage = "La naturaleza es obligatoria")]
        public string Naturaleza { get; set; }

        [Required(ErrorMessage = "El tipo de escuela es obligatorio")]
        public string TipoEscuelas { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }

         public string ZonaGeografica { get; set; }
        public byte[] imagen { get; set; }

        public DateTime  FechaActualizacion { get; set; }

        public string Latitud { get; set; }

        public string EstadoId { get; set; }
        public string EstadoOldId { get; set; }

        public string OperacionEscuela { get; set; }

        public string NombreEstado { get; set; }
        public string Longitud { get; set; }
        public enum TiposEscuelasenum
        {
           [Display(Name = "Escuela municipal de música")]
            Escuelasmunicipaldemusica = 1,

            [Display(Name = "Escuela comunitaria")]
             Escuelacomunitaria = 2,

            [Display(Name = "Institución educativa")]
            Institucioneducativa = 3,

            [Display(Name = "Conservatorio")]
            Conservatorio = 4,

            [Display(Name = "Escuela virtual")]
             EscuelaVirtual = 5,

            [Display(Name = "Formación técnica/tecnológica")]
             Formaciontecnicatecnologica = 6,
            [Display(Name = "Formación profesional")]
           
            FormacionProfesional = 7,
            [Display(Name = "Sin definir")]
          
            Sindefinir = 8


        }
    }
}