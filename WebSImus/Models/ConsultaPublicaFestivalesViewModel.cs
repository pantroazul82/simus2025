using System;
using System.Collections.Generic;

namespace WebSImus.Models
{
    /// <summary>
    /// ViewModel para la página pública de consulta de festivales
    /// </summary>
    public class ConsultaPublicaFestivalesViewModel
    {
        public ConsultaPublicaFestivalesViewModel()
        {
            Festivales = new List<FestivalPublicoDTO>();
            TerritoriosSonoros = new List<CatalogoItemDTO>();
            Tipologias = new List<CatalogoItemDTO>();
            TiposExpresion = new List<CatalogoItemDTO>();
            Departamentos = new List<CatalogoItemDTO>();
            TiposIngreso = new List<CatalogoItemDTO>();
        }

        /// <summary>
        /// Lista de festivales que cumplen con los criterios de búsqueda
        /// </summary>
        public List<FestivalPublicoDTO> Festivales { get; set; }

        /// <summary>
        /// Catálogo de territorios sonoros para filtrado
        /// </summary>
        public List<CatalogoItemDTO> TerritoriosSonoros { get; set; }

        /// <summary>
        /// Catálogo de tipologías para filtrado
        /// </summary>
        public List<CatalogoItemDTO> Tipologias { get; set; }

        /// <summary>
        /// Catálogo de tipos de expresión para filtrado
        /// </summary>
        public List<CatalogoItemDTO> TiposExpresion { get; set; }

        /// <summary>
        /// Catálogo de departamentos
        /// </summary>
        public List<CatalogoItemDTO> Departamentos { get; set; }

        /// <summary>
        /// Catálogo de tipos de ingreso
        /// </summary>
        public List<CatalogoItemDTO> TiposIngreso { get; set; }

        // Filtros de búsqueda
        public bool BuscarPorMes { get; set; }
        public bool BuscarPorFecha { get; set; }
        public string MesInicio { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string TipoIngreso { get; set; }
        public string Tipo { get; set; } // Tipología seleccionada en filtro superior
        public string TextoBusqueda { get; set; }
        public bool SinPublicoPresencial { get; set; }
        public List<int> TerritoriosSeleccionados { get; set; }
        public List<int> TipologiasSeleccionadas { get; set; }
        public List<int> ExpresionesSeleccionadas { get; set; }
    }

    /// <summary>
    /// DTO simplificado para mostrar festivales en la consulta pública
    /// </summary>
    public class FestivalPublicoDTO
    {
        public int Id { get; set; }
        public int VersionId { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Ubicacion { get; set; }
        public string ImagenUrl { get; set; }
        public string Descripcion { get; set; }
        public string TipoIngreso { get; set; }
        public bool SinPublicoPresencial { get; set; }
        public int? VersionNumero { get; set; }
    }

    /// <summary>
    /// DTO genérico para items de catálogo
    /// </summary>
    public class CatalogoItemDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public bool Seleccionado { get; set; }
    }
}
