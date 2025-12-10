using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaComun.DTO
{
    public class UsuarioDTOSIM
    {
        private DateTime? _date = null;
        public int Id { get; set; }
        public string IdUserRSS { get; set; }
        public string TipoRSS { get; set; }
        public string Email { get; set; }
        public string Identificacion { get; set; }
        public string CodTipoDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string CodPais { get; set; }
        public string CodDpto { get; set; }
        public string CodMunicipio { get; set; }
        public string Sexo { get; set; }
        public bool esUsuarioInterno { get; set; }

        public bool esActivo { get; set; }


        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaModificacion { get; set; }

        public decimal AreaId { get; set; }
        public decimal DptoId { get; set; }
        public string rutaFoto { get; set; }
        public bool esnuevoenSimus { get; set; }
        public decimal IdSipa { get; set; }
        public string contrasena { get; set; }
        public byte[] imagen { get; set; }

        public string nombrecompleto { get; set; }
        public string nombreRol { get; set; }

        #region varibles de etsados de creacion usuario
        public bool esUsuarioSiMUS { get; set; }
        public List<int> IdRol { get; set; }
        public bool puedeEditaCorreo { get; set; }

        /// <summary>
        /// Indica que se realziao un cambio en la contraseña
        /// </summary>
        public bool restablececontrasena { get; set; }
        public bool tokenInvalido { get; set; }
        public bool cambioContraseña { get; set; }
        #endregion
        #region proceso de modificaciony creacion

        public bool escreateeditexistoso { get; set; }
        public bool esactualizadoPerfil { get; set; }
        public bool esactualizadoMenu { get; set; }
        public bool esactualizadoPagina { get; set; }

        public DateTime? Fechanacimiento
        {
            get { return _date; }
            set { _date = value; }
        }
        #endregion

        public string segundoApellido { get; set; }
        public int IdAgente { get; set; }
        public bool esAgente { get; set; }
    }

    public class UsuarioBasicoDTO
    {
        public int UsuarioId { get; set; }
        public int AgenteId { get; set; }
        public string CodTipoDocumento { get; set; }
        public string Identificacion { get; set; }
        public string TipoRSS { get; set; }
        public bool EsAgente { get; set; }
        public byte[] imagen { get; set; }
        public bool esUsuarioInterno { get; set; }
        public bool esActivo { get; set; }
        public bool esUsuarioSiMUS { get; set; }
        public bool esUsuariodeRSS { get; set; }
        public string rutafoto { get; set; }
    }
}
