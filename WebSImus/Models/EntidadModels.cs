using SM.LibreriaComun.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSImus.Models
{
    public class EntidadModels
    {
        [StringLength(1000, ErrorMessage = "La longitud del motivo  debe ser mínimo de 4 caracteres y máximo de 1000", MinimumLength = 4)]
        public string Motivo { get; set; }

        public string EstadoOldId { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la entidad es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El nombre de la entidad debe ser tipo texto")]
        [StringLength(200, ErrorMessage = "La longitud del nombre de la entidad debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El nit es obligatorio")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El NIT debe ser numérico")]
        [StringLength(9, ErrorMessage = "La longitud del NIT debe ser mínimo de 9 caracteres y máximo de 9", MinimumLength = 9)]
        public string Nit { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "El digito de verificación debe ser numérico")]
        [StringLength(1, ErrorMessage = "La longitud del digito de verificación debe ser mínimo de 1 caracteres y máximo de 1", MinimumLength = 1)]
        public string DigitoVerificacion { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoDepartamento { get; set; }
      
        public string CodigoPais { get; set; }
        [Required(ErrorMessage = "La dirección es obligatoria")]
        [DataType(DataType.Text, ErrorMessage = "La dirección debe ser tipo texto")]
        [StringLength(200, ErrorMessage = "La longitud de la dirección debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        public string Direccion { get; set; }
         [StringLength(50, ErrorMessage = "La longitud del teléfono  debe ser mínimo de 4 caracteres y máximo de 50", MinimumLength = 4)]
        public string Telefono { get; set; }
        public byte[] Imagen { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [StringLength(100, ErrorMessage = "La longitud del correo electrónico  debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = "Correo electrónico invalido.")]
        public string CorreoElectronico { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        [StringLength(200, ErrorMessage = "La longitud del link portafolio debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [Url(ErrorMessage = "Link portafolio invalido")]
        public string LinkPortafolio { get; set; }
        public int ArtMusicaUsuarioId { get; set; }
        public string EstadoId { get; set; }
        public decimal ArdId { get; set; }
        public System.DateTime FechaActualizacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La naturaleza es obligatoria")]
        public string Naturaleza { get; set; }
        public List<EstandarDTO> TipoEntidadData { get; set; }
        public List<EstandarDTO> TipoEntidadSeleccionada { get; set; }
        public string[] TipoEntidadPublicado { get; set; }
    }
}