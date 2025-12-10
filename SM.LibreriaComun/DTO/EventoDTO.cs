using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class EventoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal AreaArtisticaId { get; set; }
        public string EntidadOrganizadora { get; set; }
        public Nullable<int> EntidadId { get; set; }
        public Nullable<int> AgenteId { get; set; }
        public string CodDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public string CodMunicipio { get; set; }
        public string NombreMunicipio { get; set; }
        public string LugarEvento { get; set; }
        public System.DateTime FechaEvento { get; set; }
        public Nullable<System.DateTime> FechaEventoFinal { get; set; }
        public string Descripción { get; set; }
        public byte[] Imagen { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string Tipo { get; set; }
        public int AnoEvento { get; set; }
        public int UsuarioId { get; set; }
        public int EstadoId { get; set; }
        public int DocumentoId { get; set; }
        public bool EsNacional { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public bool Destacado { get; set; }
    }

    public class ReporteDepartamentoDTO
    {
        public string Codigo { get; set; }
        public string Periodo { get; set; }
        public string Departamento { get; set; }
        public int CantidadMunicipios { get; set; }
        public int CantidadMunConEventos { get; set; }
        public decimal Porcentaje { get; set; }
    }
}
