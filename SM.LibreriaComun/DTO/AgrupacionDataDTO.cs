using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class AgrupacionDataDTO
    {
        public int AgrupacionId { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoPais { get; set; }
        public string Telefono { get; set; }
        public int TipoAgrupacionId { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public System.DateTime FechaActualizacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public byte[] Imagen { get; set; }
        public string LinkPortafolio { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string CODIGO { get; set; }
        public string DOC_NOMBRE { get; set; }
        public string Identificacion { get; set; }
        public string NombreDirector { get; set; }
        public string ApellidoDirector { get; set; }
        public string TipoAgrupacion { get; set; }
        public int DocumentoId { get; set; }
    }

    public class AgrupacionHomeDataDTO
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

    public class ActorHomeDataDTO
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
        public int TipoId { get; set; }
        public string Tipo { get; set; }
        public string PerfilFacebook { get; set; }
        public string CanalYoutube { get; set; }
        public string PerfilTwitter { get; set; }
        public string PerfilSoundCloud { get; set; }
        public string Dato { get; set; }
    }
}
