using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class ResultadoEstimuloDTO
    {
        public long Id { get; set; }

        public int Edad { get; set; }
        public string NumeroRadicacion { get; set; }

        public string NombreConvocatoria { get; set; }

        public string Area { get; set; }

        public string Participante { get; set; }

        public string NombreParticipante { get; set; }

        public string Seudonimo { get; set; }

        public string NombreProyecto { get; set; }

        public string NombreEstado { get; set; }

        public string CausalRechazo { get; set; }

        public string NombreModalidad { get; set; }

        public string Resolucion { get; set; }

        public short Anio { get; set; }

        public string Genero { get; set; }
        public string FechaNacimiento { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
    }

    public class CoordenadasDTO
    {
       
        public string Latitud { get; set; }

        public string Longitud { get; set; }

        public string Barrio { get; set; }

        public string Localidad { get; set; }

        public string Direccion { get; set; }
        public string Ciudad { get; set; }

       
    }
}
