using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Datos.DTO
{
    /// <summary>
    /// Clase utilizada para la transferencia datos entre los procedimientos almacenados de consulta para Georreferenciar y la capa de datos. trae datos de las escuelas para el home público
    /// </summary>
    public class EscuelaResultadoPublicoDTO
    {
        public decimal ENT_ID { get; set; }
        public string ENT_NOMBRE { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Municipio { get; set; }
        public string CodigoDepartamento { get; set; }
        public string Departamento { get; set; }
        public string Naturaleza { get; set; }
        public string Tipo { get; set; }
    }

    public class EscuelaResultadoSolicitudDTO
    {
        public decimal EsuelaId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Contacto { get; set; }
        public decimal UsuarioSipaId { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
     
    }
}
