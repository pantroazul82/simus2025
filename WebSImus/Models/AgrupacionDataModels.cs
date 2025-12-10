using SM.LibreriaComun.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class AgrupacionDataModels
    {
        public int AgrupacionId { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoPais { get; set; }
        public string Telefono { get; set; }
        public int TipoAgrupacionId { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public string FechaActualizacion { get; set; }
        public string FechaCreacion { get; set; }
        public byte[] Imagen { get; set; }
        public string LinkPortafolio { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string CODIGO { get; set; }
        public string DOC_NOMBRE { get; set; }
        public string Identificacion { get; set; }
        public string NombreDirector { get; set; }
        public string ApellidoDirector { get; set; }
        public string TipoAgrupacion { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string youtube { get; set; }
        public string soundcloud { get; set; }

        public int documentoId { get; set; }
        public List<AgentePublicoModels> listAgentes { get; set; }
        public List<EstandarDTO> listgeneros { get; set; }
    }
}