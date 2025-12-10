using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class AgrupacionHomeModels
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
        public string rutaFoto { get; set; }
        public string verMas { get; set; }
        public byte[] Imagen { get; set; }
        public int TipoAgrupacionId { get; set; }
        public string Tipo { get; set; }
        public string PerfilFacebook { get; set; }
        public string CanalYoutube { get; set; }
        public string PerfilTwitter { get; set; }
        public string PerfilSoundCloud { get; set; }
        public string Genero { get; set; }
    }

    public class ActoresHomeModels
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
        public string rutaFoto { get; set; }
        public string verMas { get; set; }
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