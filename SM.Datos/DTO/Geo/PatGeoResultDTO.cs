using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO.Geo
{
    public class PatGeoResultDTO
    {

        public decimal INB_ID { get; set; }
        public Nullable<decimal> USO_ID { get; set; }
        public string CodMunicipio { get; set; }
        public string INB_DIRECCION_DELIMITACION { get; set; }
        public string INB_NOMBRE_BIEN { get; set; }
        public string INB_OTROS_NOMBRES { get; set; }
        public string INB_URL_FOTOGRAFIA_BIEN { get; set; }
        public Nullable<decimal> INR_ID { get; set; }
        public Nullable<decimal> VCM_ID { get; set; }
        public Nullable<decimal> TIS_ID { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string CLT_NOMBRE { get; set; }
        public decimal CLT_ID { get; set; }
        public string CodigoDepartamento { get; set; }
        public Nullable<double> INB_LONGITUD { get; set; }
        public Nullable<double> INB_LATITUD { get; set; }
        public string INB_CODIGO_BIEN { get; set; }
        public Nullable<int> CLT_NIVEL { get; set; }
        public string CLT_NOMBRE_NIVEL { get; set; }
        public string USO_NOMBRE { get; set; }
        public Nullable<decimal> DDI_ID { get; set; }
        public Nullable<decimal> AMD_ID { get; set; }
        public string DDI_URL_IMAGEN_DECLARATORIA { get; set; }
        public string AMD_NOMBRE { get; set; }
        public string Modelo { get; set; }
        public string Ver_Mas { get; set; }
        public string Resolucion { get; set; }
    }
}
