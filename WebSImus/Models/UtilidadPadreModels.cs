using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace WebSImus.Models
{
    public class UtilidadPadreModels
    {
        public int UtilidadId { get; set; }
        [Required(ErrorMessage = "El nombre de la convocatoria es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El  nombre  debe ser tipo texto")]
        [StringLength(1000, ErrorMessage = "La longitud del nombre debe ser mínimo de 2 caracteres y máximo de 1000", MinimumLength = 2)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        public string NombreEstado { get; set; }

        [Required(ErrorMessage = "El correo electrónico  es obligatorio")]
        [StringLength(200, ErrorMessage = "La longitud del correo electrónico debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = "Correo electrónico invalido.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El teléfono  es obligatorio")]
        public string Telefono { get; set; }
        public string EstadoId { get; set; }
        public bool EsActivo { get; set; }
        public int ArtMusicaUsuarioId { get; set; }
        [Required(ErrorMessage = "La fecha inicio es obligatoria")]
        public string FechaInicio { get; set; }
        [Required(ErrorMessage = "La fecha final es obligatoria")]
        public string FechaFin { get; set; }
        [Required(ErrorMessage = "La hora de inicio es obligatoria")]
        public string HoraInicio { get; set; }
        [Required(ErrorMessage = "La hora fin es obligatoria")]
        public string HoraFin { get; set; }
        [Required(ErrorMessage = "El tipo es obligatoria")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "El actor es obligatoria")]
        public string TipoActor { get; set; }

        [Required(ErrorMessage = "El tipo de utilidad es obligatorio")]
        public string Tipoutilidad { get; set; }

        [Required(ErrorMessage = "La clasificación es obligatoria")]
        public string TipoEvento { get; set; }
        public byte[] imagen { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int DocumentoId { get; set; }

        [DataType(DataType.Upload)]
        [NotMapped]
        [Display(Name = "Archivo")]
        public HttpPostedFileBase Documento { get; set; }
        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoModels> documentoArchivo { get; set; }

        // Datos ubicación
        public string CodigoPais { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Area { get; set; }
        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }
        public string OtraCiudad { get; set; }
        public DatosBasicosUtilidad DatosBasicos { get; set; }
    }

    public class DatosBasicosUtilidad
    {
        public int UtilidadId { get; set; }
    }
}