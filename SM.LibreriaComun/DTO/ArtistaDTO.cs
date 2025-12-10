using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class ArtistaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Enlace { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Orden { get; set; }
        public Nullable<bool> EsGrupo { get; set; }
        public int CantidadMiembros { get; set; }
        public byte[] Imagen { get; set; }
        public string Resena { get; set; }
        public int ProcesoId { get; set; }
        public int UsuarioId { get; set; }
        public Nullable<System.DateTime> FechaPresentacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public int EventoId { get; set; }
        public int CategoriaId { get; set; }
    }
}
