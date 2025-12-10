using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO.Servicios
{

    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. trae datos de la convocatoria
    /// </summary>
    public class ConvocatoriaResultadoDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public string NombreActor { get; set; }
        public string TipoActor { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> DocumentoId { get; set; }
    }

    public class ParticipacionResultadoDTO
    {
        public int Id { get; set; }
        public int ConvocatoriaId { get; set; }
        public Nullable<int> AgenteId { get; set; }
        public Nullable<int> AgrupacionId { get; set; }
        public Nullable<int> EntidadId { get; set; }
        public Nullable<decimal> EscuelaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string RelacionadoA { get; set; }
    
        public string Convocatoria { get; set; }
        public string Estado { get; set; }

        public string Usuario { get; set; }
     
    }
}
