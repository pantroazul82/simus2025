using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class DocumentoModels
    {
       
            public int DocumentoId { get; set; }


            [Display(Name = "Token del archivo:")]
            public string Token { get; set; }

            [Display(Name = "Nombre archivo:")]
            public string NombreArchivo { get; set; }

            [Display(Name = "Extensión archivo:")]
            public string ExtensionArchivo { get; set; }

            [Display(Name = "Archivo:")]
            public byte[] BytesArchivo { get; set; }

            [Display(Name = "Tamaño archivo:")]
            public decimal TamanoArchivo { get; set; }

            [Display(Name = "Tipo contenido:")]
            public string TipoContenido { get; set; }

            [DataType(DataType.DateTime)]
            [Display(Name = "Fecha de registro:")]
            public DateTime FechaRegistro { get; set; }

            public int UsuarioId { get; set; }

            [Display(Name = "Nombre del usuario:")]
            public string NombreUsuario { get; set; }
            public override string ToString()
            {
                return string.Format("Nombre archivo: {0} - Tipo: {1} - Tamaño: {2} ", NombreArchivo, TipoContenido, TamanoArchivo);
            }
        
    }
}