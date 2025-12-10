using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class DocumentoDTO
    {
        public int DocumentoAnteriorId { get; set; }
        public int DocumentoId { get; set; }
        public string Token { get; set; }
        public string NombreArchivo { get; set; }
        public string ExtensionArchivo { get; set; }
        public byte[] BytesArchivo { get; set; }
        public decimal TamanoArchivo { get; set; }
        public string TipoContenido { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
    }

   
}
