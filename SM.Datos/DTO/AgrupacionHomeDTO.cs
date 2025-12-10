using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. trae datos de agrupaciones
    /// </summary>
    public class AgrupacionHomeDTO
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoPais { get; set; }
        public string Pais { get; set; }
        public string PaginaWeb { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }

        public byte[] Imagen { get; set; }
        public int TipoAgrupacionId { get; set; }
        public string Tipo { get; set; }
        public string PerfilFacebook { get; set; }
        public string CanalYoutube { get; set; }
        public string PerfilTwitter { get; set; }
        public string PerfilSoundCloud { get; set; }
        public string Genero { get; set; }
    }

    public class ActoresHomeDTO
    {

        public decimal ENT_ID { get; set; }
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoPais { get; set; }
        public string Pais { get; set; }
        public string PaginaWeb { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }

        public byte[] Imagen { get; set; }
        public int TipoId { get; set; }
        public string Tipo { get; set; }
        public string PerfilFacebook { get; set; }
        public string CanalYoutube { get; set; }
        public string PerfilTwitter { get; set; }
        public string PerfilSoundCloud { get; set; }
        public string Dato { get; set; }
    }
}
