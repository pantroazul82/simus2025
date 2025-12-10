using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WS.Simus.Data
{
     [DataContract]
    public class EscuelaData
    {
        #region Atributos
        int intEscuelaId = 0;
        string intNit = "";
        string strNombreEscuela = "";
        int intAnoConstitucion = 0;
        string strResena = "";
        string strDireccion = "";
        string strTelefono = "";
        string strCodigoMunicipio = "";
        //string strinCodigoDepartamento = "";
        string strCorreoElectronicoEscuela = "";
        string strArea = "";
        string strSitioWeb = "";
        string strNombreContacto = "";
        string strCargoContacto = "";
        string strTelefonoContacto = "";
        string strCorreoElectronicoContacto = "";
        string strMensaje = "";
        DateTime datFechaActualizacion = Convert.ToDateTime("1900-01-01");

        #endregion

        #region Propiedades
        [DataMember]
        public int EscuelaId
        {
            get { return intEscuelaId; }
            set { intEscuelaId = value; }
        }

        [DataMember]
        public string NombreEscuela
        {
            get { return strNombreEscuela; }
            set { strNombreEscuela = value; }
        }
        [DataMember]
        public string Nit
        {
            get { return intNit; }
            set { intNit = value; }
        }
        [DataMember]
        public int AnoConstitucion
        {
            get { return intAnoConstitucion; }
            set { intAnoConstitucion = value; }
        }

        [DataMember]
        public string Resena
        {
            get { return strResena; }
            set { strResena = value; }
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
        public string CorreoElectronicoEscuela
        {
            get { return strCorreoElectronicoEscuela; }
            set { strCorreoElectronicoEscuela = value; }
        }

        [DataMember]
        public string Area
        {
            get { return strArea; }
            set { strArea = value; }
        }

        [DataMember]
        public string SitioWeb
        {
            get { return strSitioWeb; }
            set { strSitioWeb = value; }
        }

        [DataMember]
        public string NombreContacto
        {
            get { return strNombreContacto; }
            set { strNombreContacto = value; }
        }
        [DataMember]
        public string CargoContacto
        {
            get { return strCargoContacto; }
            set { strCargoContacto = value; }
        }

        [DataMember]
        public string CorreoElectronicoContacto
        {
            get { return strCorreoElectronicoContacto; }
            set { strCorreoElectronicoContacto = value; }
        }

        [DataMember]
        public string TelefonoContacto
        {
            get { return strTelefonoContacto; }
            set { strTelefonoContacto = value; }
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