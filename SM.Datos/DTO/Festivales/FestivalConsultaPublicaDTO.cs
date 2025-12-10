using System;
using System.Collections.Generic;

namespace SM.Datos.DTO.Festivales
{
    /// <summary>
    /// DTO para item de catálogo genérico (territorios, tipologías, expresiones)
    /// </summary>
    public class CatalogoItemDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public bool Seleccionado { get; set; }
    }

    /// <summary>
    /// DTO para festival en consulta pública
    /// </summary>
    public class FestivalPublicoDTO
    {
        public int Id { get; set; }
        public int VersionId { get; set; }
        public string Nombre { get; set; }
        public string NombreVersion { get; set; }
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
    /// DTO para filtros de consulta pública
    /// </summary>
    public class ConsultaPublicaFiltrosDTO
    {
        public string MesInicio { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string TipoIngreso { get; set; }
        public string Tipo { get; set; } // Tipología en filtro superior
        public string TextoBusqueda { get; set; }
        public bool SinPublicoPresencial { get; set; }
        public List<int> TerritoriosSeleccionados { get; set; }
        public List<int> TipologiasSeleccionadas { get; set; }
        public List<int> ExpresionesSeleccionadas { get; set; }

        public ConsultaPublicaFiltrosDTO()
        {
            TerritoriosSeleccionados = new List<int>();
            TipologiasSeleccionadas = new List<int>();
            ExpresionesSeleccionadas = new List<int>();
        }
    }
}
