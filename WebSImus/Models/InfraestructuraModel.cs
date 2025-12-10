using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public partial class InfraestructuraModel
    {
        public decimal EscuelaId { get; set; }
        public string NombreEscuela { get; set; }
        [DataType(DataType.Text, ErrorMessage = "La sede debe ser tipo texto")]
        [StringLength(100, ErrorMessage = "La longitud de la sede debe ser mínimo de 4 caracteres y máximo de 100", MinimumLength = 4)]
        public string Sede { get; set; }
        public string Espacio { get; set; }
        public int EsSedeAsignada { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadSillas { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadAtriles { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadTableros { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadEstanterias { get; set; }

        public int EsAdecuadaAcusticamente { get; set; }

        [Range(typeof(int), "0", "100", ErrorMessage = "Ingrese un número de 0  a 100")]
        public string PorcentajeAdecuacion { get; set; }
        public int TieneAccesoInternet { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadCuerdasPulsadas { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadCuerdasSinfonicas { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadVientosMadera { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadVientosMetales { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadPercusionMenor { get; set; }
        public string CantidadPercusionSinfonica { get; set; }
        [Range(typeof(int), "0", "9999", ErrorMessage = "Ingrese un número de 0  a 9999")]
        public string CantidadOtros { get; set; }
        public int TieneMaterialPedagogico { get; set; }
        [Range(typeof(int), "0", "99999", ErrorMessage = "Ingrese un número de 0  a 99999")]
        public string CantidadTitulosBibliograficos { get; set; }
        public int TotalInstrumentos { get; set; }
        //Fuentes de dotación
        public List<EstandarDTO> FuentesDotacionData { get; set; }
        public List<EstandarDTO> FuentesDotacionSeleccionada { get; set; }
        public string[] FuentesDotacionPublicado { get; set; }

        //Soluciones acústicas
        public List<EstandarDTO> TipoSolucionesAcusticasData { get; set; }
        public List<EstandarDTO> TipoSolucionesAcusticasSeleccionada { get; set; }
        public string[] TipoSolucionesAcusticasPublicado { get; set; }

        //Tipos servicios de internet nuevo
        public List<EstandarDTO> TiposInternetData { get; set; }
        public List<EstandarDTO> TiposInternetSeleccionada { get; set; }
        public string[] TipoInternetPublicado { get; set; }

        //Tipos fuentes dotación
        public List<EstandarDTO> TiposFuentesDotacionData { get; set; }
        public List<EstandarDTO> TiposFuentesDotacionSeleccionada { get; set; }
        public string[] TipoFuentesDotacionPublicado { get; set; }

        //Material Pedagogico
        public List<EstandarDTO> MaterialPedagogicoData { get; set; }
        public List<EstandarDTO> MaterialPedagogicoSeleccionada { get; set; }
        public string[] MaterialPedagogicoPublicado { get; set; }

        public string TieneInternet { get; set; }
        public string AdecuacionAcustica { get; set; }
    }
}