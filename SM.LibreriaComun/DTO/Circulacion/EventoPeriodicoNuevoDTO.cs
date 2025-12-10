using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.Circulacion
{
    public class EventoPeriodicoNuevoDTO
    {
        public bool EsAdmin { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "El tipo evento es obligatorio")]
        public string TipoEventoId { get; set; }
        public string Tipo { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(200, ErrorMessage = "La longitud del nombre debe ser mínimo de 2 caracteres y máximo de 200", MinimumLength = 2)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La versión es obligatoria")]
        public string Version { get; set; }
        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string CodDepartamento { get; set; }
        [Required(ErrorMessage = "El municipio es obligatorio")]
        public string codMunicipio { get; set; }

        [Required(ErrorMessage = "El lugar es obligatorio")]
        public string lugar { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [StringLength(200, ErrorMessage = "La longitud del correo electrónico  debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = "Correo electrónico invalido.")]
        public string CorreoElectronico { get; set; }
        [Required(ErrorMessage = "El actor es obligatoria")]
        public string ActorId { get; set; }
        [StringLength(200, ErrorMessage = "La longitud de la pagina web debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [Url(ErrorMessage = "La pagina web invalido")]
        public string PaginaWeb { get; set; }
         [Url(ErrorMessage = "La url youtube invalido")]
        public string UrlVideoYoutube { get; set; }
          [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        public string EstadoId { get; set; }
        public bool EsActivo { get; set; }
        public string NombreEstado { get; set; }
        public int UsuarioId { get; set; }
        public ImagenesModels Imagenes { get; set; }

    }
}
