using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class ArtistaDetalleDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int CantidadMiembros { get; set; }
        public int Orden { get; set; }
        public string Enlace { get; set; }
        public bool EsGrupo { get; set; }
        public byte[] imagen { get; set; }

        public int EventoId { get; set; }
        public string Resena { get; set; }

        public string NombreDepartamento { get; set; }
        public string NombreMunicipio { get; set; }
        public string LugarEvento { get; set; }
        public string EntidadOrganizadora { get; set; }
        public string Proceso { get; set; }
        public string Categoria { get; set; }
    }
}
