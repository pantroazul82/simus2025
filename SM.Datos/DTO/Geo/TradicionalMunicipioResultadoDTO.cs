using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO.Geo
{
    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. trae datos para el mapa musical
    /// </summary>
    public class TradicionalMunicipioResultadoDTO
    {
        public string CodMunicipio { get; set; }
        public string Municipio { get; set; }
        public Nullable<double> Latitud { get; set; }
        public Nullable<double> Longitud { get; set; }
        public string CodDepartamento { get; set; }
        public string Departamento { get; set; }
        public int EjeId { get; set; }
        public string Eje { get; set; }
        public string Foto { get; set; }
        public string Estilo { get; set; }
        public int Cantidad { get; set; }
    }

    public class TradicionalGeneroResultadoDTO
    {
        public string CodMunicipio { get; set; }
        public int IdEje { get; set; }
        public string NombreEje { get; set; }
        public int GeneroId { get; set; }
        public string Genero { get; set; }
        public string Titulo { get; set; }
       public string Detalle { get; set; }
       public string NombreArchivo { get; set; }
       public string Ruta { get; set; }
    }
}
