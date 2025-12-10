using System;
using System.Collections.Generic;
using System.Web;

namespace WebSImus.Models
{
    // Item mostrado en la grilla de Versiones
    public class FestivalVersionListadoItemViewModel
    {
        public int Id { get; set; }
        public int? NumeroVersion { get; set; } // Número de versión del festival (VERSION_FESTIVAL)
        public string NombreVersion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string Estado { get; set; } // Incompleto, Registrado, Rechazado, Solicitud de Aclaraciones, Publicado
    }

    // Modelo de creación rápida en el modal
    public class FestivalVersionCrearViewModel
    {
        public string NombreVersion { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string Estado { get; set; }
    }

    /// <summary>
    /// ViewModel para el registro completo de una versión de festival (acordeón con múltiples secciones)
    /// </summary>
    public class FestivalVersionRegistroViewModel
    {
        // ID de la versión (para edición)
        public int Id { get; set; }
        
        // Indicador de si es edición o creación
        public bool EsEdicion { get; set; }

        // Sección activa del acordeón (generalidades, territorioSonoro, localizacion, tiempo, caracterizacion, financiacion, contacto)
        public string SeccionActiva { get; set; } = "generalidades";

        // ===== GENERALIDADES =====
        public int? FestivalId { get; set; } // ComboBox: Versión del festival
        public int? VersionNumero { get; set; } // Número de versión
        public string NombreVersion { get; set; }
        public string Descripcion { get; set; }

        // Material multimedia - URLs de archivos existentes
        public string UrlPrograma { get; set; }
        public string UrlAfiche { get; set; }
        public string UrlLogo { get; set; }

        // Archivos subidos (para procesamiento en POST)
        public HttpPostedFileBase ArchivoPrograma { get; set; }
        public HttpPostedFileBase ArchivoAfiche { get; set; }
        public HttpPostedFileBase ArchivoLogo { get; set; }

        // ===== TIPO DE INGRESO =====
    // Lista dinámica de tipos de ingreso cargados desde BD
    public List<TipoIngresoSeleccionItem> TiposIngreso { get; set; } = new List<TipoIngresoSeleccionItem>();

    // ===== TERRITORIOS SONOROS =====
    // Lista dinámica cargada desde la tabla ART_MUS_TERRITORIOS_SONOROS
    public List<TerritorioSonoroSeleccionItem> TerritoriosSonoros { get; set; } = new List<TerritorioSonoroSeleccionItem>();
    // Collección con los IDs seleccionados (se enlaza a los checkboxes en la vista)
    public List<int> TerritoriosSeleccionados { get; set; } = new List<int>();
    // Texto libre cuando el territorio seleccionado es "Ninguna"
    public string PracticasMusicalesTS { get; set; }
        
    // Back-compat: banderas antiguas no usadas pero se preservan para no romper contratos
    public bool TSCantosPitosYTambores { get; set; }
    public bool TSCantaYTorbellino { get; set; }
    public bool TSRaplaYCucamba { get; set; }
    public bool TSMarimarimba { get; set; }
    public bool TSFlautasCuerdasYTamboresSurenos { get; set; }
    public bool TSChirimia { get; set; }
    public bool TSJoropo { get; set; }
    public bool TSTrovaYParranda { get; set; }
    public bool TSAmazonas { get; set; }
    public bool TSInsular { get; set; }
    public bool TSPracticasDePueblosIndigenas { get; set; }
    public bool TSMusicasUrbanasAlternativasEIndependientes { get; set; }
    public bool TSComunidadesAcademicas { get; set; }
    public bool TSRoom { get; set; }
    public bool TSNinguna { get; set; }

        // ===== LOCALIZACIÓN =====
        public List<LocalizacionFestivalItem> Localizaciones { get; set; } = new List<LocalizacionFestivalItem>();
        
        // JSON string para almacenar localizaciones temporales antes de guardar la versión
        public string LocalizacionesTemporalesJson { get; set; }

        // ===== TIEMPO =====
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? MesRealizacion { get; set; } // 1-12 (Enero-Diciembre)
        public int? DuracionDias { get; set; } // Número de días de duración

        // ===== CARACTERIZACIÓN =====
        // Tipología del festival
        public int? IdTipologia { get; set; }
        public string OtraTipologia { get; set; }
        
        // Modalidades de participación - lista dinámica cargada desde BD
        public List<ModalidadParticipacionSeleccionItem> ModalidadesParticipacion { get; set; } = new List<ModalidadParticipacionSeleccionItem>();
        // Collección con los IDs seleccionados
        public List<int> ModalidadesSeleccionadas { get; set; } = new List<int>();
        public string OtraModalidadParticipacion { get; set; }
        
        // Expresiones artísticas - lista dinámica cargada desde BD
        public List<ExpresionArtisticaSeleccionItem> ExpresionesArtisticas { get; set; } = new List<ExpresionArtisticaSeleccionItem>();
        // Collección con los IDs seleccionados
        public List<int> ExpresionesSeleccionadas { get; set; } = new List<int>();
        public string OtraExpresionArtistica { get; set; }

        // ===== FINANCIACIÓN =====
        // IDs de fuentes de financiación seleccionadas desde los combos
        public int? FuenteFinanciacionPrincipal { get; set; }
        public int? FuenteFinanciacionSecundaria { get; set; }
        // Textos libres que se habilitan cuando se selecciona "Otra" en los combos
        public string OtraFuenteFinanciacionPrimaria { get; set; }
        public string OtraFuenteFinanciacionSecundaria { get; set; }
        // Uso de estampilla Procultura (Sí/No)
        public bool? UsaEstampillaProcultura { get; set; }

        // ===== CONTACTO =====
        public string Directoria { get; set; }
        public bool? PerteneceOrganizacion { get; set; } // Sí/No
        public string NombreOrganizacion { get; set; }
        public string TipoOrganizador { get; set; } // Público, Privado, Mixto, Otro
        public string OtroTipoOrganizador { get; set; }
        public string CorreoContacto { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string PaginaWeb { get; set; }
        public string OtroEnlace { get; set; }
        public string TelefonoCelular { get; set; }
        public bool? TieneEntidadesAliadas { get; set; } // Sí/No
        public string ObservacionesContacto { get; set; }
        
        // Lista de entidades aliadas
        public List<EntidadAliadaItem> EntidadesAliadas { get; set; } = new List<EntidadAliadaItem>();
    }

    /// <summary>
    /// Item seleccionable para tipos de ingreso
    /// </summary>
    public class TipoIngresoSeleccionItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Selected { get; set; }
    }

    /// <summary>
    /// Item seleccionable para Territorios Sonoros
    /// </summary>
    public class TerritorioSonoroSeleccionItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Selected { get; set; }
        // Indica si este item representa la opción "Ninguna"
        public bool EsNinguna { get; set; }
    }

    /// <summary>
    /// Item de localización de un festival
    /// </summary>
    public class LocalizacionFestivalItem
    {
        public int Id { get; set; }
        public string Departamento { get; set; }
        public string DepartamentoNombre { get; set; }
        public string Municipio { get; set; }
        public string MunicipioNombre { get; set; }
        public string Zona { get; set; }
        public string TitulacionColectiva { get; set; }
        public string ZonaTitulacionColectiva { get; set; }
        
        // Región OCAD (checkboxes)
        public bool RegionCaribe { get; set; }
        public bool RegionCentroOriente { get; set; }
        public bool RegionCentroSur { get; set; }
        public bool RegionEjeCafetero { get; set; }
        public bool RegionLlanos { get; set; }
        public bool RegionPacifico { get; set; }
    }

    /// <summary>
    /// Item de entidad aliada
    /// </summary>
    public class EntidadAliadaItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Naturaleza { get; set; } // Público, Privado, Mixto
        public string CorreoElectronico { get; set; }
    }

    /// <summary>
    /// Item para el listado de versiones en la grilla principal
    /// </summary>
    public class FestivalVersionListadoViewModel
    {
        public int Id { get; set; }
        public string NombreFestival { get; set; }
        public string NombreVersion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public DateTime? FechaSolicitudAclaraciones { get; set; }
        public DateTime? FechaReciboAclaraciones { get; set; }
        public string Estado { get; set; } // Incompleto, Registrado, Solicitud de Aclaraciones, Rechazado, Publicado
    }

    /// <summary>
    /// Item seleccionable para modalidades de participación
    /// </summary>
    public class ModalidadParticipacionSeleccionItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Selected { get; set; }
    }

    /// <summary>
    /// Item seleccionable para expresiones artísticas
    /// </summary>
    public class ExpresionArtisticaSeleccionItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Selected { get; set; }
    }

    /// <summary>
    /// ViewModel para la página de listado de versiones
    /// </summary>
    public class VersionesListadoPaginaViewModel
    {
        public string FiltroTexto { get; set; }
        public List<FestivalVersionListadoViewModel> Versiones { get; set; } = new List<FestivalVersionListadoViewModel>();
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
    }

    /// <summary>
    /// ViewModel para la página de festivales pendientes de aprobación (solo visible para rol = 1)
    /// </summary>
    public class FestivalesAprobacionViewModel
    {
        public string FiltroTexto { get; set; }
        public List<FestivalAprobacionItemViewModel> Festivales { get; set; } = new List<FestivalAprobacionItemViewModel>();
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
    }

    /// <summary>
    /// Item mostrado en la grilla de festivales pendientes de aprobación
    /// </summary>
    public class FestivalAprobacionItemViewModel
    {
        public int FestivalId { get; set; }
        public int VersionId { get; set; }
        public string NombreFestival { get; set; }
        public string NombreVersion { get; set; }
        public int? NumeroVersion { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Director { get; set; }
        public string CorreoContacto { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string Estado { get; set; }
        public string NombreUsuarioRegistro { get; set; }
    }
}
