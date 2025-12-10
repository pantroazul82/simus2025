using SM.LibreriaComun.DTO.GEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class MapaMusicalModelo
    {
        public string CodigoMunicipio { get; set; }
        public int EjeId { get; set; }
        public string Eje { get; set; }
        public int Cantidad { get; set; }
        public string Foto { get; set; }
        public string Estilo { get; set; }
        public string Ubicacion { get; set; }
        public string Ver_Mas { get; set; }
        public IEnumerable<GenerosGeoDTO> ListGeneros { get; set; }
    }
}