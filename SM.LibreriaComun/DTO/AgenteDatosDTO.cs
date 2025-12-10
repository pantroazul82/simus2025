using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
   public class AgenteDatosDTO
    {
        public int AgenteId { get; set; }
        public int ArtMusicaUsuarioId { get; set; }
        public string TipoDocumento { get; set; }
        public string TipoDocumentoDescripcion { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompletos { get; set; }
        public string Estado { get; set; }
        public string NumeroDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public string Sexo { get; set; }
        public string CodigoPais { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Telefono { get; set; }
        public string linkPortafolio { get; set; }
        public string Descripcion { get; set; }
        public byte[] imagen { get; set; }
    }

   public class AgenteListadoDTO
   {
       public int AgenteId { get; set; }
       public string CodigoDepartamento { get; set; }
       public string CodMunicipio { get; set; }
       public string Direccion { get; set; }
       public DateTime FechaCreacion { get; set; }
       public DateTime FechaActualizacion { get; set; }
       public string Nombres { get; set; }
       public string Apellidos { get; set; }
       public string NombreCompletos { get; set; }
       public string Departamento { get; set; }
       public string Municipio { get; set; }
     
       public string Estado { get; set; }
     
    
     
   }
}
