using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SM.Datos.DTO.Geo
{
    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos.  Tabla Agentes
    /// </summary>
    public class AgentesGeoResultadoDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodPais { get; set; }
        public string Pais { get; set; }
        public string NombreArtistico { get; set; }
        public string LinkPortafolio { get; set; }
        public Nullable<double> LatitudMunicipio { get; set; }
        public Nullable<double> LongitudMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string PerfilFacebook { get; set; }
        public string PerfilFlickr { get; set; }
        public string CanalYoutube { get; set; }
        public string PerfilTwitter { get; set; }
        public string PerfilSoundCloud { get; set; }
        public string PaginaWeb { get; set; }

    }


    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos.  Tabla entidades
    /// </summary>
    public class EntidadesGeoResultadoDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public int Nit { get; set; }
        public string Direccion { get; set; }
        public string Naturaleza { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoDepartamento { get; set; }
        public int CodPais { get; set; }
        public string Pais { get; set; }
        public string LinkPortafolio { get; set; }
        public Nullable<double> LatitudMunicipio { get; set; }
        public Nullable<double> LongitudMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string PerfilFacebook { get; set; }
        public string PerfilFlickr { get; set; }
        public string CanalYoutube { get; set; }
        public string PerfilTwitter { get; set; }
        public string PerfilSoundCloud { get; set; }
        public string PaginaWeb { get; set; }

    }


    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos.  Tabla agrupaciones
    /// </summary>
    public class AgrupacionGeoResultadoDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodPais { get; set; }
        public string Pais { get; set; }
        public string LinkPortafolio { get; set; }
        public Nullable<double> LatitudMunicipio { get; set; }
        public Nullable<double> LongitudMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string PerfilFacebook { get; set; }
        public string PerfilFlickr { get; set; }
        public string CanalYoutube { get; set; }
        public string PerfilTwitter { get; set; }
        public string PerfilSoundCloud { get; set; }
        public string PaginaWeb { get; set; }

    }


    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos.  Tabla Agentes por municipio
    /// </summary>
    public class AgenteMunicipioResultadoDTO
    {
        public string CodDepartamento { get; set; }
        public string CodMunicipio { get; set; }
        public string Municipio { get; set; }
        public int cantidad { get; set; }
       

    }

  
}
