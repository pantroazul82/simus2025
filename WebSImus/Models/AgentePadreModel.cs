using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class AgentePadreModel
    {
        public AgenteModel DatosBasicos { get; set; }
        public List<AgenteExperienciaModels> listExperiencia { get; set; }
        public List<AgenteExperienciaModels> listFormacion { get; set; }
    }

    public class DotacionPadreModel
    {
        public DotacionModel DatosBasicos { get; set; }
        public DotacionDocumentoModels Documentos { get; set; }
        public InstrumentoModels Instrumentos { get; set; }
        public string NombreEntidad { get; set; }
        public string NombreEscuela { get; set; }

    }

    public class DotacionModel
    {
        public int Id { get; set; }

        public int ConvocatoriaId { get; set; }
        public int EntidadId { get; set; }
        public string EscuelaId { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(200, ErrorMessage = "La longitud del nombre debe ser mínimo de 3 caracteres y máximo de 200", MinimumLength = 3)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(200, ErrorMessage = "La longitud del apellido debe ser mínimo de 3 caracteres y máximo de 200", MinimumLength = 3)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio")]
        [StringLength(200, ErrorMessage = "La longitud del cargo debe ser mínimo de 3 caracteres y máximo de 200", MinimumLength = 3)]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "La identificacion es obligatoria")]
        [StringLength(15, ErrorMessage = "La longitud de la identificación debe ser mínimo de 3 caracteres y máximo de 15", MinimumLength = 3)]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud del teléfono  debe ser mínimo de 4 caracteres y máximo de 50", MinimumLength = 4)]
        public string Telefono { get; set; }
        public string Celular { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        [StringLength(100, ErrorMessage = "La longitud del correo electrónico  debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = "Correo electrónico invalido.")]
        public string Email { get; set; }
    }

    public class DotacionDocumentoModels
    {
        [DataType(DataType.Upload)]
        [NotMapped]
        [Display(Name = "Archivo")]
        public HttpPostedFileBase DocumentoEscuela { get; set; }
        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoModels> documentosArchivo { get; set; }
        public int DotacionDocumentoId { get; set; }
        public string Categoria { get; set; }
        public int DotacionId { get; set; }
    }

    public class InstrumentoModels
    {
       
        public int InstrumentoId { get; set; }
        public string Instrumentos { get; set; }
        public string Prioridad { get; set; }
        public int DotacionId { get; set; }
        public string Cantidad { get; set; }
    }
}