using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SM.LibreriaComun.DTO
{
    public class EscuelaDTO
    {
        public Nullable<decimal> ENT_ID { get; set; }
        public Nullable<System.DateTime> ENT_FECHA_DILIGENCIAMIENTO { get; set; }

        public string ENT_FORMACION_PUBLICO { get; set; }
        public string ENT_NOMBRE { get; set; }
        public string ENT_IMAGEN { get; set; }

        public string Naturaleza { get; set; }
        public string TipoEscuela { get; set; }
        public string ENT_ESTADO { get; set; }
        public Nullable<System.DateTime> ENT_FECHA_VIGENCIA_INICIAL { get; set; }
        public Nullable<System.DateTime> ENT_FECHA_VIGENCIA_FINAL { get; set; }
        public string ENT_NIT { get; set; }
        public Nullable<int> ENT_ANO_CONSTITUCION { get; set; }
        public Nullable<decimal> ENT_ACTIVIDAD_PRINCIPAL { get; set; }
        public Nullable<decimal> ENT_AREA_ARTISTICA { get; set; }

        public string ENT_NOMBRE_CONTACTO { get; set; }
        public string ENT_CARGO_CONTACTO { get; set; }
        public Nullable<int> ENT_ANO_VINCUALCION_CONTACTO { get; set; }
        public Nullable<int> ENT_NIVEL_ENTIDAD_DEPENDE_RED { get; set; }
        public string ENT_NOMBRE_ENTIDAD_DEPENDE_RED { get; set; }
        public string ENT_OBSERVACION_VALIDACION { get; set; }
        public string ENT_CONCERTACION { get; set; }
        public Nullable<System.DateTime> ENT_FECHA_ACTUALIZACION { get; set; }
        public Nullable<short> ENT_RECURSO_PRIVADO { get; set; }
        public Nullable<short> ENT_RECURSO_PUBLICO { get; set; }
        public Nullable<short> ENT_RECURSO_MIXTAS { get; set; }
        public Nullable<decimal> REG_ID { get; set; }
         public string ENT_RESENA { get; set; }
        public Nullable<System.DateTime> ENT_FECHA_CAMBIO_ESTADO { get; set; }
        public string ZON_ID { get; set; }
        public string ZON_NOMBRE { get; set; }
        public string ZON_PADRE_ID { get; set; }
        public string ZON_NOMBRE_PADRE { get; set; }
        public string ENT_TELEFONOS { get; set; }
        public string ENT_CONTACTO_CORREO { get; set; }
        public string ZOP_NOMBRE { get; set; }
        public string ENT_DIRECCION { get; set; }
        public string ENT_DIRECCION_CORRESPONDENCIA { get; set; }
        public string ENT_TELEFONO { get; set; }
        public string ENT_FAX { get; set; }
        public string ENT_CORREO_ELECTRONICO_ENTIDAD { get; set; }
        public string ENT_PAGINA_WEB { get; set; }
        public string ENT_NOMBRES_DIRECTOR { get; set; }
        public string PERFIL_FACEBOOK { get; set; }
        public string PERFIL_TWITTER { get; set; }
        public string CANAL_YOUTUBE { get; set; }

        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string ENT_TELEFONOS_ESCUELA { get; set; }
        public string ENT_CONTACTO_CORREO_ESCUELA { get; set; }
        public decimal ARE_ID { get; set; }
        public decimal USU_ID { get; set; }
        public byte[] Imagen { get; set; }

        public string EstadoId { get; set; }
        public string OperatividadEscuela { get; set; }
    }
}
