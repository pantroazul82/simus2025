using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SM.Aplicacion.Agentes
{
    [DataContract]
    public class AgenteModels
    {
         [DataMember(Name = "AgenteId")]
        public int AgenteId { get; set; }
         [DataMember(Name = "CodigoTipoDocumento")]
        public int CodigoTipoDocumento { get; set; }
         [DataMember(Name = "NumeroDocumento")]
        public string NumeroDocumento { get; set; }
         [DataMember(Name = "CiudadNacimiento")]
        public string CiudadNacimiento { get; set; }
         [DataMember(Name = "LugarExpDocumento")]
        public string LugarExpDocumento { get; set; }
         [DataMember(Name = "CodigoPais")]
        public int CodigoPais { get; set; }
         [DataMember(Name = "CodigoMunicipio")]
        public string CodigoMunicipio { get; set; }
         [DataMember(Name = "PerteneceMinoriaEtnica")]
        public bool? PerteneceMinoriaEtnica { get; set; }
         [DataMember(Name = "CodigoMinoriaEtnica")]
        public int? CodigoMinoriaEtnica { get; set; }
         [DataMember(Name = "FechaDiligenciamiento")]
        public DateTime FechaDiligenciamiento { get; set; }
         [DataMember(Name = "NombresApellidos")]
        public string NombresApellidos { get; set; }
         [DataMember(Name = "Seudononimo")]
        public string Seudononimo { get; set; }
         [DataMember(Name = "TieneTarjetaProfesional")]
        public bool TieneTarjetaProfesional { get; set; }
         [DataMember(Name = "NumeroTP")]
        public string NumeroTP { get; set; }
         [DataMember(Name = "AnoTarjetaProfesional")]
        public string AnoTarjetaProfesional { get; set; }
         [DataMember(Name = "TieneDiscapacidad")]
        public bool? TieneDiscapacidad { get; set; }
         [DataMember(Name = "DescripcionDiscapacidad")]
        public string DescripcionDiscapacidad { get; set; }
         [DataMember(Name = "Genero")]
        public string Genero { get; set; }
         [DataMember(Name = "FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }
         [DataMember(Name = "LugarNacimiento")]
        public string LugarNacimiento { get; set; }
         [DataMember(Name = "TienePasaporte")]
        public bool? TienePasaporte { get; set; }
         [DataMember(Name = "NumeroPasaporte")]
        public string NumeroPasaporte { get; set; }
         [DataMember(Name = "FechaExpedicionPasaporte")]
        public DateTime? FechaExpedicionPasaporte { get; set; }
         [DataMember(Name = "FechaVencimientoPasaporte")]
        public DateTime? FechaVencimientoPasaporte { get; set; }
         [DataMember(Name = "CodigoEstado")]
        public string CodigoEstado { get; set; }
         [DataMember(Name = "CodigoTipoAgente")]
        public string CodigoTipoAgente { get; set; }
         [DataMember(Name = "UsuarioSIpaId")]
        public decimal UsuarioSIpaId { get; set; }
         [DataMember(Name = "FechaVigenciaInicial")]
        public DateTime? FechaVigenciaInicial { get; set; }
         [DataMember(Name = "FechaVigenciaFinal")]
        public DateTime? FechaVigenciaFinal { get; set; }
       
    }
}
