using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class EventoDanzaModels
    {
        public int Id { get; set; }
        public int DocumentoId { get; set; }
        [Required(ErrorMessage = "El nombre del evento es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El nombre del evento debe ser tipo texto")]
        [StringLength(255, ErrorMessage = "La longitud del nombre del evento debe ser mínimo de 4 caracteres y máximo de 255", MinimumLength = 4)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La entidad organizadora es obligatoria")]
        [DataType(DataType.Text, ErrorMessage = "La entidad organizadora debe ser tipo texto")]
        [StringLength(512, ErrorMessage = "La longitud de la entidad organizadora del evento debe ser mínimo de 4 caracteres y máximo de 512", MinimumLength = 4)]
        public string EntidadOrganizadora { get; set; }

        public string CodigoMunicipio { get; set; }
   
        public string CodigoDepartamento { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }

        [Required(ErrorMessage = "El lugar del evento es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El lugar del evento debe ser tipo texto")]
        [StringLength(512, ErrorMessage = "La longitud del lugar del evento debe ser mínimo de 4 caracteres y máximo de 512", MinimumLength = 4)]
        public string LugarEvento { get; set; }

        [Required(ErrorMessage = "La hora inicial del evento es obligatoria")]
        public string HoraEvento { get; set; }

        [Required(ErrorMessage = "La fecha  incial del  evento es obligatorio")]
        public string FechaEvento { get; set; }

        [Required(ErrorMessage = "La hora final del evento es obligatoria")]
        public string HoraEventoFinal { get; set; }

        [Required(ErrorMessage = "La fecha final del evento es obligatorio")]
        public string FechaEventoFinal { get; set; }
        public int ArtMusicaUsuarioId { get; set; }
        public string EstadoId { get; set; }
        public decimal ArdId { get; set; }

       [Required(ErrorMessage = "El evento es Nacional (Toda Colombia), o se desarrollará en un municipio en particular.")]
        public int Nacional { get; set; }
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Tipo { get; set; }
        public byte[] Imagen { get; set; }

        [NotMapped]
        //[Required(ErrorMessage = "{0} Es obligatorio.")]
        [DataType(DataType.Upload)]
        [Display(Name = "Archivo")]
        public HttpPostedFileBase ArchivoAgenda { get; set; }

        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoModels> documentoArchivo { get; set; }

        public string Descripcion { get; set; }

        [StringLength(20, ErrorMessage = "La longitud del teléfono debe ser mínimo de 5 caracteres y máximo de 20", MinimumLength = 5)]
        public string Telefono { get; set; }
      [EmailAddress(ErrorMessage = "La dirección de correo electrónico es invalida")]
        public string Email { get; set; }

        public bool EsDestacado { get; set; }
    }
}