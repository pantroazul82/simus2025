using SM.LibreriaComun.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebSImus.Models
{
    public class GrupoModels
    {
        public int EventoId { get; set; }
        public int GrupoId { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(500, ErrorMessage = "La longitud del nombre debe ser mínimo de 4 caracteres y máximo de 500", MinimumLength = 4)]
        public string NombreGrupo { get; set; }
        [StringLength(200, ErrorMessage = "La longitud del enlace  debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [Url(ErrorMessage = "El enlace es invalido.  un ejemplo correcto es: http://www.mincultura.gov.co")]
        public string Enlace { get; set; }
        [Required(ErrorMessage = "El contacto es obligatorio")]
        [StringLength(200, ErrorMessage = "La longitud del contacto debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        public string Contacto { get; set; }
        [Required(ErrorMessage = "El Teléfono es obligatorio")]
        [StringLength(20, ErrorMessage = "La longitud del teléfono debe ser mínimo de 4 caracteres y máximo de 20", MinimumLength = 4)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La cantidad de miembro es obligatoria")]
        public int CantidadMiembros { get; set; }
        [Required(ErrorMessage = "El orden es obligatorio")]
        public int Orden { get; set; }
        public bool EsGrupo { get; set; }
        public byte[] imagen { get; set; }
        [Required(ErrorMessage = "La reseña es obligatoria")]
        public string Resena { get; set; }
    }
}