using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
   public class EventoResultadoDTO
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
       public Nullable<System.DateTime>  FechaModificacion { get; set; }
       public Nullable<System.DateTime> FechaEventoFinal { get; set; }
       public bool EsNacional { get; set; }
       public string Tipo { get; set; }
       public string Estado { get; set; }
       public byte[] Imagen { get; set; }
       public string TieneImagen { get; set; }
       public string TieneArtistas { get; set; }
       public string Usuario { get; set; }
       
    }

   public class ConciertoResultadoDTO
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
       public System.DateTime FechaEvento { get; set; }
       public System.DateTime FechaCreacion { get; set; }
       public Nullable<System.DateTime> FechaModificacion { get; set; }
       public Nullable<System.DateTime> FechaEventoFinal { get; set; }
       public bool EsNacional { get; set; }
       public string Tipo { get; set; }
       public string Estado { get; set; }
       public byte[] Imagen { get; set; }
   }

     public class ListadoAnosDTO
     { public int AnoEvento { get; set; } }

     public class DepartamentoDTO
     {
         public string CODIGO { get; set; }
         public string DEPARTAMENTO { get; set; }
         public int CANTIDAD { get; set; }
     }
}
