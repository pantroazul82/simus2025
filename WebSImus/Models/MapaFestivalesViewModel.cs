using System;
using System.Collections.Generic;

namespace WebSImus.Models
{
    // ViewModel principal para la página del mapa de festivales
    public class MapaFestivalesViewModel
    {
        public string Titulo { get; set; } = "Mapa de festivales";
        public List<FestivalMapaDTO> Festivales { get; set; }
        public List<EstadisticaGraficaDTO> FestivalesPorCiudad { get; set; }
        public List<EstadisticaGraficaDTO> TerritoriosSonoros { get; set; }
        public List<EstadisticaGraficaDTO> FestivalesPorTipo { get; set; }
        public List<EstadisticaGraficaDTO> FestivalesPorExpresionMusical { get; set; }

        public MapaFestivalesViewModel()
        {
            Festivales = new List<FestivalMapaDTO>();
            FestivalesPorCiudad = new List<EstadisticaGraficaDTO>();
            TerritoriosSonoros = new List<EstadisticaGraficaDTO>();
            FestivalesPorTipo = new List<EstadisticaGraficaDTO>();
            FestivalesPorExpresionMusical = new List<EstadisticaGraficaDTO>();
        }
    }

    // DTO para ubicación de festivales en el mapa
    public class FestivalMapaDTO
    {
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int CantidadVersiones { get; set; }
    }

    // DTO para las estadísticas de las gráficas
    public class EstadisticaGraficaDTO
    {
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
    }
}
