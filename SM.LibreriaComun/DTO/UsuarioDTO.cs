using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class UsuarioDTO
    {
        public decimal USU_ID { get; set; }
        public Nullable<decimal> ARE_ID { get; set; }
        public Nullable<decimal> SEC_ID { get; set; }
        public Nullable<decimal> DEP_ID { get; set; }
        public string USU_TIPO { get; set; }
        public string USU_USUARIO { get; set; }
        public string USU_NOMBRE { get; set; }
        public string USU_CARGO { get; set; }
        public string USU_DIRECCION { get; set; }
        public string USU_TELEFONO { get; set; }
        public string USU_CORREO_ELECTRONICO { get; set; }
        public int USU_DIAS_EXPIRACION { get; set; }
        public string USU_CLAVE { get; set; }
        public string USU_CAMBIO_CLAVE { get; set; }
        public Nullable<System.DateTime> USU_FECHA_ULTIMO_INGRESO { get; set; }
        public Nullable<System.DateTime> USU_FECHA_CAMBIO_CLAVE { get; set; }
        public Nullable<System.DateTime> USU_FECHA_CREACION { get; set; }
        public Nullable<System.DateTime> USU_FECHA_ACTUALIZACION { get; set; }
        public string USU_ESTADO { get; set; }
        public Nullable<int> USU_INTENTOS_FALLIDOS_INGRESO { get; set; }
        public string USU_ADMINISTRADOR { get; set; }
        public string USU_REVISOR_ESTILO { get; set; }
        public string ZON_ID { get; set; }
        public string USU_DEPARTAMENTO { get; set; }
        public Nullable<decimal> usu_id_anterior { get; set; }
        public string USU_APELLIDO { get; set; }
        public RolDTO rol { get; set; }
     


    }

    public class SolicitudUsuarioDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
        public string NombreUsuario { get; set; }
        public string EntidadOrganizadora { get; set; }
        public decimal EscuelaId { get; set; }
        public string NombreEscuela { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Estado { get; set; }
        public string CorreoUsuario { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int EstadoId { get; set; }

    }
}
