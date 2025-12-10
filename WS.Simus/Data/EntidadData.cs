using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WS.Simus.Data
{
    [DataContract]
    public class EntidadData
    {
        #region Atributos
        int intEntidadId = 0;
        int intNit = 0;
        int intDigitoVerificacion = 0;
        string strNombre = "";
        string strLinkPortafolio = "";
        string strDireccion = "";
        string strTelefono = "";
        string strCodigoMunicipio = "";
        //string strinCodigoDepartamento = "";
        string strLatitud = "";
        string strLongitud = "";
        string strCorreoElectronico = "";
        string strMensaje = "";
        string strTipoEntidad = "";
        string strDescipcion = "";
        DateTime datFechaCreacion = Convert.ToDateTime("1900-01-01");
        DateTime datFechaActualizacion = Convert.ToDateTime("1900-01-01");

        #endregion

        #region Propiedades
        [DataMember]
        public int EntidadId
        {
            get { return intEntidadId; }
            set { intEntidadId = value; }
        }

        [DataMember]
        public int Nit
        {
            get { return intNit; }
            set { intNit = value; }
        }

        [DataMember]
        public int DigitoVerificacion
        {
            get { return intDigitoVerificacion; }
            set { intDigitoVerificacion = value; }
        }

        [DataMember]
        public string Nombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }

        [DataMember]
        public string LinkPortafolio
        {
            get { return strLinkPortafolio; }
            set { strLinkPortafolio = value; }
        }

        [DataMember]
        public string Direccion
        {
            get { return strDireccion; }
            set { strDireccion = value; }
        }

        [DataMember]
        public string Telefono
        {
            get { return strTelefono; }
            set { strTelefono = value; }
        }

        [DataMember]
        public string CodigoMunicipio
        {
            get { return strCodigoMunicipio; }
            set { strCodigoMunicipio = value; }
        }

        [DataMember]
        public string Latitud
        {
            get { return strLatitud; }
            set { strLatitud = value; }
        }

        [DataMember]
        public string Longitud
        {
            get { return strLongitud; }
            set { strLongitud = value; }
        }

        [DataMember]
        public string CorreoElectronico
        {
            get { return strCorreoElectronico; }
            set { strCorreoElectronico = value; }
        }

        [DataMember]
        public DateTime FechaCreacion
        {
            get { return datFechaCreacion; }
            set { datFechaCreacion = value; }
        }

        [DataMember]
        public DateTime FechaActualizacion
        {
            get { return datFechaActualizacion; }
            set { datFechaActualizacion = value; }
        }

        [DataMember]
        public string TipoEntidad
        {
            get { return strTipoEntidad; }
            set { strTipoEntidad = value; }
        }

        [DataMember]
        public string Descripcion
        {
            get { return strDescipcion; }
            set { strDescipcion = value; }
        }

        [DataMember]
        public string Mensaje
        {
            get { return strMensaje; }
            set { strMensaje = value; }
        }
        #endregion
    }
}