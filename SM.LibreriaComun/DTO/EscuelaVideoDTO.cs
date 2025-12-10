using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class EscuelaVideoDTO
    {
        public int Id { get; set; }
        public decimal EscuelaId { get; set; }
        public string clasificacion { get; set; }

        public string Descripcion { get; set; }

        public string FechaPublicacion { get; set; }
        public string urlvideoYoutube { get; set; }
    }

    public class EscuelaDocumentoDTO
    {
        public int DotacionId { get; set; }
        public int DotacionDocumentoId { get; set; }

        public int CronogramaId { get; set; }
        public int CronogramaDocumentoId { get; set; }
        public decimal EscuelaId { get; set; }
        public int EscuelaDocumentoId { get; set; }
        public int DocumentoId { get; set; }
        public string NombreArchivo { get; set; }
        public string FechaRegistro { get; set; }
        public decimal TamanoArchivo { get; set; }
        public DateTime Fecha { get; set; }
        public string Categoria { get; set; }
    }

    public class DotacionInstrumentoDTO
    {
        public int DotacionId { get; set; }
        public int DotacionInstrumentoId { get; set; }

        public string Instrumento { get; set; }
        public string Prioridad { get; set; }
        public int Cantidad { get; set; }

    }
}
