using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class EscenariohomeDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodDepto { get; set; }
        public string Departamento { get; set; }
        public string CodMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Direccion { get; set; }
        public int Aforo { get; set; }
        public string RelacionadoA { get; set; }
        public Nullable<int> AgrupacionId { get; set; }
        public Nullable<decimal> EscuelaId { get; set; }
        public Nullable<int> AgenteId { get; set; }
        public Nullable<int> EntidadId { get; set; }
        public string NombreActor { get; set; }
        public string PaginaWeb { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contacto { get; set; }
        public string Clasificacion { get; set; }
        public string HoraApertura { get; set; }
        public string HoraCierre { get; set; }

        public string facebook { get; set; }
        public string twitter { get; set; }
        public string youtube { get; set; }
        public string soundcloud { get; set; }
        public string descripcion { get; set; }

        public int documentoId { get; set; }
        public List<ImagenesBanner> banner { get; set; }
        public List<EstandarDTO> DirigidoASeleccionada { get; set; }
    }

    public class ImagenesBanner
    {
        public byte[] imagen { get; set; }
    }
}
