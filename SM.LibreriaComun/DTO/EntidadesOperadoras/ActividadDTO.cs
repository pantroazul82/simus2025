using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace SM.LibreriaComun.DTO.EntidadesOperadoras
{
    public class ActividadDTO
    {

        public int Id { get; set; }
        [DisplayName("Nombre *")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El  nombre  debe ser tipo texto")]
        [StringLength(200, ErrorMessage = "La longitud del nombre debe ser mínimo de 2 caracteres y máximo de 199", MinimumLength = 2)]
        public string Nombre { get; set; }
        [DisplayName("Descripción *")]
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        [DisplayName("Tipo actividad*")]
        [Required(ErrorMessage = "El tipo de actividad es obligatorio")]
        public string TipoActividadId { get; set; }
        public int ConvenioId { get; set; }
        [DisplayName("Valor programado *")]
        [Required(ErrorMessage = "El valor programado es obligatorio")]
        public string ValorProgramado { get; set; }
        [DisplayName("Valor ejecutado *")]
        [Required(ErrorMessage = "El valor ejecutado es obligatorio")]
        public string ValorEjecutado { get; set; }
        [DisplayName("Mínimo de días *")]
        public string NumeroDias { get; set; }
        [DisplayName("Estado *")]
        [Required(ErrorMessage = "El estado es obligatorio")]
        public string EstadoId { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int UsuarioCreadorId { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }

        public string NombreTipoActividad { get; set; }
        public string NombreEntidad { get; set; }
        public string NumeroConvenio { get; set; }


        [DataType(DataType.Upload)]
        [NotMapped]
        [Display(Name = "Archivo")]
        public HttpPostedFileBase DocumentoEPK { get; set; }
        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoDTO> documentoArchivo { get; set; }
        public int DocumentoId { get; set; }
    }
}
