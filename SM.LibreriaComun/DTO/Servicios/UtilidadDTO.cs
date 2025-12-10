using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.Servicios
{
    public class UtilidadDTO
    {
        public int UtilidadId { get; set; }
        public int DocumentoId { get; set; }
        public int EstadoId { get; set; }
        public byte[] imagen { get; set; }
        public int ActorId { get; set; }
        public int TipoUtilidadId { get; set; }
        public int TipoEventoId { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public string RelacionadoA { get; set; }
        public int TipoActorId { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public int UsuarioAprobadorId { get; set; }
        public bool EsActivo { get; set; }
        // datos ubicacion
        public int CodPais { get; set; }
        public string OtraCiudad { get; set; }
        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string codDepto { get; set; }
        public string Departamento { get; set; }
        public string codMunicipio { get; set; }
        public string Municipio { get; set; }


        // datos contacto
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
    }

    public class UtilidadListadoDTO
    {

        public int UtilidadId { get; set; }
        public string Titulo { get; set; }
        public string TipoActor { get; set; }
        public string NombreActor { get; set; }
        public string TipoUtilidad { get; set; }
        public string Clasificacion { get; set; }
        public string Estado { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public string FechaActualizacion { get; set; }
        public string FechaCreacion { get; set; }

    }

    public class UtilidadDataDetalleDTO
    {
        public int UtilidadId { get; set; }
        public int DocumentoId { get; set; }
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

    public class UtilidadHomeDataDTO
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
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Estado { get; set; }
        public string rutaFoto { get; set; }
        public string verMas { get; set; }
        public byte[] Imagen { get; set; }
        public string Descripcion { get; set; }
        public string Pais { get; set; }
        public string Ubicacion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public int DocumentoId { get; set; }

    }

    public class NoticiasDataDTO
    {
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public byte[] Imagen { get; set; }
        public string Descripcion { get; set; }
        public int UtilidadId { get; set; }
        public string Titulo { get; set; }
        public string rutaFoto { get; set; }
    }
}
