using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
    public class ReporteGeneralBasico
    {
        public string CODIGOMUNICIPIO { get; set; }
        public string CODIGODEPARTAMENTO { get; set; }
        public decimal ENT_ID { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string MUNICIPIO { get; set; }
        public string ESTADO { get; set; }
        public string NOMBRE_ESCUELA { get; set; }
        public string DIRECCIÓN_ESCUELA { get; set; }
        public string TELÉFONO_ESCUELA { get; set; }
        public string FAX_ESCUELA { get; set; }
        public string CORREO_ELECTRÓNICO_ESCUELA { get; set; }
        public string NOMBRE_CONTACTO { get; set; }
        public string TELÉFONO_CONTACTO { get; set; }
        public string CORREO_ELECTRÓNICO_CONTACTO { get; set; }
        public string NOMBRE_DIRECTOR { get; set; }
        public string TELÉFONO_DIRECTOR { get; set; }
        public string CATEGORÍA { get; set; }
        public Nullable<decimal> PORCENTAJE { get; set; }
        public Nullable<System.DateTime> FECHA_ACTUALIZACIÓN { get; set; }
        public Nullable<System.DateTime> FECHA_CATEGORIZACIÓN { get; set; }
        public string NOMBRE_CREADOR { get; set; }
        public string NOMBRE_USUARIO_CREADOR { get; set; }
        public string CORREO_ELECTRONICO_CREADOR { get; set; }
        public string TipoEscuela { get; set; }
    }
}
