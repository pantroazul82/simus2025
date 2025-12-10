using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SM.LibreriaComun.DTO.Circulacion
{
    public class EscenarioDTO
    {
        public bool EsAdmin { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "La clasificación es obligatoria")]
        public string ClasificacionId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(200, ErrorMessage = "La longitud del nombre debe ser mínimo de 2 caracteres y máximo de 200", MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string CodDepartamento { get; set; }
        [Required(ErrorMessage = "El municipio es obligatorio")]
        public string codMunicipio { get; set; }
        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string direccion { get; set; }
        [Required(ErrorMessage = "El aforo es obligatoria")]
        public string aforo { get; set; }
        [Required(ErrorMessage = "El relacionado a es obligatoria")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "El actor es obligatoria")]
        public string ActorId { get; set; }
        [StringLength(200, ErrorMessage = "La longitud de la pagina web debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [Url(ErrorMessage = "La pagina web invalido")]
        public string PaginaWeb { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [StringLength(200, ErrorMessage = "La longitud del correo electrónico  debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = "Correo electrónico invalido.")]
        public string CorreoElectronico { get; set; }
        [Required(ErrorMessage = "El contacto es obligatorio")]
        public string Contacto { get; set; }

        public string EstadoId { get; set; }

        public bool EsActivo { get; set; }

        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La hora de apertura es obligatoria")]
        public string HoraApertura { get; set; }

        [Required(ErrorMessage = "La hora de cierre es obligatoria")]
        public string HoraCierre { get; set; }

        public string NombreEstado { get; set; }

        public int DocumentoId { get; set; }
        public int UsuarioId { get; set; }

        [DataType(DataType.Upload)]
        [NotMapped]
        [Display(Name = "Archivo")]
        public HttpPostedFileBase Documento { get; set; }
        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoModels> documentoArchivo { get; set; }
        public List<EstandarDTO> DirigidoAData { get; set; }
        public List<EstandarDTO> DirigidoASeleccionada { get; set; }
        public string[] DirigidoAPublicado { get; set; }

        public ImagenesModels Imagenes { get; set; }
    }

    public class ImagenesModels
    {
        [DataType(DataType.Upload)]
        [NotMapped]
        [Display(Name = "Archivo")]
        public HttpPostedFileBase Imagenes { get; set; }
        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoModels> documentosArchivo { get; set; }
        public int ImagenId { get; set; }
        public int EscenarioId { get; set; }

        public int EventoId { get; set; }
    }
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

    public class ImagenDataDTO
    {
        public int EscenarioId { get; set; }
        public int EventoPeriodicoId { get; set; }
        public int ImagenId { get; set; }
        public bool EsPrincipal { get; set; }
       public byte[] imagen { get; set; }
  
    }
}
