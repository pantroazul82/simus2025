using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.GEO
{
    public class PatGeoDTO
    {
        public string Nombre_Bien { get; set; }
        public string Otros_Nombres { get; set; }
        public string CODIGO_BIEN { get; set; }
        public string AMD_NOMBRE { get; set; }
        public string Resolucion { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Direccion { get; set; }
        public string CLT_NOMBRE { get; set; }
        public string USO_NOMBRE { get; set; }
        public string NOMBRE_NIVEL { get; set; }
        public string URL_FOTOGRAFIA_BIEN { get; set; }
        public string URL_IMAGEN_DECLARATORIA { get; set; }
        public string Ver_Mas { get; set; }
        public string Modelo { get; set; }
        public Geometry geometry { get; set; }
        public decimal INB_ID { get; set; }
        public decimal USO_ID { get; set; }
        public string Dane { get; set; }
        public decimal INR_ID { get; set; }
        public decimal VCM_ID { get; set; }
        public decimal TIS_ID { get; set; }
        public decimal CLT_ID { get; set; }
        public string CodigoDepartamento { get; set; }
        public int NIVELID { get; set; }
        public decimal DDI_ID { get; set; }
        public decimal AMD_ID { get; set; }
    }

}
