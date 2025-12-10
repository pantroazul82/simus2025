using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.GEO
{
    public class CelebraGeoDTO
    {
        public int CantidadConciertos { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Cod_Municipio { get; set; }
        public string Cod_Departamento { get; set; }
        public string Ver_Mas { get; set; }
        public Geometry geometry { get; set; }
        public IEnumerable<ConciertosDTO> Conciertos { get; set; }
    }


    public class CelebraPorcentajeGeoDTO
    {
        public int CantidadTotalMunicipios { get; set; }
        public int CantidadConciertoRegistrado { get; set; }
        public int PorcentajeAvance { get; set; }
        public string Departamento { get; set; }

        public string Cod_Departamento { get; set; }

    }

    public class ConciertosPorMunicipioDTO
    {     
        public string CodMunicipio { get; set; }
        public string NombreMunicipio { get; set; }
        public int cantidad { get; set; }
        public string ver_Mas { get; set; }

    }
    public class ConciertosDTO
    {
        public int ConciertoId { get; set; }
        public string Lugar { get; set; }
        public string EntidadOrganizadora { get; set; }
        public string CodMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Ver_Mas { get; set; }
        public string hora { get; set; }
 
  
    }
}
