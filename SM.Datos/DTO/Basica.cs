using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. trae datos básicos
    /// </summary>
   public  class Basica
    {
       public string Value { get; set; }
       public string Nombre { get; set; }
    }


   public class ReporteDTO
   {
       public int valor { get; set; }
       public string Nombre { get; set; }
   }

   public class PracticaHistoricoDTO
   {
       public int Bandas { get; set; }
       public int Coros { get; set; }
       public int Orquesta { get; set; }
       public int Urbana { get; set; }
       public int Iniciacion { get; set; }
       public int MusicaTradicional { get; set; }
      
   }

   public class UsuarioResultadoDTO
   {
       public int ID { get; set; }
       public string NombreUsuario { get; set; }
       public string Email { get; set; }
       public string TipoRSS { get; set; }
 

   }
}
