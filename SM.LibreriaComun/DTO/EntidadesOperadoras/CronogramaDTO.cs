using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace SM.LibreriaComun.DTO.EntidadesOperadoras
{
    public class CronogramaDTO
    {
        public int Id { get; set; }
        [DisplayName("Nombre *")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DataType(DataType.Text, ErrorMessage = "El  nombre  debe ser tipo texto")]
        [StringLength(200, ErrorMessage = "La longitud del nombre debe ser mínimo de 2 caracteres y máximo de 199", MinimumLength = 2)]
        public string Nombre { get; set; }
        public int ActividadId { get; set; }
        [DisplayName("Departamento *")]
        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string Cod_departamento { get; set; }
        [DisplayName("Municipio *")]
        [Required(ErrorMessage = "El municipio es obligatorio")]
        public string Cod_municipio { get; set; }

        [DisplayName("Fecha Inicio *")]
        [Required(ErrorMessage = "La fecha inicio es obligatoria")]
        public string FechaInicio { get; set; }
        [DisplayName("Fecha Fin *")]
        [Required(ErrorMessage = "La fecha fin es obligatoria")]
        public string FechaFin { get; set; }
        [DisplayName("Cupo *")]
        [Required(ErrorMessage = "El cupo es obligatorio")]
        public string Cupo { get; set; }

        [DisplayName("Escuela *")]
        [Required(ErrorMessage = "La escuela es obligatorio")]
        public string Escuela { get; set; }

        public string TipoActividadID { get; set; }


        public int UsuarioCreadorId { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Nombreactividad { get; set; }

        public string NombreEscuela { get; set; }
        public CronogramaDocumentoModels Documentos { get; set; }
    }

    public class CronogramaDocumentoModels
    {
        [DataType(DataType.Upload)]
        [NotMapped]
        [Display(Name = "Archivo")]
        public HttpPostedFileBase DocumentoEPK { get; set; }
        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoDTO> documentosArchivo { get; set; }
        public int CronogramaDOcumentoId { get; set; }
        public string Tipo { get; set; }
        public int CronogramaId { get; set; }
    }

    public class CronogramaListadoDTO
    {
        public int ID { get; set; }
        public int CronogramaAgenteId { get; set; }
        public string Cronograma { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public decimal? EscuelaId { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Escuela { get; set; }
        public string Actividad { get; set; }
        public string Agente { get; set; }
        public string Convenio { get; set; }
        public int ConvenioId { get; set; }
        public int ActividadId { get; set; }
    }

    public class CronogramaEntidadEscuelaDTO
    {
        public int CronogramaId { get; set; }
        public string Cronograma { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public decimal? EscuelaId { get; set; }
        public string Escuela { get; set; }
        public string Actividad { get; set; }
        public string Agente { get; set; }
        public string Convenio { get; set; }
        public int EntidadId { get; set; }
        public string Entidad { get; set; }
    }

    public class CronogramaReporteConvenioDTO
    {
        public int CronogramaId { get; set; }
        public string Cronograma { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Convenio { get; set; }
        public string Actividad { get; set; }
        public int ActividadId { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public int EntidadId { get; set; }
        public string Entidad { get; set; }
    }
}
