using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SM.Datos.DTO
{
    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. trae datos de los básicos reportes
    /// </summary>
    [XmlRoot, Serializable]
    public class BasicoReporte
    {
        public string Id { get; set; }
       
        public string Nombre { get; set; }
        public int Value { get; set; }
    }

    public class UbicacionReporte
    {
        public int Rural { get; set; }
        public int Urbana { get; set; }
    }

    public class FamiliaInstrumentalReporte
    {
        public int cuerdapulsada { get; set; }
        public int cuerdassinf { get; set; }
        public int vientomadera { get; set; }
        public int vientometales { get; set; }
        public int pmenor { get; set; }
        public int psinfonica { get; set; }
        public int instrumentootra { get; set; }
        public int total { get; set; }
    }

    public class NivelEducativoReporte
    {
        public string ENT_NATURALEZA { get; set; }
        public int primaria { get; set; }
        public int secundaria { get; set; }
        public int tecnico { get; set; }
        public int universiatrio { get; set; }
        public int pregradomusica { get; set; }
        public int pregradootra { get; set; }
        public int postgrado { get; set; }
        public int total { get; set; }
    }

    public class ProduccionReporte
    {
        public string ENT_NATURALEZA { get; set; }
        public int giraLocales { get; set; }
        public int nacional { get; set; }
        public int internacional { get; set; }
     
    }

    public class RangoETarioReporte
    {
        public int Menor6 { get; set; }
        public int Entre7y11 { get; set; }
        public int Entre12y18 { get; set; }
        public int Entre19y25 { get; set; }
        public int Entre26y60 { get; set; }
        public int Mayor60 { get; set; }

    }

    public class GrupoEtnicoReporte
    {
        public int PoblacionAfro { get; set; }
        public int PoblacionIndigena { get; set; }
        public int PoblacionRom { get; set; }
        public int PoblacionRaizales { get; set; }
       

    }
}
