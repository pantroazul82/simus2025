
namespace WebSImus.Models
{
    public partial class EscuelaConsultaModel
    {
        public decimal EscuelaId { get; set; }
        public decimal UsuarioId { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
        public string Categoria { get; set; }
        public string NombreEscuela { get; set; }
        public string Naturaleza { get; set; }
        public string Tipo { get; set; }
        public string codigoEstado { get; set; }
        public string Estado { get; set; }
        public string FechaActualizacion { get; set; }
        public string FechaCreacion { get; set; }
    }

    public partial class ConsultaModel
    {
        public int Id { get; set; }
        public int TipoRegistro { get; set; }
        public string selectorAno { get; set; }
      
    }

    public partial class CertificacionModel
    {
        public int Id { get; set; }
      
        public string modulo { get; set; }

    }
}