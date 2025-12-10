using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.GEO
{
    public class AgentesGeoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Pais { get; set; }
        public string Cod_Municipio { get; set; }
        public string Cod_Departamento { get; set; }
        public string Cod_Pais { get; set; }
        public string PaginaWeb { get; set; }
        public string UrlFacebook { get; set; }
        public string UrlTwitter { get; set; }
        public string UrlYoutube { get; set; }
        public string UrlSoundCloud { get; set; }
        public string UrlFlickr { get; set; }
        public string Ver_Mas { get; set; }
        public Geometry geometry { get; set; }
    }

    public class EntidadesGeoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public string Naturaleza { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Pais { get; set; }
        public string Cod_Municipio { get; set; }
        public string Cod_Departamento { get; set; }
        public string Cod_Pais { get; set; }
        public string PaginaWeb { get; set; }
        public string UrlFacebook { get; set; }
        public string UrlTwitter { get; set; }
        public string UrlYoutube { get; set; }
        public string UrlSoundCloud { get; set; }
        public string UrlFlickr { get; set; }
        public string Ver_Mas { get; set; }
        public Geometry geometry { get; set; }
    }

    public class AgentesDptoDTO
    {
        public string Cod_Departamento { get; set; }
        public string Departamento { get; set; }
        public int Cantidad { get; set; }
        public int PorcentajeAvance { get; set; }

    }

    public class AgenteMunicipioDTO
    {
        public string CodDepartamento { get; set; }
        public string CodMunicipio { get; set; }
        public string Municipio { get; set; }
        public int cantidad { get; set; }


    }

}
