using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
    public class OcupacionResultadoDTO
    {
        public int AgenteId { get; set; }
        public int Id { get; set; }
        public int OficioId { get; set; }
        public string Atributo { get; set; }
        public bool EsInstrumento { get; set; }
        public bool EsGenero { get; set; }
    }

    public class DocumentoResultadoDTO
    {
        public int DotacionId { get; set; }
        public int CronogramaId { get; set; }
        public int DotacionDocumentoId { get; set; }
        public decimal EscuelaId { get; set; }
        public int EscuelaDocumentoId { get; set; }
        public int DocumentoId { get; set; }
        public string NombreArchivo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal TamanoArchivo { get; set; }
        public string Categoria { get; set; }
    }

    public class InstrumentoResultadoDTO
    {
        public int DotacionId { get; set; }
        public int DotacionInstrumentoId { get; set; }
       
        public string Instrumento { get; set; }
        public string Prioridad { get; set; }
        public int Cantidad { get; set; }
      
    }
}
