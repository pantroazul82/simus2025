using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.GEO
{
    public class EscuelaGeoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Cod_Municipio { get; set; }
        public string Cod_Departamento { get; set; }
        public string Naturaleza { get; set; }
        public string TipoEscuela { get; set; }
        public int TipoEscuelaId { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string PaginaWeb { get; set; }
        public string UrlFacebook { get; set; }
        public string UrlTwitter { get; set; }
        public string UrlYoutube { get; set; }
        public string CorreoElectronico { get; set; }
        public string Ver_Mas { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Geometry
    {
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Distancia { get; set; }
    }

    public class EscuelaDepartamentoDTO
    {
        public string Cod_Departamento { get; set; }
        public string Departamento { get; set; }
        public int CantidadMunicipiosEscuelas { get; set; }
        public int CantidadTotalMunicipios { get; set; }
        public int porcentajeAvance { get; set; }

        public IEnumerable<EscuelaMunicipioDTO> Municipios { get; set; }
    }

    public class EscuelaMunicipioDTO
    {
        public string Cod_Departamento { get; set; }
        public string Cod_Municipio { get; set; }
        public string Municipio { get; set; }
        public int Cantidad { get; set; }
        public int Cantidad_Mixta { get; set; }
        public int Cantidad_Privada { get; set; }
        public int Cantidad_Publica { get; set; }

    }
}
