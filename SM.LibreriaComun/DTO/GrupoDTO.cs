using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class GrupoDTO
    {
        public int Id { get; set; }

        public int EventoId { get; set; }
        public string Nombre { get; set; }
        public string Enlace { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public int Orden { get; set; }
        public int CantidadMiembros { get; set; }
        public bool EsGrupo { get; set; }
        public string Reseña { get; set; }
        public byte[] Imagen { get; set; }
    }
}
