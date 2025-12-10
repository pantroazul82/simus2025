using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class BasicoReporteDTO
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class indicadoresDTO
    {
        public string indexLabel { get; set; }
        public int y { get; set; }

        public int orden { get; set; }

        public bool exploded { get; set; }
    }

    public class EscuelasEstadisticasDTO
    {
        public int PublicaDepende { get; set; }
        public int PrivadaDepende { get; set; }
        public int MixtaDepende { get; set; }
        public int TotalDepende { get; set; }
        public int PublicaOrganizacion { get; set; }
        public int PrivadaOrganizacion { get; set; }
        public int MixtaOrganizacion { get; set; }
        public int TotalOrganizacion { get; set; }
        public string selectorAno { get; set; }

        public string periodo { get; set; }
    }

    public class EstudiantesEstadisticasDTO
    {
        [DisplayFormat(DataFormatString = "{0:N}")]
        public int Rural { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public int Urbana { get; set; }
        public int totalUbicacion { get; set; }
        public decimal PorcentajeRural { get; set; }
        public decimal PorcentajeUrbana { get; set; }
        public string selectorAno { get; set; }

    }

    public class DocentesEstadisticasDTO
    {
        public int Publica { get; set; }
        public int Privada { get; set; }
        public int Mixta { get; set; }
        public int TotalDocentes { get; set; }
        public int TotalAlumnos { get; set; }
        public string selectorAno { get; set; }
    }

    public class DepartamentoEstadisticasDTO
    {
        public int Publica { get; set; }
        public int Privada { get; set; }
        public int Mixta { get; set; }
        public int TotalEscuelas { get; set; }
        public string NombreDepto { get; set; }
        public string selectorAno { get; set; }

    }
    public class LegalmenteDTO
    {
        public string label { get; set; }
        public int y { get; set; }

    }
}
