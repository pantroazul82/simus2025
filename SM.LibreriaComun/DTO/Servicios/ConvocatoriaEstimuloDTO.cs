using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.Servicios
{
    public class ConvocatoriaEstimuloDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EstadoId { get; set; }
        public int DocumentoId { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaCierre { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int Periodo { get; set; }
        public string Titulo { get; set; }
    }

    public class ConvocatoriaListadoEstimuloDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }      
        public DateTime FechaApertura { get; set; }
        public DateTime FechaCierre { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int DocumentoId { get; set; }
        public int Periodo { get; set; }
        public int EstadoId { get; set; }
        public string Estado { get; set; }      
     
    }
}
