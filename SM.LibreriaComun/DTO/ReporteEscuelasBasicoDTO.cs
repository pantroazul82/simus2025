using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class ReporteEscuelasBasicoDTO
    {
        public string CODIGODEPARTAMENTO { get; set; }
        public string CODIGOMUNICIPIO { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string MUNICIPIO { get; set; }
        public string ESTADO { get; set; }
        public string ENT_ID { get; set; }
        public string NOMBRE_ESCUELA { get; set; }
        public string DIRECCION_ESCUELA { get; set; }
        public string TELEFONO_ESCUELA { get; set; }
        public string FAX_ESCUELA { get; set; }
        public string CORREO_ELECTRONICO_ESCUELA { get; set; }
        public string NOMBRE_CONTACTO { get; set; }
        public string TELEFONO_CONTACTO { get; set; }
        public string CORREO_ELECTRONICO_CONTACTO { get; set; }
        public string NOMBRE_DIRECTOR { get; set; }
        public string TELEFONO_DIRECTOR { get; set; }
        public string CATEGORIA { get; set; }
        public string PORCENTAJE { get; set; }
        public DateTime FECHA_ACTUALIZACION { get; set; }
        public Nullable<System.DateTime> FECHA_CATEGORIZACIÓN { get; set; }
        public string NOMBRE_CREADOR { get; set; }
        public string NOMBRE_USUARIO_CREADOR { get; set; }
        public string CORREO_ELECTRONICO_CREADOR { get; set; }

        public string TIPO_ESCUELA { get; set; }
    }
}
