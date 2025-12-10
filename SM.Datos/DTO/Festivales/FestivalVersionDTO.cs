using System;
using System.Collections.Generic;

namespace SM.Datos.DTO.Festivales
{
    /// <summary>
    /// DTO para transferencia de datos de una versión de festival
    /// </summary>
    public class FestivalVersionDTO
    {
        public int Id { get; set; }
        public int IdFestival { get; set; }
        public string NombreFestival { get; set; }
        public int? NumeroVersion { get; set; }
        public string NombreVersion { get; set; }
        public string Descripcion { get; set; }
        public string PracticasMusicales { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public List<TipoIngresoDTO> TiposIngreso { get; set; }
        public List<MaterialMultimediaDTO> MaterialMultimedia { get; set; }
        
        // Caracterización
        public int? IdTipologia { get; set; }
        public string OtraTipologia { get; set; }
        public List<ModalidadParticipacionDTO> ModalidadesParticipacion { get; set; }
        public string OtraModalidadParticipacion { get; set; }
        public List<ExpresionArtisticaDTO> ExpresionesArtisticas { get; set; }
        public string OtraExpresionArtistica { get; set; }

        // Financiación
        public int? IdFuenteFinanciacion { get; set; }
        public int? IdFuenteFinanciacionSecundaria { get; set; }
        public string OtraFuenteFinanciacionPrimaria { get; set; }
        public string OtraFuenteFinanciacionSecundaria { get; set; }
        public bool? UsoEstampillaProcultura { get; set; }

        // Contacto
        public string Director { get; set; }
        public bool? PerteneceOrgColectiva { get; set; }
        public string NombreOrganizacion { get; set; }
        public int? IdTipoOrganizador { get; set; }
        public string OtroTipoOrganizador { get; set; }
        public string CorreoContacto { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string PaginaWeb { get; set; }
        public string OtroEnlace { get; set; }
        public string TelefonoCelular { get; set; }
        public string ObservacionesContacto { get; set; }

        public FestivalVersionDTO()
        {
            TiposIngreso = new List<TipoIngresoDTO>();
            MaterialMultimedia = new List<MaterialMultimediaDTO>();
            ModalidadesParticipacion = new List<ModalidadParticipacionDTO>();
            ExpresionesArtisticas = new List<ExpresionArtisticaDTO>();
        }
    }

    /// <summary>
    /// DTO para crear una nueva versión de festival
    /// </summary>
    public class FestivalVersionCrearDTO
    {
        public int IdFestival { get; set; }
        public int? NumeroVersion { get; set; }
        public string NombreVersion { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public List<int> TiposIngreso { get; set; }
        public List<MaterialMultimediaCrearDTO> MaterialMultimedia { get; set; }
        
        // Caracterización
        public int? IdTipologia { get; set; }
        public string OtraTipologia { get; set; }
        public List<int> ModalidadesParticipacion { get; set; }
        public string OtraModalidadParticipacion { get; set; }
        public List<int> ExpresionesArtisticas { get; set; }
        public string OtraExpresionArtistica { get; set; }

        // Financiación
        public int? IdFuenteFinanciacion { get; set; }
        public int? IdFuenteFinanciacionSecundaria { get; set; }
        public string OtraFuenteFinanciacionPrimaria { get; set; }
        public string OtraFuenteFinanciacionSecundaria { get; set; }
        public bool? UsoEstampillaProcultura { get; set; }

        // Contacto
        public string Director { get; set; }
        public bool? PerteneceOrgColectiva { get; set; }
        public string NombreOrganizacion { get; set; }
        public int? IdTipoOrganizador { get; set; }
        public string OtroTipoOrganizador { get; set; }
        public string CorreoContacto { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string PaginaWeb { get; set; }
        public string OtroEnlace { get; set; }
        public string TelefonoCelular { get; set; }
        public string ObservacionesContacto { get; set; }

        // Estado de la versión
        public int? IdEstado { get; set; }

        public FestivalVersionCrearDTO()
        {
            TiposIngreso = new List<int>();
            MaterialMultimedia = new List<MaterialMultimediaCrearDTO>();
            ModalidadesParticipacion = new List<int>();
            ExpresionesArtisticas = new List<int>();
        }
    }

    /// <summary>
    /// DTO para actualizar una versión de festival existente
    /// </summary>
    public class FestivalVersionActualizarDTO
    {
        public int Id { get; set; }
        public int? NumeroVersion { get; set; }
        public string NombreVersion { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public List<int> TiposIngreso { get; set; }
        public List<MaterialMultimediaCrearDTO> MaterialMultimedia { get; set; }
        
        // Caracterización
        public int? IdTipologia { get; set; }
        public string OtraTipologia { get; set; }
        public List<int> ModalidadesParticipacion { get; set; }
        public string OtraModalidadParticipacion { get; set; }
        public List<int> ExpresionesArtisticas { get; set; }
        public string OtraExpresionArtistica { get; set; }

        // Financiación
        public int? IdFuenteFinanciacion { get; set; }
        public int? IdFuenteFinanciacionSecundaria { get; set; }
        public string OtraFuenteFinanciacionPrimaria { get; set; }
        public string OtraFuenteFinanciacionSecundaria { get; set; }
        public bool? UsoEstampillaProcultura { get; set; }

        // Contacto
        public string Director { get; set; }
        public bool? PerteneceOrgColectiva { get; set; }
        public string NombreOrganizacion { get; set; }
        public int? IdTipoOrganizador { get; set; }
        public string OtroTipoOrganizador { get; set; }
        public string CorreoContacto { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string PaginaWeb { get; set; }
        public string OtroEnlace { get; set; }
        public string TelefonoCelular { get; set; }
        public string ObservacionesContacto { get; set; }

        // Estado de la versión
        public int? IdEstado { get; set; }

        public FestivalVersionActualizarDTO()
        {
            TiposIngreso = new List<int>();
            MaterialMultimedia = new List<MaterialMultimediaCrearDTO>();
            ModalidadesParticipacion = new List<int>();
            ExpresionesArtisticas = new List<int>();
        }
    }

    /// <summary>
    /// DTO para tipo de ingreso
    /// </summary>
    public class TipoIngresoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    /// <summary>
    /// DTO para territorio sonoro
    /// </summary>
    public class TerritorioSonoroDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    /// <summary>
    /// DTO para material multimedia
    /// </summary>
    public class MaterialMultimediaDTO
    {
        public int Id { get; set; }
        public string UrlArchivo { get; set; }
        public string Descripcion { get; set; }
    }

    /// <summary>
    /// DTO para crear material multimedia
    /// </summary>
    public class MaterialMultimediaCrearDTO
    {
        public string UrlArchivo { get; set; }
        public string Descripcion { get; set; }
    }

    /// <summary>
    /// DTO para tipología de festival
    /// </summary>
    public class TipologiaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    /// <summary>
    /// DTO para modalidad de participación
    /// </summary>
    public class ModalidadParticipacionDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    /// <summary>
    /// DTO para expresión artística
    /// </summary>
    public class ExpresionArtisticaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    /// <summary>
    /// DTO para fuente de financiación
    /// </summary>
    public class FuenteFinanciacionDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
