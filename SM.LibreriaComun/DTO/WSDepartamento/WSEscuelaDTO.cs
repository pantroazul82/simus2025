using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO.WSDepartamento
{
    public class WSEscuelaDTO
    {
        public decimal EscuelaId { get; set; }

        public string Nit { get; set; }
        public string NombreEscuela { get; set; }
        public int AnoConstitucion { get; set; }
        public string Resena { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoDepartamento { get; set; }
        public string CorreoElectronicoEscuela { get; set; }
        public string Area { get; set; }
        public string SitioWeb { get; set; }
        //Datos del contacto
        public string NombreContacto { get; set; }
        public string CargoContacto { get; set; }
        public string TelefonoContacto { get; set; }

        public string CorreoElectronicoContacto { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
