using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SM.LibreriaComun.DTO;

namespace WebSImus.Models
{
    public class AgentePublicoModels
    {
        public int AgenteId { get; set; }
        public string NombreCompleto { get; set; }
        public string Estado { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }
        public string TipoDocumentoDescripcion { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public int ArtMusicaUsuarioId { get; set; }
        [Required(ErrorMessage = "El tipo documento es obligatorio")]
        public string TipoDocumento { get; set; }
        [Required(ErrorMessage = "El número documento es obligatorio")]
        public string NumeroDocumento { get; set; }
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

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [DataType(DataType.Text, ErrorMessage = "La dirección debe ser tipo texto")]
        [StringLength(200, ErrorMessage = "La longitud de la dirección debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [StringLength(100, ErrorMessage = "La longitud del correo electrónico  debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = "Correo electrónico invalido.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El sexo es obligatorio")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "El país es obligatorio")]
        public string CodigoPais { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoMunicipio { get; set; }
        [StringLength(50, ErrorMessage = "La longitud del teléfono  debe ser mínimo de 4 caracteres y máximo de 50", MinimumLength = 4)]
        public string Telefono { get; set; }
        [StringLength(200, ErrorMessage = "La longitud del link portafolio debe ser mínimo de 4 caracteres y máximo de 200", MinimumLength = 4)]
        [Url(ErrorMessage = "Link portafolio invalido")]
        public string linkPortafolio { get; set; }
        public string descripcion { get; set; }

        public string facebook { get; set; }
        public string twitter { get; set; }
        public string youtube { get; set; }
        public string soundcloud { get; set; }
        public byte[] imagen { get; set; }

        public List<OcupacionDTO> listOficios { get; set; }
        public List<EstandarDTO> listServicio { get; set; }
        public List<EstandarDTO> listIntereses { get; set; }
        public List<AgenteExperienciaModels> listExperiencia { get; set; }
        public List<AgenteExperienciaModels> listFormacion { get; set; }
    }
}