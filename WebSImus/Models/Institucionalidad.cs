using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSImus.Models
{
    public partial class Institucionalidad
    {

        #region Institucionalidad
        public decimal EscuelaId { get; set; }
        public string NombreEscuela { get; set; }
        public int UsuarioId { get; set; }
        public int CreadaLegalmente { get; set; }
        //public int PlanDesarrollo { get; set; }
        public string Regimen { get; set; }
        public string SubRegimen { get; set; }

        public string TipoDocumentoCreacion { get; set; }
        public string FechaDocumentoCreacion { get; set; }
        public string NumeroDocumentoCreacion { get; set; }
        [DataType(DataType.Upload)]
        [NotMapped]
       [Display(Name = "Archivo")]
        public HttpPostedFileBase DocumentoCreacion { get; set; }

        [NotMapped]
        [Display(Name = "Descargar archivos:")]
        public List<DocumentoModels> documentoArchivo { get; set; }
        public int DocumentoId { get; set; }
        public string Naturaleza { get; set; }
        public int DependeInstitucion { get; set; }
        [StringLength(100, ErrorMessage = "La longitud del nombre de la entidad debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        public string NombreEntidad { get; set; }
        public string NivelEntidad { get; set; }
        public string OperaEntidad { get; set; }
        [StringLength(100, ErrorMessage = "La longitud del nombre del director debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        [Required(ErrorMessage = "El nombre del director es obligatorio")]
        public string NombreDirector { get; set; }
        public string FechaNacimiento { get; set; }
        [StringLength(100, ErrorMessage = "La longitud del teléfono celular debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        [Required(ErrorMessage = "El teléfono celular del director es obligatorio")]
        public string TelefonoCelularDirector { get; set; }
        [StringLength(100, ErrorMessage = "La longitud del correo electrónico del director debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        [EmailAddress(ErrorMessage = "Correo electrónico es invalido.")]
        [Required(ErrorMessage = "El correo electrónico del director es obligatorio")]
        public string CorreoElectronicoDirector { get; set; }
       
        public string TipoVinculacionDirector { get; set; }
        [StringLength(100, ErrorMessage = "La longitud de la entidad contratante del director debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        public string EntidadContratanteDirector { get; set; }
        public int FormacionMusical { get; set; }
        public int PracticaMusical { get; set; }

        #region InformacionDocentes
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string Voluntarios { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string ContratoLaboral { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string ContratoHonorario { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string OrdenPrestacionServicios { get; set; }
        #endregion

        #region NivelEducativo
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string Primaria { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string Secundaria { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string Tecnico { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string UniversitariaSinTitulo { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string PregradoMusica { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string PregradoOtrasAreas { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string PostGrado { get; set; }
        #endregion

        #region ApoyoAdministrativo
        public int ApoyoAdministrativo { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string VoluntariosAdministrativo { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string ContratoLaboralAdministrativo { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string ContratoHonorariosAdministrativo { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string OrdenPrestacionServiciosAdministrativo { get; set; }
        #endregion
        public int ActividadMusical { get; set; }
        public int TotalDocentesNivelEducativo { get; set; }
        public int TotalDocentesVinculados { get; set; }

        public List<PracticaMusicales> PracticaMusicalData { get; set; }
        public List<PracticaMusicales> PracticaMusicalSeleccionada { get; set; }
        public PublicadoPracticaMusical Publicado { get; set; }

        //
        public List<PracticaMusicales> PracticaMusicalPNMCData { get; set; }
        public List<PracticaMusicales> PracticaMusicalPNMCSeleccionada { get; set; }
        public PublicadoPracticaMusical PublicadoPNMC { get; set; }

        #endregion
    }
}