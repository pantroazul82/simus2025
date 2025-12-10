using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.Notificacion
{
    public class NotificacionDTO
    {
        public int Id { get; set; }

        public int RegistroId { get; set; }
        public string Modulo { get; set; }
        public string NombreEstado { get; set; }
        public string FechaRegistro { get; set; }
        public string Motivo { get; set; }

        public string Tipo { get; set; }

        public int EstadoId { get; set; }
        public int UsuarioId { get; set; }

        public string NombreUsuario { get; set; }
    }
}
