using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO.Geo
{
   public class EscuelasGeoResultadoDto
    {
       public decimal ENT_ID { get; set; }
        public string Nombre { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Municipio { get; set; }
        public Nullable<double> LatitudMunicipio { get; set; }
        public Nullable<double> LongitudMunicipio { get; set; }
        public string CodigoDepartamento { get; set; }
        public string Departamento { get; set; }
        public string UrlYoutube { get; set; }
        public string Direccion { get; set; }
        public string PaginaWeb { get; set; }
        public Nullable<double> Latitud { get; set; }
        public Nullable<double> Longitud { get; set; }
        public string Telefono { get; set; }
        public string UrlFacebook { get; set; }
        public string UrlTwitter { get; set; }
        public string CorreoElectronico { get; set; }
        public string Naturaleza { get; set; }
        public string TipoEscuela { get; set; }
        public int TipoEscuelaId { get; set; }
     
    }

   public class MunicipioEscuelaResultadoDTO
   {
       public string CodDepartamento { get; set; }
       public string CodMunicipio { get; set; }
       public string Municipio { get; set; }
       public int Cantidad { get; set; }
       public int Cantidad_Mixta { get; set; }
       public int Cantidad_Publica { get; set; }
       public int Cantidad_Privada { get; set; }

   }


}
