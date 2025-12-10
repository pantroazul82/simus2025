using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.EntidadesOperadoras
{
    public class ContenidoDTO
    {
        public int Id { get; set; }
        public string NombreContenido { get; set; }
        public string DescripcionContenido { get; set; }
        public string ActividadId { get; set; }
        public int UsuarioId { get; set; }
        public System.DateTime Fechacreacion { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
    }

    public class DotacionDTO
    {
        public int Id { get; set; }
        public string CronogramaId { get; set; }
        public string Tipo { get; set; }
        public string TipoId { get; set; }
        public string Elemento { get; set; }
        public string ElementoId { get; set; }
        public string Formato { get; set; }
        public string FormatoId { get; set; }
        public string Marca { get; set; }
        public string Referencia { get; set; }
        public string Serial { get; set; }
        public string Garantia { get; set; }
        public string Diagnostico { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Aprobado { get; set; }
        public int UsuarioId { get; set; }
        public System.DateTime Fechacreacion { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
    }
}
