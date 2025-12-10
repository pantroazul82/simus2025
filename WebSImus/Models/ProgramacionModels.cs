using System.ComponentModel.DataAnnotations;


namespace WebSImus.Models
{
    public class ProgramacionModels
    {
        [Required(ErrorMessage = "El municipio es obligatorio")]
        public string CodigoMunicipio { get; set; }
        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string CodigoDepartamento { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        public string codigoAno { get; set; }
    }
}