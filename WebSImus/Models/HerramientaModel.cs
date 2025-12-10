using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace WebSImus.Models
{
    public class HerramientaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la herramienta es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El  nombre  debe ser tipo texto")]
        [StringLength(1000, ErrorMessage = "La longitud del nombre debe ser mínimo de 2 caracteres y máximo de 1000", MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        public string Autores { get; set; }

        [Required(ErrorMessage = "El tipo de herramienta es obligatoria")]
        public string TipoId { get; set; }
        [Required(ErrorMessage = "El estado es obligatoria")]
        public string EstadoId { get; set; }
        public int DocumentoId { get; set; }
        [DataType(DataType.Upload)]
        [NotMapped]
        [Display(Name = "Archivo")]
        public HttpPostedFileBase Documento { get; set; }
        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoModels> documentoArchivo { get; set; }

         [Url(ErrorMessage = "url invalida.")]
        public string UrlArchivo { get; set; }
          [Url(ErrorMessage = "url invalida.")]
        public string UrlVideo { get; set; }
    }
}