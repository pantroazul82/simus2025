using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSImus.Models
{
    public class EscuelaDocumentoModels
    {
        [DataType(DataType.Upload)]
        [NotMapped]
        [Display(Name = "Archivo")]
        public HttpPostedFileBase DocumentoEscuela { get; set; }
        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoModels> documentosArchivo { get; set; }
        public int EscuelaDocumentoId { get; set; }
        public string Categoria { get; set; }
        public decimal EscuelaId { get; set; }
    }

   
}