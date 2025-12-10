using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.Servicios
{
    public class DotacionDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ConvocatoriaId { get; set; }
        public int EntidadId { get; set; }
        public int EscuelaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

    }
}
