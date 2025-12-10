using System.ComponentModel.DataAnnotations;

namespace WebSImus.Models
{
    public class EventoModels
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del evento es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El nombre del evento debe ser tipo texto")]
        [StringLength(255, ErrorMessage = "La longitud del nombre del evento debe ser mínimo de 4 caracteres y máximo de 255", MinimumLength = 4)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La entidad organizadora es obligatoria")]
        [DataType(DataType.Text, ErrorMessage = "La entidad organizadora debe ser tipo texto")]
        [StringLength(512, ErrorMessage = "La longitud de la entidad organizadora del evento debe ser mínimo de 4 caracteres y máximo de 512", MinimumLength = 4)]
        public string EntidadOrganizadora { get; set; }

        [Required(ErrorMessage = "El municipio es obligatorio")]
        public string CodigoMunicipio { get; set; }
        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string CodigoDepartamento { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }

        [Required(ErrorMessage = "El lugar del evento es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El lugar del evento debe ser tipo texto")]
        [StringLength(512, ErrorMessage = "La longitud del lugar del evento debe ser mínimo de 4 caracteres y máximo de 512", MinimumLength = 4)]
        public string LugarEvento { get; set; }

        [Required(ErrorMessage = "La hora del  evento es obligatoria")]
        public string HoraEvento { get; set; }

        [Required(ErrorMessage = "La fecha del  evento es obligatorio")]
        public string FechaEvento { get; set; }
        public int ArtMusicaUsuarioId { get; set; }
        public string EstadoId { get; set; }
        public decimal ArdId { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Tipo { get; set; }
        public byte[] Imagen { get; set; }

        public string Descripcion { get; set; }

        [StringLength(50, ErrorMessage = "La longitud del teléfono debe ser mínimo de 5 caracteres y máximo de 50", MinimumLength = 5)]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }
        [EmailAddress(ErrorMessage = "La dirección de correo electrónico es invalida")]
        public string Email { get; set; }

        public bool EsDestacado { get; set; }

        public string imageDataURL { get; set; }
    }
}