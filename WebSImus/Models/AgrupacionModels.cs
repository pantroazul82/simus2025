using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace WebSImus.Models
{
    public class AgrupacionModels
    {
        public int AgrupacionId { get; set; }
        public int AgenteId { get; set; }
        [Required(ErrorMessage = "El tipo de agrupación es obligatorio")]
        public string TipoAgrupacionId { get; set; }

        [Required(ErrorMessage = "La naturaleza es obligatoria")]
        public string NaturalezaId { get; set; }
        public string EstadoId { get; set; }
        public int ArtMusicaUsuarioId { get; set; }
        [Required(ErrorMessage = "El tipo documento es obligatorio")]
        public string TipoDocumento { get; set; }
        [Required(ErrorMessage = "El número documento es obligatorio")]
        public string NumeroDocumento { get; set; }
        [Required(ErrorMessage = "El nombre de la agrupación es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El  nombre  debe ser tipo texto")]
        [StringLength(50, ErrorMessage = "La longitud del nombre debe ser mínimo de 2 caracteres y máximo de 200", MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El primer nombre es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El primer nombre  debe ser tipo texto")]
        [StringLength(50, ErrorMessage = "La longitud del primer nombre debe ser mínimo de 2 caracteres y máximo de 50", MinimumLength = 2)]
        public string PrimerNombre { get; set; }
        [DataType(DataType.Text, ErrorMessage = "El segundo nombre  debe ser tipo texto")]
        [StringLength(50, ErrorMessage = "La longitud del segundo nombre debe ser mínimo de 2 caracteres y máximo de 50", MinimumLength = 2)]
        public string SegundoNombre { get; set; }
        [Required(ErrorMessage = "El primer apellido es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El primer apellido  debe ser tipo texto")]
        [StringLength(50, ErrorMessage = "La longitud del primer apellido debe ser mínimo de 2 caracteres y máximo de 50", MinimumLength = 2)]
        public string PrimerApellido { get; set; }
        [DataType(DataType.Text, ErrorMessage = "El segundo apellido  debe ser tipo texto")]
        [StringLength(50, ErrorMessage = "La longitud del segundo apellido debe ser mínimo de 2 caracteres y máximo de 50", MinimumLength = 2)]
        public string SegundoApellido { get; set; }
        [Required(ErrorMessage = "La dirección es obligatoria")]
        [DataType(DataType.Text, ErrorMessage = "La dirección debe ser tipo texto")]
        [StringLength(200, ErrorMessage = "La longitud de la dirección debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [StringLength(100, ErrorMessage = "La longitud del correo electrónico  debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = "Correo electrónico invalido.")]
        public string CorreoElectronico { get; set; }
        [Required(ErrorMessage = "El país es obligatorio")]
        public string CodigoPais { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoMunicipio { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud del teléfono  debe ser mínimo de 4 caracteres y máximo de 50", MinimumLength = 4)]
        public string Telefono { get; set; }
        [StringLength(200, ErrorMessage = "La longitud del link portafolio debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [Url(ErrorMessage = "Link portafolio invalido")]
        public string linkPortafolio { get; set; }
        public byte[] imagen { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaActualizacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public List<EstandarDTO> GeneroData { get; set; }
        public List<EstandarDTO> GenerosSeleccionada { get; set; }
        public string[] GenerosPublicado { get; set; }
    }

    public class AgrupacionNuevoModels
    {
        [StringLength(1000, ErrorMessage = "La longitud del motivo  debe ser mínimo de 4 caracteres y máximo de 1000", MinimumLength = 4)]
        public string Motivo { get; set; }

        public string EstadoOldId { get; set; }
        public int AgrupacionId { get; set; }
        [Required(ErrorMessage = "El tipo de agrupación es obligatorio")]
        public string TipoAgrupacionId { get; set; }

        [Required(ErrorMessage = "El área es obligatoria")]
        public string AreaId { get; set; }
        [Required(ErrorMessage = "La naturaleza es obligatoria")]
        public string NaturalezaId { get; set; }
        public string EstadoId { get; set; }
        public int ArtMusicaUsuarioId { get; set; }
       
        [Required(ErrorMessage = "El nombre de la agrupación es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El  nombre  debe ser tipo texto")]
        [StringLength(200, ErrorMessage = "La longitud del nombre debe ser mínimo de 2 caracteres y máximo de 200", MinimumLength = 2)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [DataType(DataType.Text, ErrorMessage = "La dirección debe ser tipo texto")]
        [StringLength(200, ErrorMessage = "La longitud de la dirección debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [StringLength(200, ErrorMessage = "La longitud del correo electrónico  debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = "Correo electrónico invalido.")]
        public string CorreoElectronico { get; set; }

        public string CodigoPais { get; set; }
        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string CodigoDepartamento { get; set; }
        [Required(ErrorMessage = "El municipio es obligatorio")]
        public string CodigoMunicipio { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud del teléfono  debe ser mínimo de 4 caracteres y máximo de 50", MinimumLength = 4)]
        public string Telefono { get; set; }
        [StringLength(200, ErrorMessage = "La longitud del link portafolio debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [Url(ErrorMessage = "Link portafolio invalido")]
        public string linkPortafolio { get; set; }
        public byte[] imagen { get; set; }
        [Required(ErrorMessage = "La reseña es obligatoria")]
        public string Descripcion { get; set; }
        public System.DateTime FechaActualizacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        [DataType(DataType.Upload)]
        [NotMapped]
        [Display(Name = "Archivo")]
        public HttpPostedFileBase DocumentoEPK { get; set; }
        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoModels> documentoArchivo { get; set; }
        public int DocumentoId { get; set; }
    }
}