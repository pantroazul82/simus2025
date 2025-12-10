using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SM.LibreriaComun.DTO.EntidadesOperadoras
{
  
    public class ConvenioDTO
    {
        public int Id { get; set; }
        [DisplayName("Número de convenio *")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El  nombre  debe ser tipo texto")]
        [StringLength(200, ErrorMessage = "La longitud del nombre debe ser mínimo de 2 caracteres y máximo de 199", MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El objeto es requerido")]
        [DataType(DataType.Text, ErrorMessage = "El  objeto  debe ser tipo texto")]
        [StringLength(1000, ErrorMessage = "La longitud del objeto debe ser mínimo de 2 caracteres y máximo de 1000", MinimumLength = 2)]
        [DisplayName("Objeto *")]
        public string Objeto { get; set; }
        [Required(ErrorMessage = "El valor es obligatoria")]
        [DisplayName("Valor ($) *")]
        public string Valor { get; set; }
          [DisplayName("Entidad *")]
        [Required(ErrorMessage = "la entidad es obligatoria")]
        public string EntidadId { get; set; }
        [Required(ErrorMessage = "El coordinador es obligatorio")]
        [DisplayName("Coordinador *")]
        public string Coord_AgenteId { get; set; }
        public string Periodo { get; set; }
        [Required(ErrorMessage = "La fecha inicio es obligatoria")]
        [DisplayName("Fecha inicio *")]
        public string FechaInicio { get; set; }
        [Required(ErrorMessage = "La fecha final es obligatoria")]
        [DisplayName("Fecha fin *")]
        public string FechaFin { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio")]
        [DisplayName("Estado *")]
        public string EstadoId { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int UsuarioCreadorId { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
        public string NombreEntidad { get; set; }

        [DataType(DataType.Upload)]
        [NotMapped]
        [Display(Name = "Archivo")]
        public HttpPostedFileBase DocumentoEPK { get; set; }
        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoDTO> documentoArchivo { get; set; }
        public int DocumentoId { get; set; }
    }

    public class ConvenioConsultaDTO
    {
        public int Id { get; set; }
        [DisplayName("Número de convenio *")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El  nombre  debe ser tipo texto")]
        [StringLength(200, ErrorMessage = "La longitud del nombre debe ser mínimo de 2 caracteres y máximo de 199", MinimumLength = 2)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El objeto es requerido")]
        [DataType(DataType.Text, ErrorMessage = "El  objeto  debe ser tipo texto")]
        [StringLength(1000, ErrorMessage = "La longitud del objeto debe ser mínimo de 2 caracteres y máximo de 1000", MinimumLength = 2)]
        [DisplayName("Objeto *")]
        public string Objeto { get; set; }
        [Required(ErrorMessage = "El valor es obligatoria")]
        [DisplayName("Valor ($) *")]
        public string Valor { get; set; }
        [DisplayName("Entidad *")]
        [Required(ErrorMessage = "la entidad es obligatoria")]
        public string EntidadId { get; set; }
        [Required(ErrorMessage = "El coordinador es obligatorio")]
        [DisplayName("Coordinador *")]
        public string Coord_AgenteId { get; set; }
        public string Periodo { get; set; }
        [Required(ErrorMessage = "La fecha inicio es obligatoria")]
        [DisplayName("Fecha inicio *")]
        public string FechaInicio { get; set; }
        [Required(ErrorMessage = "La fecha final es obligatoria")]
        [DisplayName("Fecha fin *")]
        public string FechaFin { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio")]
        [DisplayName("Estado *")]
        public string EstadoId { get; set; }
        public string Descripcion { get; set; }


        public System.DateTime FechaCreacion { get; set; }
        public int UsuarioCreadorId { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
        public string Nombreestado { get; set; }
        public string Nombreentidad { get; set; }
    }
}
