using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class UtilidadHomeModels
    {
        public int UtilidadId { get; set; }

        public int documentoId { get; set; }
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

        [Display(Name = "Descargar archivos:")]
        public List<DocumentoModels> documentoArchivo { get; set; }
        public List<NoticiasRecientes> listadoNoticias { get; set; }

       
    }

    public class NoticiasRecientes
    {
        public string FechaInicio { get; set; }
        public string rutaFoto { get; set; }
        public string verMas { get; set; }
        public byte[] Imagen { get; set; }
        public string Descripcion { get; set; }
        public int UtilidadId { get; set; }
        public string Titulo { get; set; }
    }

    public class ListadoCajaModel
    {
        public int  Id { get; set; }
        public string Nombre { get; set; }
        public int TipoId { get; set; }
        public string TipoHerramienta { get; set; }
     
    }
}