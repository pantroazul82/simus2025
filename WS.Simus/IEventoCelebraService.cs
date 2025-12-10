using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace WS.Simus
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEventoCelebraService" en el código y en el archivo de configuración a la vez.

    [ServiceContract(Namespace = Constantes.constantes.Namespace)]
   public interface IEventoCelebraService
    {

        [OperationContract]
        //[WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "CantidadMunicipiosParticipantes")]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
         
        string CantidadMunicipiosParticipantes();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CantidadConciertos")]
        //[OperationContract]
        //[WebInvoke(UriTemplate = "/CantidadConciertos", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json)]
        string CantidadConciertos();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CantidadArtistas")]
        string CantidadArtistas();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CantidadAgrupaciones")]
        string CantidadAgrupaciones();

     
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, UriTemplate = "CantidadMunicipioDanza")]
        string CantidadMunicipioDanza();


        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CantidadDepartamentoDanza")]
        string CantidadDepartamentoDanza();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CantidadEventosDanza")]
        string CantidadEventosDanza();
    }
}
