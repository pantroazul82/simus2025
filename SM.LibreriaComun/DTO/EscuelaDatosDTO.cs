using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class EscuelaDatosDTO
    {
        public decimal ENT_ID { get; set; }
        public string ENT_NOMBRE { get; set; }
        public string ENT_IMAGEN { get; set; }
        public string ENT_ESTADO { get; set; }
        public string ENT_NIT { get; set; }
        public string ENT_NOMBRE_CONTACTO { get; set; }
        public string ENT_CARGO_CONTACTO { get; set; }
        public string ENT_RESENA { get; set; }
        public string ENT_TELEFONOS { get; set; }
        public string ENT_CONTACTO_CORREO { get; set; }
        public string ZON_ID { get; set; }
        public string ZON_NOMBRE { get; set; }
        public string ZON_PADRE_ID { get; set; }
        public string ZON_NOMBRE_PADRE { get; set; }
        public string ENT_DIRECCION { get; set; }
        public string ENT_DIRECCION_CORRESPONDENCIA { get; set; }
        public string ENT_TELEFONO { get; set; }
        public string ENT_FAX { get; set; }
        public string ENT_CORREO_ELECTRONICO_ENTIDAD { get; set; }
        public string ENT_PAGINA_WEB { get; set; }
        public Nullable<short> ID_CATEGORIA { get; set; }
        public Nullable<System.DateTime> FECHA_CATEGORIZACION { get; set; }
        public Nullable<decimal> PORCENTAJE_TOTAL { get; set; }
        public string DESCRIPCION_CATEGORIA { get; set; }
        public Nullable<decimal> USU_ID { get; set; }
    }

    public class EscuelaNuevoDatosDTO
    {
        public decimal ENT_ID { get; set; }
        public string ENT_NOMBRE { get; set; }
        public string ENT_ESTADO { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Naturaleza { get; set; }
        public string Tipo { get; set; }

        public System.DateTime ENT_FECHA_ACTUALIZACION { get; set; }
        public System.DateTime ENT_FECHA_DILIGENCIAMIENTO { get; set; }
       
    }

    public class EscuelaAuditoriaModelDTO
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public string FechaRegistro { get; set; }
        public string Operacion { get; set; }
        public string NombreUsuario { get; set; }
        public string Escuelas { get; set; }
        public string Descripcion { get; set; }
    }
}
