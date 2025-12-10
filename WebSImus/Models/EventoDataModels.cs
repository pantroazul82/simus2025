using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSImus.Models
{
    public class EventoDataModels
    {
        public int EventoId { get; set; }
        public int UsuarioId { get; set; }
        public string CodDepartamento { get; set; }
        public string CodMunicipio { get; set; }
        public int AnoEvento { get; set; }
        public string EntidadOrganizadora { get; set; }
        public string Nombre { get; set; }
        public string LugarEvento { get; set; }
        public string NombreDepartamento { get; set; }
        public string NombreMunicipio { get; set; }
        public string Email { get; set; }
        public System.DateTime FechaEvento { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string TextoFechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string FechaActualizacion { get; set; }
        public Nullable<System.DateTime> FechaEventoFinal { get; set; }
        public bool EsNacional { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string rutaFoto { get; set; }

        public string artistas { get; set; }
        public byte[] Imagen { get; set; }
        public string TieneImagen { get; set; }
        public string TieneArtistas { get; set; }
        public string Usuario { get; set; }
    }
}