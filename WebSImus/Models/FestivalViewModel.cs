using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class FestivalViewModel
    {
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public DateTime Fecha { get; set; }
        public string GeneroMusical { get; set; }
        public bool EsGratis { get; set; }
        public string ImagenUrl { get; set; }

    }

    public class BusquedaFestivalesViewModel
    {
        public string TextoBusqueda { get; set; }
        public bool? SoloGratis { get; set; }
        public string GeneroSeleccionado { get; set; }
        public string DepartamentoSeleccionado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public List<FestivalViewModel> Resultados { get; set; }
    }

    // ViewModel para la página administrativa/listado (imagen proporcionada)
    public class FestivalListadoItemViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaSolicitudAclaraciones { get; set; }
        public DateTime? FechaReciboAclaraciones { get; set; }
        public string Estado { get; set; }
    }

    public class FestivalListadoViewModel
    {
        public string FiltroTexto { get; set; }
        public List<FestivalListadoItemViewModel> Festivales { get; set; }
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
    }

    // ViewModel para ver/editar un festival completo
    public class FestivalDetalleViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? VersionesRealizadas { get; set; }
        public DateTime? FechaUltimaVersion { get; set; }
        public string Descripcion { get; set; }
        public string CorreoContacto { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string PaginaWeb { get; set; }
        public string OtroEnlace { get; set; }
        public string Celular { get; set; }
        public string ObservacionesContacto { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public string Estado { get; set; }
        public bool SoloLectura { get; set; }
    }

    // ViewModel para la grilla de localizaciones
    public class LocalizacionGridViewModel
    {
        public int Id { get; set; }
        public string DepartamentoNombre { get; set; }
        public string MunicipioNombre { get; set; }
        public string ZonaNombre { get; set; }
        public string ZonaTitulacionNombre { get; set; }
    }
}