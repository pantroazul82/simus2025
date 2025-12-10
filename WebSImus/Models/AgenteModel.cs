using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class AgenteModel
    {
        [StringLength(1000, ErrorMessage = "La longitud del motivo  debe ser mínimo de 4 caracteres y máximo de 1000", MinimumLength = 4)]
        public string Motivo { get; set; }

        public string EstadoOldId { get; set; }
        public int AgenteId { get; set; }

        public string EstadoId { get; set; }
        public int ArtMusicaUsuarioId { get; set; }
        [Required(ErrorMessage = "El tipo documento es obligatorio")]
        public string TipoDocumento { get; set; }
        [Required(ErrorMessage = "El número documento es obligatorio")]
        public string NumeroDocumento { get; set; }
      
        [DataType(DataType.Text, ErrorMessage = "El nombre artístico  debe ser tipo texto")]
        [StringLength(50, ErrorMessage = "La longitud del nombre artístico debe ser mínimo de 2 caracteres y máximo de 50", MinimumLength = 2)]
        public string NombreArtistico { get; set; }
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
        public DateTime FechaNacimiento { get; set; }

        
        [DataType(DataType.Text, ErrorMessage = "La dirección debe ser tipo texto")]
        [StringLength(200, ErrorMessage = "La longitud de la dirección debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 1)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [StringLength(100, ErrorMessage = "La longitud del correo electrónico  debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = "Correo electrónico invalido.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El sexo es obligatorio")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "El país es obligatorio")]
        public string CodigoPais { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string CodigoDepartamento { get; set; }
          [Required(ErrorMessage = "El municipio es obligatorio")]
        public string CodigoMunicipio { get; set; }
         //[Required(ErrorMessage = "El teléfono es obligatoria")]
        [StringLength(50, ErrorMessage = "La longitud del teléfono  debe ser mínimo de 4 caracteres y máximo de 50", MinimumLength = 4)]
        public string Telefono { get; set; }
        [StringLength(200, ErrorMessage = "La longitud del link portafolio debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [Url(ErrorMessage = "Link portafolio invalido")]
        public string linkPortafolio { get; set; }

        public byte[] imagen { get; set; }

        [Display(Name = "Reseña")]
        //[Required(ErrorMessage = "La reseña es obligatoria")]
        [StringLength(2000, ErrorMessage = "La longitud de la reseña debe ser mínimo de 4 caracteres y máximo de 2000", MinimumLength = 4)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El área es obligatoria")]
        public string Area { get; set; }
         //desde aqui borrar cuando entremos a producción

        public List<EstandarDTO> OficiosData { get; set; }
        public List<EstandarDTO> OficiosSeleccionada { get; set; }
        public string[] OficiosPublicado { get; set; }

        public List<EstandarDTO> GeneroData { get; set; }
        public List<EstandarDTO> GenerosSeleccionada { get; set; }
        public string[] GenerosPublicado { get; set; }
    }
}