
namespace SM.LibreriaComun.DTO.FichaAsesoria
{
    public class AsesoriaEscuelaDTO
    {
        public decimal EscuelaId { get; set; }
        public AsesoriaNuevoDTO Asesoria { get; set; }
        public AsesoriaConceptoDTO Concepto { get; set; }
    }
    public class AsesoriaNuevoDTO
    {
        public int Id { get; set; }
        public decimal EscuelaId { get; set; }
        public string PracticaColectiva { get; set; }
        public string NombreAgrupacion { get; set; }
        public string PromedioAnualPresentaciones { get; set; }
        public string PromedioMesesPresentaciones { get; set; }
      
        public string AnoValue { get; set; }
        public string NombreDirector { get; set; }
        public string Basico { get; set; }
        public string Medio { get; set; }
        public string Avanzado { get; set; }
    }
    public class AsesoriaConceptoDTO
    {
        public int Id { get; set; }
        public string AspectoAsesorado { get; set; }
        public string Recomendacion { get; set; }
        public string Concepto { get; set; }
        public string Mecanismo { get; set; }
        public decimal EscuelaId { get; set; }
    }
}
