using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WS.Simus.Data
{
    [DataContract]
    public class AgenteData
    {
        #region Atributos
        int intAgenteId = 0;
        string strTipoDocumento = "";
        string strNumeroDocumento = "";
        string strPrimerNombre = "";
        string strSegundoNombre = "";
        string strPrimerApellido = "";
        string strSegundoApellido = "";
        string strGenero = "";
        DateTime datFechaNacimiento = Convert.ToDateTime("1900-01-01");
        string strDireccion = "";
        string strTelefono = "";
        string strCodigoMunicipio = "";
       // string strinCodigoDepartamento = "";
        string strLatitud = "";
        string strLongitud = "";
        string strCorreoElectronico = "";
        string strMensaje = "";
        byte[] byteImagen = null;
        DateTime datFechaCreacion = Convert.ToDateTime("1900-01-01");
        DateTime datFechaActualizacion = Convert.ToDateTime("1900-01-01");

        #endregion

        #region Propiedades
        [DataMember]
        public int AgenteId
        {
            get { return intAgenteId; }
            set { intAgenteId = value; }
        }

        [DataMember]
        public string TipoDocumento
        {
            get { return strTipoDocumento; }
            set { strTipoDocumento = value; }
        }

        [DataMember]
        public string NumeroDocumento
        {
            get { return strNumeroDocumento; }
            set { strNumeroDocumento = value; }
        }

        [DataMember]
        public string PrimerNombre
        {
            get { return strPrimerNombre; }
            set { strPrimerNombre = value; }
        }

        [DataMember]
        public string SegundoNombre
        {
            get { return strSegundoNombre; }
            set { strSegundoNombre = value; }
        }

        [DataMember]
        public string PrimerApellido
        {
            get { return strPrimerApellido; }
            set { strPrimerApellido = value; }
        }

        [DataMember]
        public string SegundoApellido
        {
            get { return strSegundoApellido; }
            set { strSegundoApellido = value; }
        }

        [DataMember]
        public string Genero
        {
            get { return strGenero; }
            set { strGenero = value; }
        }

        [DataMember]
        public DateTime FechaNacimiento
        {
            get { return datFechaNacimiento; }
            set { datFechaNacimiento = value; }
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
        public byte[] Imagen
        {
            get { return byteImagen; }
            set { byteImagen = value; }
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
        public string Mensaje
        {
            get { return strMensaje; }
            set { strMensaje = value; }
        }
        #endregion
     
    }
}