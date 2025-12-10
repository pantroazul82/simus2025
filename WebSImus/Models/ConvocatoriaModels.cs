using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class ConvocatoriaModels
    {
        public int ConvocatoriaId { get; set; }
        [Required(ErrorMessage = "El nombre de la convocatoria es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El  nombre  debe ser tipo texto")]
        [StringLength(1000, ErrorMessage = "La longitud del nombre debe ser mínimo de 2 caracteres y máximo de 200", MinimumLength = 2)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        public string NombreEstado { get; set; }
        public string EstadoId { get; set; }
        public int ArtMusicaUsuarioId { get; set; }
        [Required(ErrorMessage = "La fecha inicio es obligatoria")]
        public string FechaInicio { get; set; }
        [Required(ErrorMessage = "La fecha final es obligatoria")]
        public string FechaFin { get; set; }
        [Required(ErrorMessage = "El tipo es obligatoria")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "El actor es obligatoria")]
        public string TipoActor { get; set; }
        public string RelacionadoA { get; set; }
        public int DocumentoId { get; set; }

        [DataType(DataType.Upload)]
        [NotMapped]
        [Display(Name = "Archivo")]
        public HttpPostedFileBase Documento { get; set; }
        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoModels> documentoArchivo { get; set; }
        public List<EstandarDTO> DirigidoAData { get; set; }
        public List<EstandarDTO> DirigidoASeleccionada { get; set; }
        public string[] DirigidoAPublicado { get; set; }

    }

    public class ConvocatoriaDetalleModels
    {
        public int documentoId { get; set; }
        public int ConvocatoriaId { get; set; }
        [Required(ErrorMessage = "El nombre de la convocatoria es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El  nombre  debe ser tipo texto")]
        [StringLength(1000, ErrorMessage = "La longitud del nombre debe ser mínimo de 2 caracteres y máximo de 200", MinimumLength = 2)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        public string NombreEstado { get; set; }
        public string EstadoId { get; set; }
     
        [Required(ErrorMessage = "La fecha inicio es obligatoria")]
        public string FechaInicio { get; set; }
        [Required(ErrorMessage = "La fecha final es obligatoria")]
        public string FechaFin { get; set; }
        [Required(ErrorMessage = "El tipo es obligatoria")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "El actor es obligatoria")]
        public string TipoActor { get; set; }
        public string RelacionadoA { get; set; }
        public int DocumentoId { get; set; }

        public bool EsDotacion { get; set; }
        public string NombreTipo { get; set; }
        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoModels> documentoArchivo { get; set; }
     
        public List<EstandarDTO> DirigidoASeleccionada { get; set; }
        public List<EstandarDTO> ListadoMunicipiosDotacion { get; set; }
        public List<EstandarDTO> listadoEntidadesActualizado { get; set; }

    }

    public class ParicipacionModels
    {
        public int ConvocatoriaId { get; set; }
        public string Tipo { get; set; }

        public string TipoActor { get; set; }
        public string Descripcion { get; set; }
    }
}