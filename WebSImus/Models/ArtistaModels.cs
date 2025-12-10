using System.ComponentModel.DataAnnotations;

namespace WebSImus.Models
{
    public class ArtistaModels
    {
        public int Id { get; set; }
         [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre del artista es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El nombre del artista debe ser tipo texto")]
        [StringLength(255, ErrorMessage = "La longitud del nombre del artista debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El contacto es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El conctacto debe ser tipo texto")]
        [StringLength(255, ErrorMessage = "La longitud del contacto debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        public string Contacto { get; set; }
        [StringLength(20, ErrorMessage = "La longitud del teléfono debe ser mínimo de 5 caracteres y máximo de 20", MinimumLength = 5)]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }
        [EmailAddress(ErrorMessage = "La dirección de correo electrónico es invalida")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La cantidad de miembro es obligatoria")]
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadMiembros { get; set; }
        [Required(ErrorMessage = "El orden es obligatorio")]
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string Orden { get; set; }
        [Url(ErrorMessage = "El enlace es invalido.  un ejemplo correcto es: http://www.mincultura.gov.co")]
        public string Enlace { get; set; }
        public int EsGrupo { get; set; }
        public byte[] imagen { get; set; }
        //[Required(ErrorMessage = "La reseña es obligatoria")]
        public string Resena { get; set; }

        [Required(ErrorMessage = "El proceso es obligatorio")]
        public string ProcesoId { get; set; }

        [Required(ErrorMessage = "La categoria es obligatoria")]
        public string CategoriaId { get; set; }
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
    }
}