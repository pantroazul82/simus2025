using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.GEO
{
    public class MunicipiosGeoDTO
    {
        public string Cod_Municipio { get; set; }
        public string Municipio { get; set; }
        public Geometry geometry { get; set; }
        public string Cod_Departamento { get; set; }
        public string Departamento { get; set; }
        public int EjeId { get; set; }
        public string Eje { get; set; }
        public int Cantidad { get; set; }
        public string Ver_Mas { get; set; }
        public string Foto { get; set; }
        public string Estilo { get; set; }
        public string Ubicacion { get; set; }
        public IEnumerable<GenerosGeoDTO> ListGeneros { get; set; }
    }

    public class GenerosGeoDTO
    {
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
