using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO.Servicios
{
    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. trae datos de las utilidades
    /// </summary>
    public class UtilidadResultadoDTO
    {

        public int UtilidadId { get; set; }
        public string Titulo { get; set; }
        public string TipoActor { get; set; }
        public string NombreActor { get; set; }
        public string TipoUtilidad { get; set; }
        public string Clasificacion { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }

        public Nullable<System.DateTime> FechaActualizacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }


    }

    public class UtilidadDetalleDTO
    {
        public int UtilidadId { get; set; }
        public int ? DocumentoId { get; set; }
        public string Titulo { get; set; }
        public string TipoActor { get; set; }
        public string NombreActor { get; set; }
        public string TipoUtilidad { get; set; }
        public string Clasificacion { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public byte[] Imagen { get; set; }
        public string OtraCiudad { get; set; }


    }

    public class UtilidadHomeDTO
    {
        public int UtilidadId { get; set; }
        public string Titulo { get; set; }
        public string TipoActor { get; set; }
        public string NombreActor { get; set; }
        public string TipoUtilidad { get; set; }
        public string Clasificacion { get; set; }
        public int TipoServicioId { get; set; }
        public int TipoActorId { get; set; }
        public int TipoEventoId { get; set; }
        public int CodPais { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public string Estado { get; set; }
        public byte[] Imagen { get; set; }
        public string Descripcion { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string OtraCiudad { get; set; }

        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int DocumentoId { get; set; }


    }

    public class NoticiasDTO
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public byte[] Imagen { get; set; }
        public string Descripcion { get; set; }
        public int UtilidadId { get; set; }
        public string Titulo { get; set; }
    }

  
}
