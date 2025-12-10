using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class InstitucionalidadDTO
    {
        public decimal ENT_ID { get; set; }
        public bool ENT_CREADA_LEGALMENTE { get; set; }
        public bool? ENT_PLAN_DESARROLLO { get; set; }
        public bool ENT_TIENE_DIRECTOR { get; set; }
        public string ENT_NOMBRES_DIRECTOR { get; set; }
        public  Nullable<System.DateTime>  ENT_FECHA_NACIMIENTO_DIRECTOR { get; set; }
        public string ENT_CELULAR_DIRECTOR { get; set; }
        public string ENT_CORREO_ELECTRONICO_DIRECTOR { get; set; }
        public  short  ENT_TIPO_VINCULACION_DIRECTOR { get; set; }
        public string ENT_ENTIDAD_CONTRATANTE { get; set; }
        public  short  ENT_CANTIDAD_DOCENTES_VOLUNTARIOS { get; set; }
        public  short  ENT_CANTIDAD_DOCENTES_PRESTACION_SERVICIOS { get; set; }
        public  short  ENT_CANTIDAD_DOCENTES_HONORARIOS { get; set; }
        public  short  ENT_CANTIDAD_DOCENTES_NOMINA { get; set; }
        public  short  ENT_CANTIDAD_TOTAL_DOCENTES_VINCULADOS { get; set; }
        public  short  ENT_CANTIDAD_DOCENTES_NIVEL_PRIMARIA { get; set; }
        public  short  ENT_CANTIDAD_DOCENTES_NIVEL_SECUNDARIA { get; set; }
        public  short  ENT_CANTIDAD_DOCENTES_NIVEL_TECNICO { get; set; }
        public  short  ENT_CANTIDAD_DOCENTES_UNIVERSITARIO { get; set; }
        public  short  ENT_CANTIDAD_DOCENTES_PREGRADO_MUSICA { get; set; }
        public  short  ENT_CANTIDAD_DOCENTES_PREGRADO_OTRA_AREA { get; set; }
        public  short  ENT_CANTIDAD_DOCENTES_POSTGRADO { get; set; }
        public  short  ENT_CANTIDAD_TOTAL_DOCENTES_NIVEL_EDUCATIVO { get; set; }
        public bool ENT_CUENTA_APOYO_ADMINISTRATIVO { get; set; }
        public  short ENT_CANTIDAD_APOYO_VOLUNTARIO { get; set; }
        public  short ENT_CANTIDAD_APOYO_PRESTACION_SERVICIOS { get; set; }
        public  short ENT_CANTIDAD_APOYO_HONORARIOS { get; set; }
        public  short ENT_CANTIDAD_APOYO_NOMINA { get; set; }
        public bool ENT_INCLUYE_ACTIVIDAD_MUSICAL { get; set; }

        public string Naturaleza { get; set; }
        public string Regimen { get; set; }
        public string SubRegimen { get; set; }
        public string EntidadDepende { get; set; }
        public string OperaEntidad { get; set; }
        public int DependeEntidad { get; set; }
        public int NivelEntidad { get; set; }

        public string TipoDocumentoCreacion { get; set; }
        public string FechaDocumentoCreacion { get; set; }
        public string NumeroDocumentoCreacion { get; set; }
        public int DocumentoId { get; set; }
    }
}
