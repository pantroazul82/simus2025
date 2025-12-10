using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace WebSImus.Models
{
    public class EstimuloModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la convocatoria es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El  nombre  debe ser tipo texto")]
        [StringLength(300, ErrorMessage = "La longitud del nombre debe ser mínimo de 2 caracteres y máximo de 300", MinimumLength = 2)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio")]
        public string EstadoId { get; set; }
        [Required(ErrorMessage = "El periodo es obligatorio")]
        public string Periodo { get; set; }

        [Required(ErrorMessage = "La fecha de apertura es obligatoria")]
        public string FechaApertura { get; set; }

        [Required(ErrorMessage = "La fecha de cierre es obligatoria")]
        public string FechaCierre { get; set; }

        [Required(ErrorMessage = "La fecha de publicación es obligatoria")]
        public string FechaPublicacion { get; set; }
        public int DocumentoId { get; set; }
        [DataType(DataType.Upload)]
        [NotMapped]
        [Display(Name = "Archivo")]
        public HttpPostedFileBase Documento { get; set; }
        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoModels> documentoArchivo { get; set; }
    }
}